using System;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace SmoothTween
{
    [AddComponentMenu("")]
    internal class SmoothTweenManager : MonoBehaviour
    {
        internal static SmoothTweenManager Instance;
        internal static int InitialCapacity = 10;

        [SerializeField] internal List<ReusableTween> tweens;
        [SerializeField] internal List<ReusableTween> fixedUpdateTweens;
        [NonSerialized] internal Queue<ReusableTween> pool;

        internal int lastId;
        internal Ease defaultEase = Ease.OutQuad;
        internal const Ease defaultShakeEase = Ease.OutQuad;
        internal bool validateCustomCurves = true;
        int processedCount;
        internal int updateDepth;
        internal static readonly object dummyTarget = new object();

        internal int tweensCount => tweens.Count + fixedUpdateTweens.Count;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void BeforeSceneLoad()
        {
            var go = new GameObject(nameof(SmoothTweenManager));
            DontDestroyOnLoad(go);
            var instance = go.AddComponent<SmoothTweenManager>();
            instance.Initialization();
            Instance = instance;
        }

        private void Initialization()
        {
            tweens = new List<ReusableTween>();
            fixedUpdateTweens = new List<ReusableTween>();
            pool = new Queue<ReusableTween>();
            for (var i = 0; i < InitialCapacity; i++)
            {
                pool.Enqueue(new ReusableTween());
            }
        }

        internal void FixedUpdate() => TweenUpdate(fixedUpdateTweens, Time.fixedDeltaTime, Time.fixedUnscaledDeltaTime, out _);

        internal void Update() => TweenUpdate(tweens, Time.deltaTime, Time.unscaledDeltaTime, out processedCount);

        private void TweenUpdate(List<ReusableTween> current, float deltaTime, float unscaledDeltaTime, out int processed)
        {
            if (updateDepth != 0) throw new Exception("updateDepth != 0");

            updateDepth++;
            var oldCount = current.Count;
            var numRemoved = 0;
            for (var i = 0; i < oldCount; i++)
            {
                var tween = current[i];
                var newIndex = i - numRemoved;
                if (tween.UpdateAndCheckIfRunning(tween.settings.useUnscaledTime ? unscaledDeltaTime : deltaTime))
                {
                    if (i != newIndex)
                    {
                        current[i] = null;
                        current[newIndex] = tween;
                    }

                    continue;
                }

                ReleaseTweenToPool(tween);
                current[i] = null;
                numRemoved++;
            }

            processed = oldCount - numRemoved;
            updateDepth--;
            if (numRemoved == 0)
            {
                return;
            }

            var newCount = current.Count;
            for (var i = oldCount; i < newCount; i++)
            {
                var tween = current[i];
                var newIndex = i - numRemoved;
                current[newIndex] = tween;
            }

            current.RemoveRange(newCount - numRemoved, numRemoved);
        }

        private void LateUpdate()
        {
            updateDepth++;
            var cachedCount = tweens.Count;
            for (var i = processedCount; i < cachedCount; i++)
            {
                var tween = tweens[i];
                if (tween._isAlive
                    && !tween.startFromCurrent
                    && tween.settings.startDelay == 0
                    && !tween.isAdditive
                    && tween.canManipulate()
                    && tween.elapsedTimeTotal == 0f)
                {
                    tween.SetElapsedTimeTotal(0f);
                }
            }

            updateDepth--;
        }

        private void ReleaseTweenToPool(ReusableTween tween)
        {
            tween.Reset();
            pool.Enqueue(tween);
        }

        internal static Tween CreateEmpty()
        {
            var result = DelayWithoutDurationCheck(dummyTarget, 0, false);
            if (result == null) throw new Exception("CreateEmpty");
            return result.Value;
        }

        internal static Tween? DelayWithoutDurationCheck(object target, float duration, bool useUnscaledTime)
        {
            var tween = FetchTween();
            tween.propType = PropType.Float;
            tween.tweenType = TweenType.Delay;
            var settings = new TweenSettings
            {
                duration = duration,
                ease = Ease.Linear,
                useUnscaledTime = useUnscaledTime
            };
            tween.Setup(target, ref settings, _ => { }, null, false);
            var result = AddTween(tween);
            return result.IsCreated ? result : null;
        }

        internal static ReusableTween FetchTween()
        {
            return Instance.FetchTween_Internal();
        }

        private ReusableTween FetchTween_Internal()
        {
            var result = pool.Count == 0 ? new ReusableTween() : pool.Dequeue();
            result.id = ++lastId;
            return result;
        }

        internal static Tween Animate(ReusableTween tween)
        {
            return AddTween(tween);
        }

        internal static Tween AddTween(ReusableTween tween)
        {
            return Instance.AddTween_Internal(tween);
        }

        private Tween AddTween_Internal(ReusableTween tween)
        {
            if (tween.target == null)
            {
                Debug.LogError("Target is Null");
                tween.kill();
                ReleaseTweenToPool(tween);
                return default;
            }

            if (tween.settings.useFixedUpdate)
            {
                fixedUpdateTweens.Add(tween);
            }
            else
            {
                tweens.Add(tween);
            }

            return new Tween(tween);
        }

        internal static int ProcessAll(object onTarget, Predicate<ReusableTween> predicate)
        {
            return Instance.ProcessAll_Internal(onTarget, predicate);
        }

        private int ProcessAll_Internal(object onTarget, Predicate<ReusableTween> predicate)
        {
            return processInList(tweens) + processInList(fixedUpdateTweens);

            int processInList(IReadOnlyList<ReusableTween> current)
            {
                var numProcessed = 0;
                var totalCount = 0;
                var count = current.Count;
                for (var i = 0; i < count; i++)
                {
                    var tween = current[i];
                    if (tween == null)
                    {
                        continue;
                    }

                    totalCount++;
                    if (onTarget != null)
                    {
                        if (tween.target != onTarget)
                        {
                            continue;
                        }

                        if (tween.IsInSequence())
                        {
                            continue;
                        }
                    }

                    if (tween._isAlive && predicate(tween))
                    {
                        numProcessed++;
                    }
                }

                return onTarget == null ? totalCount : numProcessed;
            }
        }
    }
}