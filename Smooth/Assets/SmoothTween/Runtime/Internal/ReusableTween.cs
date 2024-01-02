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
        [CanBeNull] internal object target;
        [SerializeField, CanBeNull] internal UnityEngine.Object unityTarget;
        [SerializeField] internal bool _isPaused;
        internal bool _isAlive;
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
        [SerializeField] int cyclesDone;
        const int iniCyclesDone = -1;

        internal object customOnValueChange;
        internal int intParam;
        Action<ReusableTween> onValueChange;

        [CanBeNull] Action<ReusableTween> onComplete;
        [CanBeNull] object onCompleteCallback;
        [CanBeNull] object onCompleteTarget;

        internal float waitDelay;
        internal Sequence sequence;
        internal Tween prev;
        internal Tween next;
        internal Tween prevSibling;
        internal Tween nextSibling;

        internal Func<ReusableTween, ValueContainer> getter;
        internal bool startFromCurrent;

        bool stoppedEmergently;
        internal readonly TweenCoroutineEnumerator coroutineEnumerator = new TweenCoroutineEnumerator();
        internal float timeScale = 1f;
        internal Tween.ShakeData shakeData;
        State state;

        internal bool UpdateAndCheckIfRunning(float dt)
        {
            if (!_isAlive)
            {
                return sequence.IsCreated;
            }

            if (!_isPaused)
            {
                SetElapsedTimeTotal(elapsedTimeTotal + dt * timeScale);
            }

            return _isAlive;
        }

        internal void SetElapsedTimeTotal(float newElapsedTimeTotal)
        {
            if (!sequence.IsCreated)
            {
                setElapsedTimeTotal(newElapsedTimeTotal, out _);
                return;
            }

            if (isMainSequenceRoot())
            {
                updateSequence(newElapsedTimeTotal, false);
            }
        }

        internal void updateSequence(float _elapsedTimeTotal, bool isRestart)
        {
            float prevEasedT = easedInterpolationFactor;
            setElapsedTimeTotal(_elapsedTimeTotal, out int cyclesDiff); // update sequence root

            bool isRestartToBeginning = isRestart && cyclesDiff < 0;
            if (cyclesDiff != 0 && !isRestartToBeginning)
            {
                // print($"           sequence cyclesDiff: {cyclesDiff}");
                if (isRestart)
                {
                    cyclesDiff = 1;
                }

                int cyclesDiffAbs = Mathf.Abs(cyclesDiff);
                int newCyclesDone = cyclesDone;
                cyclesDone -= cyclesDiff;
                int cyclesDelta = cyclesDiff > 0 ? 1 : -1;
                var interpolationFactor = cyclesDelta > 0 ? 1f : 0f;
                for (int i = 0; i < cyclesDiffAbs; i++)
                {
                    if (cyclesDone == settings.cycles || cyclesDone == iniCyclesDone)
                    {
                        // do nothing when moving backward from the last cycle or forward from the -1 cycle
                        cyclesDone += cyclesDelta;
                        continue;
                    }

                    var easedT = calcEasedT(interpolationFactor, cyclesDone);
                    var isForwardCycle = easedT > 0.5f;
                    const float negativeElapsedTime = -1000f;
                    if (!forceChildrenToPos())
                    {
                        return;
                    }

                    bool forceChildrenToPos()
                    {
                        // complete the previous cycles by forcing all children tweens to 0f or 1f
                        // print($" (i:{i}) force to pos: {isForwardCycle}");
                        var simulatedSequenceElapsedTime = isForwardCycle ? float.MaxValue : negativeElapsedTime;
                        foreach (var t in sequence.getSelfChildren(isForwardCycle))
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
                        if (!restartChildren())
                        {
                            return;
                        }

                        bool restartChildren()
                        {
                            // print($"restart to pos: {!isForwardCycle}");
                            var simulatedSequenceElapsedTime = !isForwardCycle ? float.MaxValue : negativeElapsedTime;
                            prevEasedT = simulatedSequenceElapsedTime;
                            foreach (var t in sequence.getSelfChildren(!isForwardCycle))
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

                if (isDone(cyclesDiff))
                {
                    if (isMainSequenceRoot() && !_isPaused)
                    {
                        sequence.releaseTweens();
                    }

                    return;
                }
            }

            easedInterpolationFactor = Mathf.Clamp01(easedInterpolationFactor);
            bool isForward = easedInterpolationFactor > prevEasedT;
            float sequenceElapsedTime = easedInterpolationFactor * cycleDuration;
            foreach (var t in sequence.getSelfChildren(isForward))
            {
                t.tween.updateSequenceChild(sequenceElapsedTime, isRestart);
                if (!sequence.isAlive)
                {
                    return;
                }
            }
        }

        bool isDone(int cyclesDiff)
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
                updateSequence(encompassingElapsedTime, isRestart);
            }
            else
            {
                setElapsedTimeTotal(encompassingElapsedTime, out _);
            }
        }

        internal bool isMainSequenceRoot() => tweenType == TweenType.MainSequence;
        internal bool isSequenceRoot() => tweenType == TweenType.MainSequence || tweenType == TweenType.NestedSequence;

        void setElapsedTimeTotal(float _elapsedTimeTotal, out int cyclesDiff)
        {
            elapsedTimeTotal = _elapsedTimeTotal;
            float t = calcTFromElapsedTimeTotal(_elapsedTimeTotal, out cyclesDiff, out var newState);
            cyclesDone += cyclesDiff;
            if (newState == State.Running || state != newState)
            {
                var easedT = calcEasedT(t, cyclesDone);
                // print($"state: {state}/{newState}, cycles: {cyclesDone}/{settings.cycles} (diff: {cyclesDiff}), elapsedTimeTotal: {elapsedTimeTotal}, interpolation: {t}/{easedT}");
                state = newState;
                ReportOnValueChange(easedT);
                if (stoppedEmergently || !_isAlive)
                {
                    return;
                }
            }

            if (isDone(cyclesDiff))
            {
                if (!IsInSequence() && !_isPaused)
                {
                    kill();
                }

                ReportOnComplete();
            }
        }

        float calcTFromElapsedTimeTotal(float _elapsedTimeTotal, out int cyclesDiff, out State newState)
        {
            // key timeline points: 0 | startDelay | duration | 1 | endDelay | onComplete
            var cyclesTotal = settings.cycles;
            if (_elapsedTimeTotal == float.MaxValue)
            {
                var cyclesLeft = cyclesTotal - cyclesDone;
                cyclesDiff = cyclesLeft;
                newState = State.After;
                return 1f;
            }

            _elapsedTimeTotal -= waitDelay; // waitDelay is applied before calculating cycles
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

        /*void print(object msg) {
            Debug.Log($"[{Time.frameCount}]  id {id}  {msg}");
        }*/

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
            stoppedEmergently = false;
            waitDelay = 0f;
            coroutineEnumerator.resetEnumerator();
            tweenType = TweenType.None;
            timeScale = 1f;
            clearOnUpdate();
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


        /// _getter is null for custom tweens
        internal void Setup([CanBeNull] object _target, ref TweenSettings _settings, [NotNull] Action<ReusableTween> _onValueChange, [CanBeNull] Func<ReusableTween, ValueContainer> _getter,
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
            _isPaused = false;
            revive();

            cyclesDone = iniCyclesDone;
            _settings.SetValidValues();
            settings.CopyFrom(ref _settings);
            recalculateTotalDuration();
            onValueChange = _onValueChange;
            startFromCurrent = _startFromCurrent;
            getter = _getter;
            if (!_startFromCurrent)
            {
                cacheDiff();
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

        /// Tween.Custom and Tween.ShakeCustom try-catch the <see cref="onValueChange"/> and calls <see cref="ReusableTween.EmergencyStop"/> if an exception occurs.
        /// <see cref="ReusableTween.EmergencyStop"/> sets <see cref="stoppedEmergently"/> to true.
        void ReportOnValueChange(float _easedInterpolationFactor)
        {
            // Debug.Log($"id {id}, ReportOnValueChange {_easedInterpolationFactor}");
            if (startFromCurrent)
            {
                startFromCurrent = false;
                startValue = Tween.tryGetStartValueFromOtherShake(this) ?? getter(this);
                cacheDiff();
            }

            easedInterpolationFactor = _easedInterpolationFactor;
            onValueChange(this);
            if (stoppedEmergently || !_isAlive)
            {
                return;
            }

            onUpdate?.Invoke(this);
        }

        void ReportOnComplete()
        {
            onComplete?.Invoke(this);
        }

        internal bool HasOnComplete => onComplete != null;

        [NotNull]
        internal string GetDescription()
        {
            string result = "";
            if (!_isAlive)
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
                /*if (waitDelay != 0f) {
                    result += $"{waitDelay}+";
                }*/
                result += $"{duration}";
            }

            result += $" / id {id}";
            if (sequence.IsCreated && tweenType != TweenType.MainSequence)
            {
                result += $" / sequence {sequence.root.id}";
            }

            return result;
        }

        internal float calcDurationWithWaitDependencies()
        {
            var cycles = settings.cycles;
            return waitDelay + cycleDuration * cycles;
        }

        internal void recalculateTotalDuration()
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

        float calcEasedT(float t, int cyclesDone)
        {
            var cycleMode = settings.cycleMode;
            var cyclesTotal = settings.cycles;
            if (cyclesDone == cyclesTotal)
            {
                // Debug.Log("cyclesDone == cyclesTotal");
                switch (cycleMode)
                {
                    case CycleMode.Restart:
                        return evaluate(1f);
                    case CycleMode.Yoyo:
                    case CycleMode.Rewind:
                        return evaluate(cyclesTotal % 2);
                    case CycleMode.Incremental:
                        return cyclesTotal;
                    default:
                        throw new Exception();
                }
            }

            if (cycleMode == CycleMode.Restart)
            {
                return evaluate(t);
            }

            if (cycleMode == CycleMode.Incremental)
            {
                return evaluate(t) + cyclesDone;
            }

            var isForwardCycle = cyclesDone % 2 == 0;
            if (isForwardCycle)
            {
                return evaluate(t);
            }

            if (cycleMode == CycleMode.Yoyo)
            {
                return 1 - evaluate(t);
            }

            if (cycleMode == CycleMode.Rewind)
            {
                return evaluate(1 - t);
            }

            throw new Exception();
        }

        float evaluate(float t)
        {
            if (settings.ease == Ease.Custom)
            {
                if (settings.parametricEase != ParametricEase.None)
                {
                    return Easing.Evaluate(t, this);
                }

                return settings.customEase.Evaluate(t);
            }

            return StandardEasing.Evaluate(t, settings.ease);
        }

        internal void cacheDiff()
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
            kill(); // protects from recursive call
            cyclesDone = settings.cycles;
            ReportOnValueChange(calcEasedT(1f, settings.cycles));
            if (stoppedEmergently)
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

                mainSequence.emergencyStop();
            }
            else if (_isAlive)
            {
                // EmergencyStop() can be called after ForceComplete() and a caught exception in Tween.Custom()
                kill();
            }

            stoppedEmergently = true;
            WarnOnCompleteIgnored(isTargetDestroyed);
        }

        internal void kill()
        {
            _isAlive = false;
#if UNITY_EDITOR
            debugDescription = null;
#endif
        }

        void revive()
        {
            _isAlive = true;
#if UNITY_EDITOR
            debugDescription = null;
#endif
        }

        internal bool IsInSequence()
        {
            var result = sequence.IsCreated;
            return result;
        }

        internal bool canManipulate() => !IsInSequence() || isMainSequenceRoot();

        internal bool trySetPause(bool isPaused)
        {
            if (_isPaused == isPaused)
            {
                return false;
            }

            _isPaused = isPaused;
            return true;
        }

        [CanBeNull] object onUpdateTarget;
        object onUpdateCallback;
        Action<ReusableTween> onUpdate;

        internal void SetOnUpdate<T>(T _target, [NotNull] Action<T, Tween> _onUpdate) where T : class
        {
            onUpdateTarget = _target;
            onUpdateCallback = _onUpdate;
            onUpdate = reusableTween => reusableTween.invokeOnUpdate<T>();
        }

        void invokeOnUpdate<T>() where T : class
        {
            var callback = onUpdateCallback as Action<T, Tween>;
            var _onUpdateTarget = onUpdateTarget as T;
            try
            {
                callback(_onUpdateTarget, new Tween(this));
            }
            catch (Exception e)
            {
                Debug.LogError($"OnUpdate() will not be called again because it thrown exception, tween: {GetDescription()}, exception:\n{e}", unityTarget);
                clearOnUpdate();
            }
        }

        void clearOnUpdate()
        {
            onUpdateTarget = null;
            onUpdateCallback = null;
            onUpdate = null;
        }

        public override string ToString()
        {
            return GetDescription();
        }

        enum State
        {
            Before,
            Running,
            After
        }

        internal float getElapsedTimeTotal()
        {
            var result = elapsedTimeTotal;
            var durationTotal = getDurationTotal();
            if (result == float.MaxValue)
            {
                return durationTotal;
            }

            return Mathf.Clamp(result, 0f, durationTotal);
        }

        internal float getDurationTotal()
        {
            var cyclesTotal = settings.cycles;
            if (cyclesTotal == -1)
            {
                return float.PositiveInfinity;
            }

            return cycleDuration * cyclesTotal;
        }

        internal int getCyclesDone()
        {
            int result = cyclesDone;
            if (result == iniCyclesDone)
            {
                return 0;
            }

            return result;
        }
    }
}