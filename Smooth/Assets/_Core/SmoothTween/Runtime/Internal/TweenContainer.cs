using System;
using UnityEngine;

namespace SmoothTween.Runtime
{
    [Serializable]
    internal class TweenContainer
    {
        private enum State
        {
            Before,
            Running,
            After
        }
#if UNITY_EDITOR
        [SerializeField, HideInInspector] internal string debugDescription;
#endif
        internal int id = -1;
        internal object target;
        [SerializeField] internal UnityEngine.Object unityTarget;
        [SerializeField] internal bool isPaused;
        internal bool isAlive;
        [SerializeField] internal float elapsedTimeTotal;
        [SerializeField] internal float easedInterpolationFactor;
        internal bool startFromCurrent;
        internal bool isAdditive;
        internal float cycleDuration;

        internal PropType propType;
        internal SmoothType smoothType;
        internal ValueContainer diff;
        [SerializeField] internal ValueContainer startValue;
        [SerializeField] internal ValueContainer endValue;

        internal float timeScale = 1f;

        [SerializeField] internal SmoothData data;
        [SerializeField] private int m_CyclesDone;

        internal float waitDelay;
        internal SmoothSequence smoothSequence;
        private bool m_StoppedEmergent;
        private const int iniCyclesDone = -1;

        private State m_State;

        private Action<TweenContainer> onComplete;
        internal Func<TweenContainer, ValueContainer> getter;
        private Action<TweenContainer> onValueChange;
        private Action<TweenContainer> onUpdate;

        internal bool CanManipulate() => !IsInSequence() || IsMainSequenceRoot();
        internal bool IsInSequence() => smoothSequence.IsCreated;
        internal bool IsMainSequenceRoot() => smoothType == SmoothType.MainSequence;

        internal bool UpdateAndCheckIfRunning(float dt)
        {
            if (!isAlive)
            {
                return smoothSequence.IsCreated;
            }

            if (!isPaused)
            {
                SetElapsedTimeTotal(elapsedTimeTotal + dt * timeScale);
            }

            return isAlive;
        }

        internal void SetElapsedTimeTotal(float newElapsedTimeTotal)
        {
            if (!smoothSequence.IsCreated)
            {
                SetElapsedTimeTotal(newElapsedTimeTotal, out _);
                return;
            }

            if (IsMainSequenceRoot())
            {
                UpdateSequence(newElapsedTimeTotal, false);
            }
        }

        private void SetElapsedTimeTotal(float _elapsedTimeTotal, out int cyclesDiff)
        {
            elapsedTimeTotal = _elapsedTimeTotal;
            var t = CalcTFromElapsedTimeTotal(_elapsedTimeTotal, out cyclesDiff, out var newState);
            m_CyclesDone += cyclesDiff;
            if (newState == State.Running || m_State != newState)
            {
                var easedT = CalcEasedT(t, m_CyclesDone);
                m_State = newState;
                ReportOnValueChange(easedT);
                if (m_StoppedEmergent || !isAlive)
                {
                    return;
                }
            }

            if (!IsDone(cyclesDiff)) return;
            if (!IsInSequence() && !isPaused)
            {
                Kill();
            }

            ReportOnComplete();
        }

        private bool IsDone(int cyclesDiff)
        {
            if (timeScale >= 0f)
            {
                return cyclesDiff > 0 && m_CyclesDone == data.cycles;
            }

            return cyclesDiff < 0 && m_CyclesDone == iniCyclesDone;
        }

        internal void Kill()
        {
            isAlive = false;
#if UNITY_EDITOR
            debugDescription = null;
#endif
        }

        private void ReportOnComplete()
        {
            onComplete?.Invoke(this);
        }

        internal void UpdateSequence(float _elapsedTimeTotal, bool isRestart)
        {
            var prevEasedT = easedInterpolationFactor;
            SetElapsedTimeTotal(_elapsedTimeTotal, out var cyclesDiff);
            var isRestartToBeginning = isRestart && cyclesDiff < 0;
            if (cyclesDiff != 0 && !isRestartToBeginning)
            {
                if (isRestart)
                {
                    cyclesDiff = 1;
                }

                var cyclesDiffAbs = Mathf.Abs(cyclesDiff);
                m_CyclesDone -= cyclesDiff;
                var cyclesDelta = cyclesDiff > 0 ? 1 : -1;
                var interpolationFactor = cyclesDelta > 0 ? 1f : 0f;
                for (var i = 0; i < cyclesDiffAbs; i++)
                {
                    if (m_CyclesDone == data.cycles || m_CyclesDone == iniCyclesDone)
                    {
                        m_CyclesDone += cyclesDelta;
                        continue;
                    }

                    var easedT = CalcEasedT(interpolationFactor, m_CyclesDone);
                    var isForwardCycle = easedT > 0.5f;
                    const float negativeElapsedTime = -1000f;
                    if (!ForceChildrenToPos())
                    {
                        return;
                    }

                    bool ForceChildrenToPos()
                    {
                        var simulatedSequenceElapsedTime = isForwardCycle ? float.MaxValue : negativeElapsedTime;
                        foreach (var t in smoothSequence.GetSelfChildren(isForwardCycle))
                        {
                            var tween = t.tween;
                            tween.updateSequenceChild(simulatedSequenceElapsedTime, isRestart);
                            if (!smoothSequence.isAlive)
                            {
                                return false;
                            }
                        }

                        return true;
                    }

                    m_CyclesDone += cyclesDelta;
                    var sequenceCycleMode = data.cycleMode;
                    if (sequenceCycleMode == CycleMode.Restart && m_CyclesDone != data.cycles && m_CyclesDone != iniCyclesDone)
                    {
                        if (!RestartChildren()) return;

                        bool RestartChildren()
                        {
                            var simulatedSequenceElapsedTime = !isForwardCycle ? float.MaxValue : negativeElapsedTime;
                            prevEasedT = simulatedSequenceElapsedTime;
                            foreach (var t in smoothSequence.GetSelfChildren(!isForwardCycle))
                            {
                                var tween = t.tween;
                                tween.updateSequenceChild(simulatedSequenceElapsedTime, true);
                                if (!smoothSequence.isAlive)
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
                        smoothSequence.Release();
                    }

                    return;
                }
            }

            easedInterpolationFactor = Mathf.Clamp01(easedInterpolationFactor);
            var isForward = easedInterpolationFactor > prevEasedT;
            var sequenceElapsedTime = easedInterpolationFactor * cycleDuration;
            foreach (var t in smoothSequence.GetSelfChildren(isForward))
            {
                t.tween.updateSequenceChild(sequenceElapsedTime, isRestart);
                if (!smoothSequence.isAlive) return;
            }
        }

        private float CalcTFromElapsedTimeTotal(float _elapsedTimeTotal, out int cyclesDiff, out State newState)
        {
            var cyclesTotal = data.cycles;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (_elapsedTimeTotal == float.MaxValue)
            {
                var cyclesLeft = cyclesTotal - m_CyclesDone;
                cyclesDiff = cyclesLeft;
                newState = State.After;
                return 1f;
            }

            _elapsedTimeTotal -= waitDelay;
            if (_elapsedTimeTotal < 0f)
            {
                cyclesDiff = iniCyclesDone - m_CyclesDone;
                newState = State.Before;
                return 0f;
            }

            var duration = data.duration;
            if (duration == 0f)
            {
                if (cyclesTotal == -1)
                {
                    cyclesDiff = m_CyclesDone == iniCyclesDone ? 2 : 1;
                    newState = State.Running;
                    return 1f;
                }

                if (_elapsedTimeTotal == 0f)
                {
                    cyclesDiff = iniCyclesDone - m_CyclesDone;
                    newState = State.Before;
                    return 0f;
                }

                var cyclesLeft = cyclesTotal - m_CyclesDone;
                cyclesDiff = cyclesLeft;
                newState = State.After;
                return 1f;
            }

            var newCyclesDone = (int)(_elapsedTimeTotal / cycleDuration);
            if (cyclesTotal != -1 && newCyclesDone > cyclesTotal)
            {
                newCyclesDone = cyclesTotal;
            }

            cyclesDiff = newCyclesDone - m_CyclesDone;
            if (cyclesTotal != -1 && m_CyclesDone + cyclesDiff == cyclesTotal)
            {
                newState = State.After;
                return 1f;
            }

            var elapsedTimeInCycle = _elapsedTimeTotal - cycleDuration * newCyclesDone - data.startDelay;
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

        private float CalcEasedT(float t, int cyclesDone)
        {
            var cycleMode = data.cycleMode;
            var cyclesTotal = data.cycles;
            if (cyclesDone == cyclesTotal)
            {
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

            if (cycleMode == CycleMode.Restart) return Evaluate(t);
            if (cycleMode == CycleMode.Incremental) return Evaluate(t) + cyclesDone;
            var isForwardCycle = cyclesDone % 2 == 0;
            if (isForwardCycle) return Evaluate(t);
            if (cycleMode == CycleMode.Yoyo) return 1 - Evaluate(t);
            if (cycleMode == CycleMode.Rewind) return Evaluate(1 - t);
            throw new Exception();
        }

        private float Evaluate(float t)
        {
            if (data.ease == Ease.Custom)
            {
                if (data.parametricEase != ParametricEase.None)
                {
                    return Easing.Evaluate(t, this);
                }

                return data.customEase.Evaluate(t);
            }

            return StandardEasing.Evaluate(t, data.ease);
        }

        private void ReportOnValueChange(float _easedInterpolationFactor)
        {
            if (startFromCurrent)
            {
                startFromCurrent = false;
                startValue = Smooth.TryGetStartValueFromOtherShake(this) ?? getter(this);
                CacheDiff();
            }

            easedInterpolationFactor = _easedInterpolationFactor;
            onValueChange(this);
            if (m_StoppedEmergent || !isAlive) return;
            onUpdate?.Invoke(this);
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

        internal void Reset()
        {
#if UNITY_EDITOR
            debugDescription = null;
#endif
            id = -1;
            target = null;
            unityTarget = null;
            propType = PropType.None;
            data.customEase = null;
            customOnValueChange = null;
            shakeData.Reset();
            onValueChange = null;
            onComplete = null;
            onCompleteCallback = null;
            onCompleteTarget = null;
            getter = null;
            m_StoppedEmergent = false;
            waitDelay = 0f;
            coroutineEnumerator.resetEnumerator();
            smoothType = SmoothType.None;
            timeScale = 1f;
            warnIgnoredOnCompleteIfTargetDestroyed = true;
            clearOnUpdate();
        }
    }
}