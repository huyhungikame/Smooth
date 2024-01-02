using System;
using UnityEngine;

namespace SmoothTween
{
    /// <summary>An ordered group of tweens and callbacks. Tweens in a sequence can run in parallel to one another with <see cref="Group"/> and sequentially with <see cref="Chain"/>.<br/>
    /// To make tweens in a Sequence overlap each other, use <see cref="TweenSettings.startDelay"/> and <see cref="TweenSettings.endDelay"/>.</summary>
    /// <example><code>
    /// Sequence.Create()
    ///     .Group(Tween.PositionX(transform, endValue: 10f, duration: 1.5f))
    ///     .Group(Tween.Scale(transform, endValue: 2f, duration: 0.5f)) // position and localScale tweens will run in parallel because they are 'grouped'
    ///     .Chain(Tween.Rotation(transform, endValue: new Vector3(0f, 0f, 45f), duration: 1f)) // rotation tween is 'chained' so it will start when both previous tweens are finished (after 1.5 seconds) 
    ///     .ChainCallback(() =&gt; Debug.Log("Sequence completed"));
    /// </code></example>
    public partial struct Sequence
    {
        private const int emptySequenceTag = -43;
        internal Tween root;
        internal bool IsCreated => root.IsCreated;

        public bool isAlive => root.isAlive;

        public float elapsedTime
        {
            get => root.elapsedTime;
            set => root.elapsedTime = value;
        }

        public int cyclesTotal => root.cyclesTotal;

        public int cyclesDone => root.cyclesDone;

        public float duration
        {
            get => root.duration;
            private set
            {
                var rootTween = root.tween;
                rootTween.settings.duration = value;
                rootTween.cycleDuration = value;
            }
        }

        public float elapsedTimeTotal
        {
            get => root.elapsedTimeTotal;
            set => root.elapsedTimeTotal = value;
        }

        public float durationTotal => root.durationTotal;

        public float progress
        {
            get => root.progress;
            set => root.progress = value;
        }

        public float progressTotal
        {
            get => root.progressTotal;
            set => root.progressTotal = value;
        }

        private bool TryManipulate() => root.TryManipulate();

        private bool ValidateCanAddChildren()
        {
            return root.elapsedTimeTotal == 0f;
        }

        public static Sequence Create(int cycles = 1, CycleMode cycleMode = CycleMode.Restart, Ease sequenceEase = Ease.Linear, bool useUnscaledTime = false, bool useFixedUpdate = false)
        {
            var tween = SmoothTweenManager.FetchTween();
            tween.propType = PropType.Float;
            tween.tweenType = TweenType.MainSequence;
            if (cycleMode == CycleMode.Incremental)
            {
                Debug.LogError(
                    $"Sequence doesn't support CycleMode.Incremental. Parameter {nameof(sequenceEase)} is applied to the sequence's 'timeline', and incrementing the 'timeline' doesn't make sense. For the same reason, {nameof(sequenceEase)} is clamped to [0:1] range.");
                cycleMode = CycleMode.Restart;
            }

            if (sequenceEase == Ease.Custom)
            {
                Debug.LogError("Sequence doesn't support Ease.Custom.");
                sequenceEase = Ease.Linear;
            }

            if (sequenceEase == Ease.Default)
            {
                sequenceEase = Ease.Linear;
            }

            var settings = new TweenSettings(0f, sequenceEase, cycles, cycleMode, 0f, 0f, useUnscaledTime, useFixedUpdate);
            tween.Setup(SmoothTweenManager.dummyTarget, ref settings, _ => { }, null, false);
            tween.intParam = emptySequenceTag;
            var root = SmoothTweenManager.AddTween(tween);
            return new Sequence(root);
        }

        public static Sequence Create(Tween firstTween)
        {
            return Create().Group(firstTween);
        }

        private Sequence(Tween rootTween)
        {
            root = rootTween;
            SetSequence(rootTween);
        }

        public Sequence Group(Tween tween)
        {
            if (!TryManipulate() || !ValidateCanAddChildren())
            {
                return this;
            }

            Validate(tween);
            ValidateChildSettings(tween);
            tween.tween.waitDelay = GetLastInSelfOrRoot().tween.waitDelay;
            AddLinkedReference(tween);
            SetSequence(tween);
            duration = Mathf.Max(duration, tween.durationTotal);
            return this;
        }

        private void AddLinkedReference(Tween tween)
        {
            Tween last;
            if (root.tween.next.IsCreated)
            {
                last = GetLast();
                var lastInSelf = GetLastInSelfOrRoot();
                lastInSelf.tween.nextSibling = tween;
                tween.tween.prevSibling = lastInSelf;
            }
            else
            {
                last = root;
            }

            last.tween.next = tween;
            tween.tween.prev = last;
            root.tween.intParam = 0;
        }

        private Tween GetLast()
        {
            Tween result = default;
            foreach (var current in GetAllTweens())
            {
                result = current;
            }

            return result;
        }

        public Sequence Chain(Tween tween)
        {
            return !TryManipulate() ? this : Chain(tween, duration);
        }

        private Sequence Chain(Tween other, float waitDelay)
        {
            Validate(other);
            ValidateChildSettings(other);
            if (!ValidateCanAddChildren())
            {
                return this;
            }

            other.tween.waitDelay = waitDelay;
            AddLinkedReference(other);
            SetSequence(other);
            duration += other.durationTotal;
            return this;
        }

        public Sequence ChainCallback<T>(T target, Action<T> callback) where T : class
        {
            if (!TryManipulate())
            {
                return this;
            }

            var maybeDelay = SmoothTweenManager.DelayWithoutDurationCheck(target, 0, false);
            if (!maybeDelay.HasValue)
            {
                return this;
            }

            var delay = maybeDelay.Value;
            delay.tween.OnComplete(target, callback);
            return Chain(delay);
        }

        public Sequence ChainDelay(float _duration, bool useUnscaledTime = false)
        {
            return Chain(Tween.Delay<object>(null, _duration, null, useUnscaledTime));
        }

        private Tween GetLastInSelfOrRoot()
        {
            var result = root;
            foreach (var current in GetSelfChildren())
            {
                result = current;
            }

            return result;
        }


        private void SetSequence(Tween handle)
        {
            var tween = handle.tween;
            tween.sequence = this;
        }

        private static void ValidateChildSettings(Tween child)
        {
            if (child.tween.isPaused)
            {
                warnIgnoredChildrenSetting(nameof(isPaused));
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (child.tween.timeScale != 1f)
            {
                warnIgnoredChildrenSetting(nameof(timeScale));
            }

            if (child.tween.settings.useUnscaledTime)
            {
                warnIgnoredChildrenSetting(nameof(TweenSettings.useUnscaledTime));
            }

            if (child.tween.settings.useFixedUpdate)
            {
                warnIgnoredChildrenSetting(nameof(TweenSettings.useFixedUpdate));
            }

            return;

            void warnIgnoredChildrenSetting(string settingName)
            {
                Debug.LogError(
                    $"'{settingName}' was ignored after adding tween/sequence to the Sequence. Parent Sequence controls isPaused/timeScale/useUnscaledTime/useFixedUpdate of all its children tweens and sequences.\n");
            }
        }

        private static void Validate(Tween other)
        {
            if (other.tween.sequence.IsCreated)
            {
                throw new Exception($"A tween can be added to a sequence only once and can only belong to one sequence. Tween: {other.tween.GetDescription()}");
            }
        }

        public void Stop()
        {
            if (isAlive && TryManipulate())
            {
                ReleaseTweens();
            }
        }

        public void Complete()
        {
            if (!isAlive || !TryManipulate()) return;
            SetRemainingCycles(1);
            root.isPaused = false;
            root.tween.UpdateSequence(float.MaxValue, false);
        }

        internal void EmergencyStop()
        {
            ReleaseTweens(t => t.WarnOnCompleteIgnored(false));
        }

        internal void ReleaseTweens(Action<ReusableTween> beforeKill = null)
        {
            var enumerator = GetAllTweens();
            enumerator.MoveNext();
            var current = enumerator.Current;
            while (true)
            {
                // ReSharper disable once RedundantCast
                var next = enumerator.MoveNext() ? enumerator.Current : (Tween?)null;
                var tween = current.tween;
                beforeKill?.Invoke(tween);
                tween.Kill();
                releaseTween(tween);
                if (!next.HasValue)
                {
                    break;
                }

                current = next.Value;
            }
        }

        static void releaseTween(ReusableTween tween)
        {
            tween.next = default;
            tween.prev = default;
            tween.prevSibling = default;
            tween.nextSibling = default;
            tween.sequence = default;
            if (tween.isSequenceRoot())
            {
                tween.tweenType = TweenType.None;
            }
        }

        internal SequenceChildrenEnumerator GetAllChildren()
        {
            var enumerator = GetAllTweens();
            enumerator.MoveNext();
            return enumerator;
        }

        public void SetRemainingCycles(bool stopAtEndValue)
        {
            root.SetRemainingCycles(stopAtEndValue);
        }

        public void SetRemainingCycles(int cycles)
        {
            root.SetRemainingCycles(cycles);
        }

        public bool isPaused
        {
            get => root.isPaused;
            set => root.isPaused = value;
        }

        internal SequenceDirectEnumerator GetSelfChildren(bool isForward = true) => new SequenceDirectEnumerator(this, isForward);
        internal SequenceChildrenEnumerator GetAllTweens() => new SequenceChildrenEnumerator(this);

        public override string ToString() => root.ToString();

        internal struct SequenceDirectEnumerator
        {
            private Tween current;
            private readonly bool isEmpty;
            internal readonly bool isForward;
            internal bool isStarted;

            internal SequenceDirectEnumerator(Sequence s, bool isForward)
            {
                this.isForward = isForward;
                isStarted = false;
                isEmpty = IsSequenceEmpty(s);
                if (isEmpty)
                {
                    current = default;
                    return;
                }

                current = s.root.tween.next;
                if (isForward) return;
                while (true)
                {
                    var next = current.tween.nextSibling;
                    if (!next.IsCreated)
                    {
                        break;
                    }

                    current = next;
                }
            }

            internal static bool IsSequenceEmpty(Sequence s)
            {
                return s.root.tween.intParam == emptySequenceTag;
            }

            public readonly SequenceDirectEnumerator GetEnumerator()
            {
                return this;
            }

            public readonly Tween Current => current;

            public bool MoveNext()
            {
                if (isEmpty)
                {
                    return false;
                }

                if (!isStarted)
                {
                    isStarted = true;
                    return true;
                }

                current = isForward ? current.tween.nextSibling : current.tween.prevSibling;
                return current.IsCreated;
            }
        }

        internal struct SequenceChildrenEnumerator
        {
            private readonly Sequence sequence;
            private Tween current;
            private bool isStarted;

            internal SequenceChildrenEnumerator(Sequence s)
            {
                sequence = s;
                current = default;
                isStarted = false;
            }

            public readonly SequenceChildrenEnumerator GetEnumerator()
            {
                return this;
            }

            public readonly Tween Current => current;

            public bool MoveNext()
            {
                if (!isStarted)
                {
                    current = sequence.root;
                    isStarted = true;
                    return true;
                }

                current = current.tween.next;
                return current.IsCreated;
            }
        }

        public Sequence Chain(Sequence other) => NestSequence(other, true);
        public Sequence Group(Sequence other) => NestSequence(other, false);

        private Sequence NestSequence(Sequence other, bool isChainOp)
        {
            if (!TryManipulate() || !ValidateCanAddChildren())
            {
                return this;
            }

            ref var otherTweenType = ref other.root.tween.tweenType;
            otherTweenType = TweenType.NestedSequence;

            var waitDelayShift = isChainOp ? duration : root.tween.waitDelay;
            other.root.tween.waitDelay += waitDelayShift;

            AddLinkedReference(other.root);
            if (isChainOp)
            {
                duration += other.durationTotal;
            }
            else
            {
                duration = Mathf.Max(duration, other.durationTotal);
            }

            ValidateChildSettings(other.root);
            return this;
        }

        public float timeScale
        {
            get => root.timeScale;
            set => root.timeScale = value;
        }

        public Sequence OnComplete<T>(T target, Action<T> onComplete) where T : class
        {
            root.OnComplete(target, onComplete);
            return this;
        }
    }
}