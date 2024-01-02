using System;
using JetBrains.Annotations;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace SmoothTween
{
    [Serializable]
    internal class ReusableTween
    {
#if UNITY_EDITOR
        [SerializeField, HideInInspector] internal string debugDescription;
#endif
        internal int id = -1;
        internal object target;
        [SerializeField, CanBeNull] internal UnityEngine.Object unityTarget;
        [SerializeField] internal bool isPaused;
        internal bool isAlive;
        [SerializeField] internal float elapsedTimeTotal;
        [SerializeField] internal float easedInterpolationFactor;
        internal float cycleDuration;
        internal PropType propType;
        internal TweenType tweenType;
        [SerializeField] internal ValueContainer startValue;
        [SerializeField] internal ValueContainer endValue;
        internal ValueContainer diff;
        internal bool isAdditive;
        internal ValueContainer prevVal;
        [SerializeField] internal TweenSettings settings;
        [SerializeField] private int cyclesDone;
        public const int iniCyclesDone = -1;

        internal object customOnValueChange;
        internal int intParam;
        private Action<ReusableTween> onValueChange;
        private Action<ReusableTween> onComplete;
        private object onCompleteCallback;
        private object onCompleteTarget;

        internal float waitDelay;
        internal Sequence sequence;
        internal Tween prev;
        internal Tween next;
        internal Tween prevSibling;
        internal Tween nextSibling;

        internal Func<ReusableTween, ValueContainer> getter;
        internal bool startFromCurrent;

        private bool stoppedEmergent;
        internal readonly TweenCoroutineEnumerator coroutineEnumerator = new TweenCoroutineEnumerator();
        internal float timeScale = 1f;
        internal Tween.ShakeData shakeData;
        private State state;

        internal bool UpdateAndCheckIfRunning(float dt)
        {
            if (!isAlive)
            {
                return sequence.IsCreated;
            }

            if (!isPaused)
            {
                SetElapsedTimeTotal(elapsedTimeTotal + dt * timeScale);
            }

            return isAlive;
        }

        internal void SetElapsedTimeTotal(float newElapsedTimeTotal)
        {
            if (!sequence.IsCreated)
            {
                SetElapsedTimeTotal(newElapsedTimeTotal, out _);
                return;
            }

            if (IsMainSequenceRoot())
            {
                UpdateSequence(newElapsedTimeTotal, false);
            }
        }

        internal void UpdateSequence(float _elapsedTimeTotal, bool isRestart)
        {
            var prevEasedT = easedInterpolationFactor;
            SetElapsedTimeTotal(_elapsedTimeTotal, out int cyclesDiff);
            var isRestartToBeginning = isRestart && cyclesDiff < 0;
            if (cyclesDiff != 0 && !isRestartToBeginning)
            {
                if (isRestart)
                {
                    cyclesDiff = 1;
                }

                var cyclesDiffAbs = Mathf.Abs(cyclesDiff);
                cyclesDone -= cyclesDiff;
                var cyclesDelta = cyclesDiff > 0 ? 1 : -1;
                var interpolationFactor = cyclesDelta > 0 ? 1f : 0f;
                for (var i = 0; i < cyclesDiffAbs; i++)
                {
                    if (cyclesDone == settings.cycles || cyclesDone == iniCyclesDone)
                    {
                        cyclesDone += cyclesDelta;
                        continue;
                    }

                    var easedT = CalcEasedT(interpolationFactor, cyclesDone);
                    var isForwardCycle = easedT > 0.5f;
                    const float negativeElapsedTime = -1000f;
                    if (!ForceChildrenToPos())
                    {
                        return;
                    }

                    bool ForceChildrenToPos()
                    {
                        var simulatedSequenceElapsedTime = isForwardCycle ? float.MaxValue : negativeElapsedTime;
                        foreach (var t in sequence.GetSelfChildren(isForwardCycle))
                        {
                            var tween = t.tween;
                            tween.updateSequenceChild(simulatedSequenceElapsedTime, isRestart);
                            if (!sequence.isAlive)
                            {
                                return false;
                            }
                        }

                        return true;
                    }

                    cyclesDone += cyclesDelta;
                    var sequenceCycleMode = settings.cycleMode;
                    if (sequenceCycleMode == CycleMode.Restart && cyclesDone != settings.cycles && cyclesDone != iniCyclesDone)
                    {
                        // '&& cyclesDone != 0' check is wrong because we should do the restart when moving from 1 to 0 cyclesDone
                        if (!RestartChildren())
                        {
                            return;
                        }

                        bool RestartChildren()
                        {
                            // print($"restart to pos: {!isForwardCycle}");
                            var simulatedSequenceElapsedTime = !isForwardCycle ? float.MaxValue : negativeElapsedTime;
                            prevEasedT = simulatedSequenceElapsedTime;
                            foreach (var t in sequence.GetSelfChildren(!isForwardCycle))
                            {
                                var tween = t.tween;
                                tween.updateSequenceChild(simulatedSequenceElapsedTime, true);
                                if (!sequence.isAlive)
                                {
                                    return false;
                                }
                            }

                            return true;
                        }
                    }
                }

                if (IsDone(cyclesDiff))
                {
                    if (IsMainSequenceRoot() && !isPaused)
                    {
                        sequence.ReleaseTweens();
                    }

                    return;
                }
            }

            easedInterpolationFactor = Mathf.Clamp01(easedInterpolationFactor);
            bool isForward = easedInterpolationFactor > prevEasedT;
            float sequenceElapsedTime = easedInterpolationFactor * cycleDuration;
            foreach (var t in sequence.GetSelfChildren(isForward))
            {
                t.tween.updateSequenceChild(sequenceElapsedTime, isRestart);
                if (!sequence.isAlive)
                {
                    return;
                }
            }
        }

        bool IsDone(int cyclesDiff)
        {
            if (timeScale >= 0f)
            {
                return cyclesDiff > 0 && cyclesDone == settings.cycles;
            }

            return cyclesDiff < 0 && cyclesDone == iniCyclesDone;
        }

        void updateSequenceChild(float encompassingElapsedTime, bool isRestart)
        {
            if (isSequenceRoot())
            {
                UpdateSequence(encompassingElapsedTime, isRestart);
            }
            else
            {
                SetElapsedTimeTotal(encompassingElapsedTime, out _);
            }
        }

        internal bool IsMainSequenceRoot() => tweenType == TweenType.MainSequence;
        internal bool isSequenceRoot() => tweenType == TweenType.MainSequence || tweenType == TweenType.NestedSequence;

        private void SetElapsedTimeTotal(float _elapsedTimeTotal, out int cyclesDiff)
        {
            elapsedTimeTotal = _elapsedTimeTotal;
            var t = CalcTFromElapsedTimeTotal(_elapsedTimeTotal, out cyclesDiff, out var newState);
            cyclesDone += cyclesDiff;
            if (newState == State.Running || state != newState)
            {
                var easedT = CalcEasedT(t, cyclesDone);
                state = newState;
                ReportOnValueChange(easedT);
                if (stoppedEmergent || !isAlive)
                {
                    return;
                }
            }

            if (IsDone(cyclesDiff))
            {
                if (!IsInSequence() && !isPaused)
                {
                    Kill();
                }

                ReportOnComplete();
            }
        }

        private float CalcTFromElapsedTimeTotal(float _elapsedTimeTotal, out int cyclesDiff, out State newState)
        {
            var cyclesTotal = settings.cycles;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (_elapsedTimeTotal == float.MaxValue)
            {
                var cyclesLeft = cyclesTotal - cyclesDone;
                cyclesDiff = cyclesLeft;
                newState = State.After;
                return 1f;
            }

            _elapsedTimeTotal -= waitDelay;
            if (_elapsedTimeTotal < 0f)
            {
                cyclesDiff = iniCyclesDone - cyclesDone;
                newState = State.Before;
                return 0f;
            }

            var duration = settings.duration;
            if (duration == 0f)
            {
                if (cyclesTotal == -1)
                {
                    cyclesDiff = cyclesDone == iniCyclesDone ? 2 : 1;
                    newState = State.Running;
                    return 1f;
                }

                if (_elapsedTimeTotal == 0f)
                {
                    cyclesDiff = iniCyclesDone - cyclesDone;
                    newState = State.Before;
                    return 0f;
                }

                var cyclesLeft = cyclesTotal - cyclesDone;
                cyclesDiff = cyclesLeft;
                newState = State.After;
                return 1f;
            }

            var newCyclesDone = (int)(_elapsedTimeTotal / cycleDuration);
            if (cyclesTotal != -1 && newCyclesDone > cyclesTotal)
            {
                newCyclesDone = cyclesTotal;
            }

            cyclesDiff = newCyclesDone - cyclesDone;
            if (cyclesTotal != -1 && cyclesDone + cyclesDiff == cyclesTotal)
            {
                newState = State.After;
                return 1f;
            }

            var elapsedTimeInCycle = _elapsedTimeTotal - cycleDuration * newCyclesDone - settings.startDelay;
            if (elapsedTimeInCycle < 0f)
            {
                newState = State.Before;
                return 0f;
            }

            var result = elapsedTimeInCycle / duration;
            if (result > 1f)
            {
                newState = State.After;
                return 1f;
            }

            newState = State.Running;
            return result;
        }

        internal void Reset()
        {
#if UNITY_EDITOR
            debugDescription = null;
#endif
            id = -1;
            target = null;
            unityTarget = null;
            propType = PropType.None;
            settings.customEase = null;
            customOnValueChange = null;
            shakeData.Reset();
            onValueChange = null;
            onComplete = null;
            onCompleteCallback = null;
            onCompleteTarget = null;
            getter = null;
            stoppedEmergent = false;
            waitDelay = 0f;
            coroutineEnumerator.resetEnumerator();
            tweenType = TweenType.None;
            timeScale = 1f;
            ClearOnUpdate();
        }

        internal void OnComplete<T>(T _target, Action<T> _onComplete) where T : class
        {
            onCompleteTarget = _target;
            onCompleteCallback = _onComplete;
            onComplete = tween =>
            {
                var callback = tween.onCompleteCallback as Action<T>;
                var _onCompleteTarget = tween.onCompleteTarget as T;
                callback?.Invoke(_onCompleteTarget);
            };
        }

        internal void Setup(object _target, ref TweenSettings _settings, Action<ReusableTween> _onValueChange, Func<ReusableTween, ValueContainer> _getter,
            bool _startFromCurrent)
        {
            if (_settings.ease == Ease.Default)
            {
                _settings.ease = SmoothTweenManager.Instance.defaultEase;
            }
            else if (_settings.ease == Ease.Custom && _settings.parametricEase == ParametricEase.None)
            {
                if (_settings.customEase == null || !TweenSettings.ValidateCustomCurveKeyframes(_settings.customEase))
                {
                    Debug.LogError($"Ease type is Ease.Custom, but {nameof(TweenSettings.customEase)} is not configured correctly.");
                    _settings.ease = SmoothTweenManager.Instance.defaultEase;
                }
            }

            state = State.Before;
            target = _target;
            setUnityTarget(_target);
            elapsedTimeTotal = 0f;
            easedInterpolationFactor = float.MinValue;
            isPaused = false;
            Revive();

            cyclesDone = iniCyclesDone;
            _settings.SetValidValues();
            settings.CopyFrom(ref _settings);
            RecalculateTotalDuration();
            onValueChange = _onValueChange;
            startFromCurrent = _startFromCurrent;
            getter = _getter;
            if (!_startFromCurrent)
            {
                CacheDiff();
            }

            if (propType == PropType.Quaternion)
            {
                prevVal.QuaternionVal = Quaternion.identity;
            }
            else
            {
                prevVal.Reset();
            }
        }

        internal void setUnityTarget(object _target)
        {
            var unityObject = _target as UnityEngine.Object;
            unityTarget = unityObject;
        }

        private void ReportOnValueChange(float _easedInterpolationFactor)
        {
            if (startFromCurrent)
            {
                startFromCurrent = false;
                startValue = Tween.TryGetStartValueFromOtherShake(this) ?? getter(this);
                CacheDiff();
            }

            easedInterpolationFactor = _easedInterpolationFactor;
            onValueChange(this);
            if (stoppedEmergent || !isAlive)
            {
                return;
            }

            onUpdate?.Invoke(this);
        }

        private void ReportOnComplete()
        {
            onComplete?.Invoke(this);
        }

        internal bool HasOnComplete => onComplete != null;


        internal string GetDescription()
        {
            var result = "";
            if (!isAlive)
            {
                result += " - ";
            }

            if (target != SmoothTweenManager.dummyTarget)
            {
                result += $"{(unityTarget != null ? unityTarget.name : target?.GetType().Name)} / ";
            }

            var duration = settings.duration;
            if (tweenType == TweenType.Delay)
            {
                if (duration == 0f && onComplete != null)
                {
                    result += "Callback";
                }
                else
                {
                    result += $"Delay / duration {duration}";
                }
            }
            else
            {
                if (tweenType == TweenType.MainSequence)
                {
                    result += $"Sequence {id}";
                }
                else if (tweenType == TweenType.NestedSequence)
                {
                    result += $"Sequence {id} (nested)";
                }
                else
                {
                    result += $"{(tweenType != TweenType.None ? tweenType.ToString() : propType.ToString())}";
                }

                result += " / duration ";
                result += $"{duration}";
            }

            result += $" / id {id}";
            if (sequence.IsCreated && tweenType != TweenType.MainSequence)
            {
                result += $" / sequence {sequence.root.id}";
            }

            return result;
        }

        internal float CalcDurationWithWaitDependencies()
        {
            var cycles = settings.cycles;
            return waitDelay + cycleDuration * cycles;
        }

        internal void RecalculateTotalDuration()
        {
            cycleDuration = settings.startDelay + settings.duration + settings.endDelay;
        }

        internal float FloatVal => startValue.x + diff.x * easedInterpolationFactor;

        internal Vector2 Vector2Val
        {
            get
            {
                var easedT = easedInterpolationFactor;
                return new Vector2(
                    startValue.x + diff.x * easedT,
                    startValue.y + diff.y * easedT);
            }
        }

        internal Vector3 Vector3Val
        {
            get
            {
                var easedT = easedInterpolationFactor;
                return new Vector3(
                    startValue.x + diff.x * easedT,
                    startValue.y + diff.y * easedT,
                    startValue.z + diff.z * easedT);
            }
        }

        internal Vector4 Vector4Val
        {
            get
            {
                var easedT = easedInterpolationFactor;
                return new Vector4(
                    startValue.x + diff.x * easedT,
                    startValue.y + diff.y * easedT,
                    startValue.z + diff.z * easedT,
                    startValue.w + diff.w * easedT);
            }
        }

        internal Color ColorVal
        {
            get
            {
                var easedT = easedInterpolationFactor;
                return new Color(
                    startValue.x + diff.x * easedT,
                    startValue.y + diff.y * easedT,
                    startValue.z + diff.z * easedT,
                    startValue.w + diff.w * easedT);
            }
        }

        internal Rect RectVal
        {
            get
            {
                var easedT = easedInterpolationFactor;
                return new Rect(
                    startValue.x + diff.x * easedT,
                    startValue.y + diff.y * easedT,
                    startValue.z + diff.z * easedT,
                    startValue.w + diff.w * easedT);
            }
        }

        internal Quaternion QuaternionVal => Quaternion.SlerpUnclamped(startValue.QuaternionVal, endValue.QuaternionVal, easedInterpolationFactor);

        private float CalcEasedT(float t, int cycle)
        {
            var cycleMode = settings.cycleMode;
            var cyclesTotal = settings.cycles;
            if (cycle == cyclesTotal)
            {
                // Debug.Log("cyclesDone == cyclesTotal");
                switch (cycleMode)
                {
                    case CycleMode.Restart:
                        return Evaluate(1f);
                    case CycleMode.Yoyo:
                    case CycleMode.Rewind:
                        return Evaluate(cyclesTotal % 2);
                    case CycleMode.Incremental:
                        return cyclesTotal;
                    default:
                        throw new Exception();
                }
            }

            if (cycleMode == CycleMode.Restart)
            {
                return Evaluate(t);
            }

            if (cycleMode == CycleMode.Incremental)
            {
                return Evaluate(t) + cycle;
            }

            var isForwardCycle = cycle % 2 == 0;
            if (isForwardCycle)
            {
                return Evaluate(t);
            }

            if (cycleMode == CycleMode.Yoyo)
            {
                return 1 - Evaluate(t);
            }

            if (cycleMode == CycleMode.Rewind)
            {
                return Evaluate(1 - t);
            }

            throw new Exception();
        }

        private float Evaluate(float t)
        {
            if (settings.ease != Ease.Custom) return StandardEasing.Evaluate(t, settings.ease);
            return settings.parametricEase != ParametricEase.None ? Easing.Evaluate(t, this) : settings.customEase.Evaluate(t);
        }

        internal void CacheDiff()
        {
            if (propType == PropType.Quaternion)
            {
                startValue.QuaternionVal.Normalize();
                endValue.QuaternionVal.Normalize();
            }
            else
            {
                diff.x = endValue.x - startValue.x;
                diff.y = endValue.y - startValue.y;
                diff.z = endValue.z - startValue.z;
                diff.w = endValue.w - startValue.w;
            }
        }

        internal void ForceComplete()
        {
            Kill();
            cyclesDone = settings.cycles;
            ReportOnValueChange(CalcEasedT(1f, settings.cycles));
            if (stoppedEmergent)
            {
                return;
            }

            ReportOnComplete();
        }

        internal void WarnOnCompleteIgnored(bool isTargetDestroyed)
        {
            if (!HasOnComplete) return;
            onComplete = null;
            var msg = $"Tween: {GetDescription()}.\n";
            if (isTargetDestroyed)
            {
                msg +=
                    "\nIf you use tween.OnComplete(), Tween.Delay(), or sequence.ChainDelay() only for cosmetic purposes, you can turn off this error by passing 'warnIfTargetDestroyed: false' to the method.\n";
            }

            Debug.LogError(msg, unityTarget);
        }

        internal void EmergencyStop(bool isTargetDestroyed = false)
        {
            if (sequence.IsCreated)
            {
                var mainSequence = sequence;
                while (true)
                {
                    var _prev = mainSequence.root.tween.prev;
                    if (!_prev.IsCreated)
                    {
                        break;
                    }

                    var parent = _prev.tween.sequence;
                    if (!parent.IsCreated)
                    {
                        break;
                    }

                    mainSequence = parent;
                }

                mainSequence.EmergencyStop();
            }
            else if (isAlive)
            {
                Kill();
            }

            stoppedEmergent = true;
            WarnOnCompleteIgnored(isTargetDestroyed);
        }

        internal void Kill()
        {
            isAlive = false;
#if UNITY_EDITOR
            debugDescription = null;
#endif
        }

        private void Revive()
        {
            isAlive = true;
#if UNITY_EDITOR
            debugDescription = null;
#endif
        }

        internal bool IsInSequence()
        {
            return sequence.IsCreated;
        }

        internal bool CanManipulate() => !IsInSequence() || IsMainSequenceRoot();

        internal bool TrySetPause(bool value)
        {
            if (isPaused == value)
            {
                return false;
            }

            isPaused = value;
            return true;
        }

        private object onUpdateTarget;
        private object onUpdateCallback;
        private Action<ReusableTween> onUpdate;

        internal void SetOnUpdate<T>(T _target, Action<T, Tween> _onUpdate) where T : class
        {
            onUpdateTarget = _target;
            onUpdateCallback = _onUpdate;
            onUpdate = reusableTween => reusableTween.InvokeOnUpdate<T>();
        }

        private void InvokeOnUpdate<T>() where T : class
        {
            var callback = onUpdateCallback as Action<T, Tween>;
            var _onUpdateTarget = onUpdateTarget as T;
            try
            {
                callback?.Invoke(_onUpdateTarget, new Tween(this));
            }
            catch (Exception e)
            {
                Debug.LogError($"OnUpdate() will not be called again because it thrown exception, tween: {GetDescription()}, exception:\n{e}", unityTarget);
                ClearOnUpdate();
            }
        }

        private void ClearOnUpdate()
        {
            onUpdateTarget = null;
            onUpdateCallback = null;
            onUpdate = null;
        }

        public override string ToString()
        {
            return GetDescription();
        }

        private enum State
        {
            Before,
            Running,
            After
        }

        internal float GetElapsedTimeTotal()
        {
            var result = elapsedTimeTotal;
            var durationTotal = GetDurationTotal();
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return result == float.MaxValue ? durationTotal : Mathf.Clamp(result, 0f, durationTotal);
        }

        internal float GetDurationTotal()
        {
            var cyclesTotal = settings.cycles;
            if (cyclesTotal == -1)
            {
                return float.PositiveInfinity;
            }

            return cycleDuration * cyclesTotal;
        }

        internal int GetCyclesDone()
        {
            var result = cyclesDone;
            return result == iniCyclesDone ? 0 : result;
        }
    }
}