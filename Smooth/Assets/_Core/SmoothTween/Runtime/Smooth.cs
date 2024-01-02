using System;
using SmoothTween.Runtime;
using UnityEngine;

namespace SmoothTween
{
    [Serializable]
    public partial struct Smooth
    {
        internal readonly TweenContainer container;
        internal readonly int id;
        internal bool IsCreated => id != 0;
        public bool isAlive => id != 0 && container.id == id && container.isAlive;

        internal Smooth(TweenContainer container)
        {
            id = container.id;
            this.container = container;
        }

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
                return result < 0f ? 0f : result;
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

        public int cyclesTotal => ValidateIsAlive() ? container.data.cycles : 0;

        public int cyclesDone => ValidateIsAlive() ? container.GetCyclesDone() : 0;

        public float duration
        {
            get
            {
                if (!ValidateIsAlive())
                {
                    return 0;
                }

                return container.cycleDuration;
            }
        }

        public override string ToString() => isAlive ? container.GetDescription() : $"DEAD / id {id}";

        public float elapsedTimeTotal
        {
            get => ValidateIsAlive() ? container.GetElapsedTimeTotal() : 0;
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

            container.SetElapsedTimeTotal(value);
            if (isAlive && value > durationTotal)
            {
                container.elapsedTimeTotal = durationTotal;
            }
        }

        public float durationTotal => ValidateIsAlive() ? container.GetDurationTotal() : 0;

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
                if (value == 1f)
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
                if (value == 1f)
                {
                    SetElapsedTimeTotal(float.MaxValue);
                    return;
                }

                SetElapsedTimeTotal(value * durationTotal);
            }
        }

        public float interpolationFactor => ValidateIsAlive() ? Mathf.Max(0f, container.easedInterpolationFactor) : 0f;

        public bool isPaused
        {
            get => TryManipulate() && container.isPaused;
            set
            {
                if (!TryManipulate() || !container.TrySetPause(value)) return;
                if (value || cyclesDone != cyclesTotal) return;
                if (container.IsMainSequenceRoot())
                {
                    container.smoothSequence.Release();
                    return;
                }

                container.Kill();
            }
        }

        public void Stop()
        {
            if (isAlive && TryManipulate())
            {
                container.Kill();
            }
        }

        public void Complete()
        {
            if (isAlive && TryManipulate())
            {
                container.ForceComplete();
            }
        }

        internal bool TryManipulate()
        {
            return ValidateIsAlive() && container.CanManipulate();
        }

        public void SetRemainingCycles(bool stopAtEndValue)
        {
            if (!TryManipulate())
            {
                return;
            }

            if (container.data.cycleMode == CycleMode.Restart || container.data.cycleMode == CycleMode.Incremental)
            {
                Debug.LogWarning(nameof(SetRemainingCycles) + "(bool " + nameof(stopAtEndValue) +
                                 ") is meant to be used with CycleMode.Yoyo or Rewind. Please consider using the overload that accepts int instead.");
            }

            SetRemainingCycles(container.GetCyclesDone() % 2 == 0 == stopAtEndValue ? 1 : 2);
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

            if (container.timeScale < 0f)
            {
                Debug.LogError(nameof(SetRemainingCycles) + "() doesn't work with negative " + nameof(tween.timeScale));
            }

            if (container.smoothType == SmoothType.Delay && container.HasOnComplete())
            {
                Debug.LogError("Applying cycles to Delay will not repeat the OnComplete() callback, but instead will increase the Delay duration.\n" +
                               "OnComplete() is called only once when ALL tween cycles complete. To repeat the OnComplete() callback, please use the Sequence.Create(cycles: numCycles) and put the tween inside a Sequence.\n" +
                               "More info: https://forum.unity.com/threads/1479609/page-3#post-9415922\n");
            }

            if (cycles == -1)
            {
                container.data.cycles = -1;
            }
            else
            {
                SmoothData.SetCyclesTo1If0(ref cycles);
                container.data.cycles = container.GetCyclesDone() + cycles;
            }
        }

        public Smooth OnComplete<T>(T target, Action<T> onComplete) where T : class
        {
            if (ValidateIsAlive())
            {
                container.OnComplete(target, onComplete);
            }

            return this;
        }

        public SmoothSequence Group(Smooth _tween) => TryManipulate() ? SmoothSequence.Create(this).Group(_tween) : default;
        public SmoothSequence Chain(Smooth _tween) => TryManipulate() ? SmoothSequence.Create(this).Chain(_tween) : default;
        public SmoothSequence Group(SmoothSequence sequence) => TryManipulate() ? SmoothSequence.Create(this).Group(sequence) : default;
        public SmoothSequence Chain(SmoothSequence sequence) => TryManipulate() ? SmoothSequence.Create(this).Chain(sequence) : default;

        private bool ValidateIsAlive()
        {
            if (!IsCreated)
            {
                Debug.LogError("Not Create");
            }
            else if (!isAlive)
            {
                Debug.LogError("Is Dead");
            }

            return isAlive;
        }

        /// <summary>Custom timeScale. To smoothly animate timeScale over time, use <see cref="Tween.TweenTimeScale"/> method.</summary>
        public float timeScale
        {
            get => TryManipulate() ? tween.timeScale : 1;
            set
            {
                if (TryManipulate())
                {
                    Assert.IsFalse(float.IsNaN(value));
                    Assert.IsFalse(float.IsInfinity(value));
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

        internal float durationWithWaitDelay => tween.calcDurationWithWaitDependencies();
    }
}