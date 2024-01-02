using System;
using System.Collections;
using System.Linq;
using JetBrains.Annotations;

namespace SmoothTween {
    public partial struct Tween : IEnumerator {
        /// <summary>Use this method to wait for a Tween in coroutines.</summary>
        /// <example><code>
        /// IEnumerator Coroutine() {
        ///     yield return Tween.Delay(1).ToYieldInstruction();
        /// }
        /// </code></example>
        [NotNull]
        public IEnumerator ToYieldInstruction() {
            if (!isAlive || !tryManipulate()) {
                return Enumerable.Empty<object>().GetEnumerator();
            }
            var result = tween.coroutineEnumerator;
            result.SetTween(this);
            return result;
        }

        bool IEnumerator.MoveNext() {
            return isAlive;
        }

        object IEnumerator.Current {
            get {
                return null;
            }
        }

        void IEnumerator.Reset() => throw new NotSupportedException();
    }

    public partial struct Sequence : IEnumerator {
        /// <summary>Use this method to wait for a Sequence in coroutines.</summary>
        /// <example><code>
        /// IEnumerator Coroutine() {
        ///     var sequence = Sequence.Create(Tween.Delay(1)).ChainCallback(() =&gt; Debug.Log("Done!"));
        ///     yield return sequence.ToYieldInstruction();
        /// }
        /// </code></example>
        [NotNull]
        public IEnumerator ToYieldInstruction() => root.ToYieldInstruction();

        bool IEnumerator.MoveNext() {
            return isAlive;
        }

        object IEnumerator.Current {
            get {
                return null;
            }
        }

        void IEnumerator.Reset() => throw new NotSupportedException();
    }

    internal class TweenCoroutineEnumerator : IEnumerator {
        Tween tween;
        bool isRunning;

        internal void SetTween(Tween _tween) {
            tween = _tween;
            isRunning = true;
        }

        bool IEnumerator.MoveNext() {
            var result = tween.isAlive;
            if (!result) {
                resetEnumerator();
            }
            return result;
        }

        internal void resetEnumerator() {
            tween = default;
            isRunning = false;
        }

        object IEnumerator.Current {
            get {
                return null;
            }
        }

        void IEnumerator.Reset() => throw new NotSupportedException();
    }
}