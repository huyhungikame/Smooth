using System;
using PrimeTween;
using SmoothTween.Runtime;
using UnityEngine;
using UnityEngine.Assertions;

namespace SmoothTween
{
    [Serializable]
    public partial struct SmoothSequence
    {
        internal readonly Smooth root;
        public bool isAlive => root.isAlive;
        internal bool IsCreated => root.IsCreated;

        public static SmoothSequence Create(int cycles = 1, CycleMode cycleMode = CycleMode.Restart, Ease sequenceEase = Ease.Linear, bool useUnscaledTime = false, bool useFixedUpdate = false)
        {
            var tween = SmoothTweenManager.FetchContainer();
            tween.propType = PropType.Float;
            tween.smoothType = SmoothType.MainSequence;
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

            var settings = new SmoothData(0f, sequenceEase, cycles, cycleMode, 0f, 0f, useUnscaledTime, useFixedUpdate);
            tween.Setup(PrimeTweenManager.dummyTarget, ref settings, _ => { }, null, false);
            tween.intParam = emptySequenceTag;
            var root = PrimeTweenManager.addTween(tween);
            Assert.IsTrue(root.isAlive);
            return new Sequence(root);
        }

        internal void Release(Action<TweenContainer> beforeKill = null)
        {
            var enumerator = getAllTweens();
            enumerator.MoveNext();
            var current = enumerator.Current;
            Assert.IsTrue(current.isAlive);
            while (true)
            {
                // ReSharper disable once RedundantCast
                Tween? next = enumerator.MoveNext() ? enumerator.Current : (Tween?)null;
                var tween = current.tween;
                Assert.IsTrue(tween._isAlive);
                beforeKill?.Invoke(tween);
                tween.kill();
                Assert.IsFalse(tween._isAlive);
                releaseTween(tween);
                if (!next.HasValue)
                {
                    break;
                }

                current = next.Value;
            }

            Assert.IsFalse(isAlive); // not IsCreated because this may be a local variable in the user's codebase
        }

        internal SequenceDirectEnumerator GetSelfChildren(bool isForward = true) => new SequenceDirectEnumerator(this, isForward);

        internal struct SequenceDirectEnumerator
        {
            private readonly SmoothSequence sequence;
            private Smooth current;
            private readonly bool isEmpty;
            private readonly bool isForward;
            private bool isStarted;

            internal SequenceDirectEnumerator(SmoothSequence s, bool isForward)
            {
                sequence = s;
                this.isForward = isForward;
                isStarted = false;
                isEmpty = IsSequenceEmpty(s);
                if (isEmpty)
                {
                    current = default;
                    return;
                }

                current = sequence.root.tween.next;
                if (!isForward)
                {
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
            }

            private static bool IsSequenceEmpty(SmoothSequence s)
            {
                return s.root.tween.intParam == emptySequenceTag;
            }

            public
#if UNITY_2020_2_OR_NEWER
                readonly
#endif
                SequenceDirectEnumerator GetEnumerator()
            {
                Assert.IsTrue(sequence.isAlive);
                return this;
            }

            public
#if UNITY_2020_2_OR_NEWER
                readonly
#endif
                Tween Current
            {
                get
                {
                    Assert.IsTrue(sequence.isAlive);
                    Assert.IsTrue(current.IsCreated);
                    Assert.IsNotNull(current.tween);
                    Assert.AreEqual(current.id, current.tween.id);
                    Assert.IsTrue(current.tween.sequence.IsCreated);
                    return current;
                }
            }

            public bool MoveNext()
            {
                if (isEmpty)
                {
                    return false;
                }

                Assert.IsTrue(current.isAlive);
                if (!isStarted)
                {
                    isStarted = true;
                    return true;
                }

                current = isForward ? current.tween.nextSibling : current.tween.prevSibling;
                return current.IsCreated;
            }
        }
    }
}