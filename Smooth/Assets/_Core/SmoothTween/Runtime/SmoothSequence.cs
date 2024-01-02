using System;
using SmoothTween.Runtime;

namespace SmoothTween
{
    [Serializable]
    public partial struct SmoothSequence
    {
        internal readonly Smooth root;
        public bool isAlive => root.isAlive;
        internal bool IsCreated => root.IsCreated;

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