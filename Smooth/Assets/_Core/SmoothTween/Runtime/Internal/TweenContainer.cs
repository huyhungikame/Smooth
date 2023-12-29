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

        [SerializeField] internal bool isPaused;
        internal bool isAlive;
        [SerializeField] internal float elapsedTimeTotal;
        internal bool startFromCurrent;
        internal bool isAdditive;

        internal SmoothType smoothType;

        internal float timeScale = 1f;

        [SerializeField] internal SmoothData data;
        [SerializeField] private int m_CyclesDone;

        internal SmoothSequence smoothSequence;

        private State m_State;

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
                var easedT = calcEasedT(t, m_CyclesDone);
                // print($"state: {state}/{newState}, cycles: {cyclesDone}/{settings.cycles} (diff: {cyclesDiff}), elapsedTimeTotal: {elapsedTimeTotal}, interpolation: {t}/{easedT}");
                m_State = newState;
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

        internal void UpdateSequence(float _elapsedTimeTotal, bool isRestart)
        {
            Assert.IsTrue(isSequenceRoot());
            float prevEasedT = easedInterpolationFactor;
            setElapsedTimeTotal(_elapsedTimeTotal, out int cyclesDiff); // update sequence root

            bool isRestartToBeginning = isRestart && cyclesDiff < 0;
            Assert.IsTrue(!isRestartToBeginning || m_CyclesDone == 0 || m_CyclesDone == iniCyclesDone);
            if (cyclesDiff != 0 && !isRestartToBeginning)
            {
                // print($"           sequence cyclesDiff: {cyclesDiff}");
                if (isRestart)
                {
                    Assert.IsTrue(cyclesDiff > 0 && m_CyclesDone == settings.cycles);
                    cyclesDiff = 1;
                }

                int cyclesDiffAbs = Mathf.Abs(cyclesDiff);
                int newCyclesDone = m_CyclesDone;
                m_CyclesDone -= cyclesDiff;
                int cyclesDelta = cyclesDiff > 0 ? 1 : -1;
                var interpolationFactor = cyclesDelta > 0 ? 1f : 0f;
                for (int i = 0; i < cyclesDiffAbs; i++)
                {
                    Assert.IsTrue(!isRestart || i == 0);
                    if (m_CyclesDone == settings.cycles || m_CyclesDone == iniCyclesDone)
                    {
                        // do nothing when moving backward from the last cycle or forward from the -1 cycle
                        m_CyclesDone += cyclesDelta;
                        continue;
                    }

                    var easedT = calcEasedT(interpolationFactor, m_CyclesDone);
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

                    m_CyclesDone += cyclesDelta;
                    var sequenceCycleMode = settings.cycleMode;
                    if (sequenceCycleMode == CycleMode.Restart && m_CyclesDone != settings.cycles && m_CyclesDone != iniCyclesDone)
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

                                Assert.IsTrue(isForwardCycle || tween.cyclesDone == tween.settings.cycles);
                                Assert.IsTrue(!isForwardCycle || tween.cyclesDone <= 0);
                                Assert.IsTrue(isForwardCycle || tween.state == State.After);
                                Assert.IsTrue(!isForwardCycle || tween.state == State.Before);
                            }

                            return true;
                        }
                    }
                }

                Assert.AreEqual(newCyclesDone, m_CyclesDone);
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

        private float CalcTFromElapsedTimeTotal(float _elapsedTimeTotal, out int cyclesDiff, out State newState)
        {
            // key timeline points: 0 | startDelay | duration | 1 | endDelay | onComplete
            var cyclesTotal = settings.cycles;
            if (_elapsedTimeTotal == float.MaxValue)
            {
                Assert.AreNotEqual(-1, cyclesTotal);
                var cyclesLeft = cyclesTotal - m_CyclesDone;
                Assert.IsTrue(cyclesLeft >= 0);
                cyclesDiff = cyclesLeft;
                newState = State.After;
                return 1f;
            }

            _elapsedTimeTotal -= waitDelay; // waitDelay is applied before calculating cycles
            if (_elapsedTimeTotal < 0f)
            {
                cyclesDiff = iniCyclesDone - m_CyclesDone;
                newState = State.Before;
                return 0f;
            }

            Assert.IsTrue(_elapsedTimeTotal >= 0f);
            Assert.AreNotEqual(float.MaxValue, _elapsedTimeTotal);
            var duration = settings.duration;
            if (duration == 0f)
            {
                if (cyclesTotal == -1)
                {
                    cyclesDiff = m_CyclesDone == iniCyclesDone ? 2 : 1;
                    newState = State.Running;
                    return 1f;
                }

                Assert.AreNotEqual(-1, cyclesTotal);
                if (_elapsedTimeTotal == 0f)
                {
                    cyclesDiff = iniCyclesDone - m_CyclesDone;
                    newState = State.Before;
                    return 0f;
                }

                var cyclesLeft = cyclesTotal - m_CyclesDone;
                Assert.IsTrue(cyclesLeft >= 0);
                cyclesDiff = cyclesLeft;
                newState = State.After;
                return 1f;
            }

            Assert.AreNotEqual(0f, cycleDuration);
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

            var elapsedTimeInCycle = _elapsedTimeTotal - cycleDuration * newCyclesDone - settings.startDelay;
            if (elapsedTimeInCycle < 0f)
            {
                newState = State.Before;
                return 0f;
            }

            Assert.IsTrue(elapsedTimeInCycle >= 0f);
            Assert.AreNotEqual(0f, duration);
            var result = elapsedTimeInCycle / duration;
            if (result > 1f)
            {
                newState = State.After;
                return 1f;
            }

            newState = State.Running;
            Assert.IsTrue(result >= 0f);
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
            data.customEase = null;
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
            smoothType = SmoothType.None;
            timeScale = 1f;
            warnIgnoredOnCompleteIfTargetDestroyed = true;
            clearOnUpdate();
        }
    }
}