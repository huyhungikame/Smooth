using System;
using UnityEngine;

namespace SmoothTween
{
    public readonly partial struct Tween
    {
        internal readonly int id;
        internal readonly ReusableTween tween;

        internal bool IsCreated => id != 0;

        internal Tween(ReusableTween tween)
        {
            id = tween.id;
            this.tween = tween;
        }

        public bool isAlive => id != 0 && tween.id == id && tween.isAlive;

        public float elapsedTime
        {
            get
            {
                if (!ValidateIsAlive())
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
            set => SetElapsedTime(value);
        }

        private void SetElapsedTime(float value)
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

            SetElapsedTimeTotal(value + cycleDuration * _cyclesDone);
        }

        /// The total number of cycles. Returns -1 to indicate infinite number cycles.
        public int cyclesTotal => ValidateIsAlive() ? tween.settings.cycles : 0;

        public int cyclesDone => ValidateIsAlive() ? tween.GetCyclesDone() : 0;

        /// The duration of one cycle.
        public float duration
        {
            get
            {
                if (!ValidateIsAlive())
                {
                    return 0;
                }

                var result = tween.cycleDuration;
                return result;
            }
        }


        public override string ToString() => isAlive ? tween.GetDescription() : $"DEAD / id {id}";

        public float elapsedTimeTotal
        {
            get => ValidateIsAlive() ? tween.GetElapsedTimeTotal() : 0;
            set => SetElapsedTimeTotal(value);
        }

        private void SetElapsedTimeTotal(float value)
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
            if (isAlive && value > durationTotal)
            {
                tween.elapsedTimeTotal = durationTotal;
            }
        }

        public float durationTotal => ValidateIsAlive() ? tween.GetDurationTotal() : 0;

        public float progress
        {
            get
            {
                if (!ValidateIsAlive())
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
                if (value >= 1f)
                {
                    bool isLastCycle = cyclesDone == cyclesTotal - 1;
                    if (isLastCycle)
                    {
                        SetElapsedTimeTotal(float.MaxValue);
                        return;
                    }
                }

                SetElapsedTime(value * duration);
            }
        }

        public float progressTotal
        {
            get
            {
                if (!ValidateIsAlive())
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
                if (value >= 1f)
                {
                    SetElapsedTimeTotal(float.MaxValue);
                    return;
                }

                SetElapsedTimeTotal(value * durationTotal);
            }
        }

        public float InterpolationFactor => ValidateIsAlive() ? Mathf.Max(0f, tween.easedInterpolationFactor) : 0f;

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
                            tween.sequence.ReleaseTweens();
                        }
                        else
                        {
                            tween.Kill();
                        }
                    }
                }
            }
        }

        public void Stop()
        {
            if (isAlive && TryManipulate())
            {
                tween.Kill();
            }
        }

        public void Complete()
        {
            if (isAlive && TryManipulate())
            {
                tween.ForceComplete();
            }
        }

        internal bool TryManipulate()
        {
            return ValidateIsAlive() && tween.CanManipulate();
        }

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
                TweenSettings.SetCyclesTo1If0(ref cycles);
                tween.settings.cycles = tween.GetCyclesDone() + cycles;
            }
        }


        public Tween OnComplete<T>(T target, Action<T> onComplete) where T : class
        {
            if (ValidateIsAlive())
            {
                tween.OnComplete(target, onComplete);
            }

            return this;
        }

        public Sequence Group(Tween _tween) => TryManipulate() ? Sequence.Create(this).Group(_tween) : default;
        public Sequence Chain(Tween _tween) => TryManipulate() ? Sequence.Create(this).Chain(_tween) : default;
        public Sequence Group(Sequence sequence) => TryManipulate() ? Sequence.Create(this).Group(sequence) : default;
        public Sequence Chain(Sequence sequence) => TryManipulate() ? Sequence.Create(this).Chain(sequence) : default;

        private bool ValidateIsAlive()
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
            if (ValidateIsAlive())
            {
                tween.SetOnUpdate(target, onUpdate);
            }

            return this;
        }

        internal float DurationWithWaitDelay => tween.CalcDurationWithWaitDependencies();
    }
}