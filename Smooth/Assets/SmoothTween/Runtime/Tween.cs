// ReSharper disable CompareOfFloatsByEqualityOperator

#if PRIME_TWEEN_INSPECTOR_DEBUGGING && UNITY_EDITOR
#define ENABLE_SERIALIZATION
#endif
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace SmoothTween
{
    /// <summary>The main API of the PrimeTween library.<br/><br/>
    /// Use static Tween methods to start animations (tweens).<br/>
    /// Use the returned Tween struct to control the running tween and access its properties.<br/><br/>
    /// Tweens are non-reusable. That is, when a tween completes (or is stopped manually), it becomes 'dead' (<see cref="isAlive"/> == false) and can no longer be used to control the tween or access its properties.<br/>
    /// To restart the animation from the beginning (or play in the opposite direction), simply start a new Tween. Starting tweens is very fast and doesn't allocate garbage,
    /// so you can start hundreds of tweens per seconds with no performance overhead.</summary>
    /// <example><code>
    /// var tween = Tween.LocalPositionX(transform, endValue: 1.5f, duration: 1f);
    /// // Let the tween run for some time...
    /// if (tween.isAlive) {
    ///     Debug.Log($"Animation is still running, elapsed time: {tween.elapsedTime}.");
    /// } else {
    ///     Debug.Log("Animation is already completed.");
    /// }
    /// </code></example>
#if ENABLE_SERIALIZATION
    [Serializable]
#endif
    public
#if !ENABLE_SERIALIZATION
        readonly
#endif
        partial struct Tween /*: ITween<Tween>*/
    {
        /// Uniquely identifies the tween.
        /// Can be observed from the Debug Inspector if PRIME_TWEEN_INSPECTOR_DEBUGGING is defined. Use only for debugging purposes.
        internal
#if !ENABLE_SERIALIZATION
            readonly
#endif
            int id;

        internal readonly ReusableTween tween;

        internal bool IsCreated => id != 0;

        internal Tween( ReusableTween tween)
        {
            id = tween.id;
            this.tween = tween;
        }

        /// A tween is 'alive' when it has been created and is not stopped or completed yet. Paused tween is also considered 'alive'.
        public bool isAlive => id != 0 && tween.id == id && tween.isAlive;

        /// Elapsed time of the current cycle.
        public float elapsedTime
        {
            get
            {
                if (!validateIsAlive())
                {
                    return 0;
                }

                if (cyclesDone == cyclesTotal)
                {
                    return duration;
                }

                var result = elapsedTimeTotal - duration * cyclesDone;
                if (result < 0f)
                {
                    return 0f;
                }

                return result;
            }
            set => setElapsedTime(value);
        }

        void setElapsedTime(float value)
        {
            if (!TryManipulate())
            {
                return;
            }

            if (value < 0f || float.IsNaN(value))
            {
                Debug.LogError($"Invalid elapsedTime value: {value}, tween: {ToString()}");
                return;
            }

            var cycleDuration = duration;
            if (value > cycleDuration)
            {
                value = cycleDuration;
            }

            var _cyclesDone = cyclesDone;
            if (_cyclesDone == cyclesTotal)
            {
                _cyclesDone -= 1;
            }

            setElapsedTimeTotal(value + cycleDuration * _cyclesDone);
        }

        /// The total number of cycles. Returns -1 to indicate infinite number cycles.
        public int cyclesTotal => validateIsAlive() ? tween.settings.cycles : 0;

        public int cyclesDone => validateIsAlive() ? tween.GetCyclesDone() : 0;

        /// The duration of one cycle.
        public float duration
        {
            get
            {
                if (!validateIsAlive())
                {
                    return 0;
                }

                var result = tween.cycleDuration;
                return result;
            }
        }

        
        public override string ToString() => isAlive ? tween.GetDescription() : $"DEAD / id {id}";

        /// Elapsed time of all cycles.
        public float elapsedTimeTotal
        {
            get => validateIsAlive() ? tween.GetElapsedTimeTotal() : 0;
            set => setElapsedTimeTotal(value);
        }

        void setElapsedTimeTotal(float value)
        {
            if (!TryManipulate())
            {
                return;
            }

            if (value < 0f || float.IsNaN(value) || (cyclesTotal == -1 && value >= float.MaxValue))
            {
                Debug.LogError($"Invalid elapsedTimeTotal value: {value}, tween: {ToString()}");
                return;
            }

            tween.SetElapsedTimeTotal(value);
            // SetElapsedTimeTotal may complete the tween, so isAlive check is needed
            if (isAlive && value > durationTotal)
            {
                tween.elapsedTimeTotal = durationTotal;
            }
        }

        /// <summary>The duration of all cycles. If cycles == -1, returns <see cref="float.PositiveInfinity"/>.</summary>
        public float durationTotal => validateIsAlive() ? tween.GetDurationTotal() : 0;

        /// Normalized progress of the current cycle expressed in 0..1 range.
        public float progress
        {
            get
            {
                if (!validateIsAlive())
                {
                    return 0;
                }

                if (duration == 0)
                {
                    return 0;
                }

                return Mathf.Min(elapsedTime / duration, 1f);
            }
            set
            {
                value = Mathf.Clamp01(value);
                if (value == 1f)
                {
                    bool isLastCycle = cyclesDone == cyclesTotal - 1;
                    if (isLastCycle)
                    {
                        setElapsedTimeTotal(float.MaxValue);
                        return;
                    }
                }

                setElapsedTime(value * duration);
            }
        }

        /// Normalized progress of all cycles expressed in 0..1 range.
        public float progressTotal
        {
            get
            {
                if (!validateIsAlive())
                {
                    return 0;
                }

                if (cyclesTotal == -1)
                {
                    return 0;
                }

                var _totalDuration = durationTotal;
                if (_totalDuration == 0)
                {
                    return 0;
                }

                return Mathf.Min(elapsedTimeTotal / _totalDuration, 1f);
            }
            set
            {
                if (cyclesTotal == -1)
                {
                    Debug.LogError($"It's not allowed to set progressTotal on infinite tween (cyclesTotal == -1), tween: {ToString()}.");
                    return;
                }

                value = Mathf.Clamp01(value);
                if (value == 1f)
                {
                    setElapsedTimeTotal(float.MaxValue);
                    return;
                }

                setElapsedTimeTotal(value * durationTotal);
            }
        }

        /// <summary>The current percentage of change between 'startValue' and 'endValue' values in 0..1 range.</summary>
        public float interpolationFactor => validateIsAlive() ? Mathf.Max(0f, tween.easedInterpolationFactor) : 0f;

        public bool isPaused
        {
            get => TryManipulate() && tween.isPaused;
            set
            {
                if (TryManipulate() && tween.TrySetPause(value))
                {
                    if (!value && cyclesDone == cyclesTotal)
                    {
                        if (tween.IsMainSequenceRoot())
                        {
                            tween.sequence.releaseTweens();
                        }
                        else
                        {
                            tween.Kill();
                        }
                    }
                }
            }
        }

        /// Interrupts the tween, ignoring onComplete callback. 
        public void Stop()
        {
            if (isAlive && TryManipulate())
            {
                tween.Kill();
            }
        }

        /// Immediately sets the tween to the endValue and calls onComplete.
        public void Complete()
        {
            // don't warn that tween is dead because dead tween means that it's already 'completed'
            if (isAlive && TryManipulate())
            {
                tween.ForceComplete();
            }
        }

        internal bool TryManipulate()
        {
            if (!validateIsAlive())
            {
                return false;
            }

            if (!tween.CanManipulate())
            {
                return false;
            }

            return true;
        }

        /// <summary>Stops the tween when it reaches 'startValue' or 'endValue' for the next time.<br/>
        /// For example, if you have an infinite tween (cycles == -1) with CycleMode.Yoyo/Rewind, and you wish to stop it when it reaches the 'endValue', then set <see cref="stopAtEndValue"/> to true.
        /// To stop the animation at the 'startValue', set <see cref="stopAtEndValue"/> to false.</summary>
        public void SetRemainingCycles(bool stopAtEndValue)
        {
            if (!TryManipulate())
            {
                return;
            }

            if (tween.settings.cycleMode == CycleMode.Restart || tween.settings.cycleMode == CycleMode.Incremental)
            {
                Debug.LogWarning(nameof(SetRemainingCycles) + "(bool " + nameof(stopAtEndValue) +
                                 ") is meant to be used with CycleMode.Yoyo or Rewind. Please consider using the overload that accepts int instead.");
            }

            SetRemainingCycles(tween.GetCyclesDone() % 2 == 0 == stopAtEndValue ? 1 : 2);
        }

        /// <summary>Sets the number of remaining cycles.<br/>
        /// This method modifies the <see cref="cyclesTotal"/> so that the tween will complete after the number of <see cref="cycles"/>.<br/>
        /// To set the initial number of cycles, pass the 'cycles' parameter to 'Tween.' methods instead.<br/><br/>
        /// Setting cycles to -1 will repeat the tween indefinitely.<br/></summary>
        public void SetRemainingCycles(int cycles)
        {
            if (!TryManipulate())
            {
                return;
            }

            if (tween.timeScale < 0f)
            {
                Debug.LogError(nameof(SetRemainingCycles) + "() doesn't work with negative " + nameof(tween.timeScale));
            }

            if (tween.tweenType == TweenType.Delay && tween.HasOnComplete)
            {
                Debug.LogError("Applying cycles to Delay will not repeat the OnComplete() callback, but instead will increase the Delay duration.\n" +
                               "OnComplete() is called only once when ALL tween cycles complete. To repeat the OnComplete() callback, please use the Sequence.Create(cycles: numCycles) and put the tween inside a Sequence.\n" +
                               "More info: https://forum.unity.com/threads/1479609/page-3#post-9415922\n");
            }

            if (cycles == -1)
            {
                tween.settings.cycles = -1;
            }
            else
            {
                TweenSettings.setCyclesTo1If0(ref cycles);
                tween.settings.cycles = tween.GetCyclesDone() + cycles;
            }
        }


        public Tween OnComplete<T>(T target, Action<T> onComplete) where T : class
        {
            if (validateIsAlive())
            {
                tween.OnComplete(target, onComplete);
            }

            return this;
        }

        public Sequence Group(Tween _tween) => TryManipulate() ? Sequence.Create(this).Group(_tween) : default;
        public Sequence Chain(Tween _tween) => TryManipulate() ? Sequence.Create(this).Chain(_tween) : default;
        public Sequence Group(Sequence sequence) => TryManipulate() ? Sequence.Create(this).Group(sequence) : default;
        public Sequence Chain(Sequence sequence) => TryManipulate() ? Sequence.Create(this).Chain(sequence) : default;

        bool validateIsAlive()
        {
            if (!IsCreated)
            {
                Debug.LogError("Is Create Error");
            }
            else if (!isAlive)
            {
                Debug.LogError("Is Dead");
            }

            return isAlive;
        }

        public float timeScale
        {
            get => TryManipulate() ? tween.timeScale : 1;
            set
            {
                if (TryManipulate())
                {
                    tween.timeScale = value;
                }
            }
        }

        public Tween OnUpdate<T>(T target, Action<T, Tween> onUpdate) where T : class
        {
            if (validateIsAlive())
            {
                tween.SetOnUpdate(target, onUpdate);
            }

            return this;
        }

        internal float durationWithWaitDelay => tween.CalcDurationWithWaitDependencies();
    }
}