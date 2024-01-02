using System;
using System.Collections.Generic;
using UnityEngine;

namespace SmoothTween.Runtime
{
    [AddComponentMenu("")]
    internal class SmoothTweenManager : MonoBehaviour
    {
        internal static SmoothTweenManager Instance;
        internal const int InitialCapacity = 10;

        [SerializeField] internal List<TweenContainer> m_Tween;
        [SerializeField] internal List<TweenContainer> m_FixedUpdateTween;
        internal Queue<TweenContainer> m_Pool;
        internal int tweenCount => m_Tween.Count + m_FixedUpdateTween.Count;
        internal int updateDepth;
        internal Ease defaultEase = Ease.OutQuad;
        private int m_ProcessedCount;
        internal static readonly object dummyTarget = new object();
        internal int m_LastId;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void BeforeSceneLoad()
        {
            var o = new GameObject(nameof(SmoothTweenManager));
            DontDestroyOnLoad(o);
            var instance = o.AddComponent<SmoothTweenManager>();
            instance.Initialization();
            Instance = instance;
        }

        private void Initialization()
        {
            m_Tween = new List<TweenContainer>();
            m_FixedUpdateTween = new List<TweenContainer>();
            m_Pool = new Queue<TweenContainer>();
            for (var i = 0; i < InitialCapacity; i++)
            {
                m_Pool.Enqueue(new TweenContainer());
            }
        }

        internal void FixedUpdate() => TweenUpdate(m_FixedUpdateTween, Time.fixedDeltaTime, Time.fixedUnscaledDeltaTime, out _);

        internal void Update() => TweenUpdate(m_Tween, Time.deltaTime, Time.unscaledDeltaTime, out m_ProcessedCount);

        private void TweenUpdate(List<TweenContainer> container, float deltaTime, float unscaledDeltaTime, out int processedCount)
        {
            if (updateDepth != 0) throw new Exception("updateDepth != 0");

            updateDepth++;
            var oldCount = container.Count;
            var numRemoved = 0;
            for (var i = 0; i < oldCount; i++)
            {
                var tween = container[i];
                var newIndex = i - numRemoved;
                if (tween.UpdateAndCheckIfRunning(tween.data.useUnscaledTime ? unscaledDeltaTime : deltaTime))
                {
                    if (i != newIndex)
                    {
                        container[i] = null;
                        container[newIndex] = tween;
                    }

                    continue;
                }

                ReleaseTweenToPool(tween);
                container[i] = null;
                numRemoved++;
            }

            processedCount = oldCount - numRemoved;
            updateDepth--;
            if (numRemoved == 0) return;
            var newCount = container.Count;
            for (var i = oldCount; i < newCount; i++)
            {
                var tween = container[i];
                var newIndex = i - numRemoved;
                container[newIndex] = tween;
            }

            container.RemoveRange(newCount - numRemoved, numRemoved);
        }

        internal void LateUpdate()
        {
            updateDepth++;
            var cachedCount = m_Tween.Count;
            for (var i = m_ProcessedCount; i < cachedCount; i++)
            {
                var tween = m_Tween[i];
                if (tween.isAlive
                    && !tween.startFromCurrent
                    && tween.data.startDelay == 0
                    && !tween.isAdditive
                    && tween.CanManipulate()
                    && tween.elapsedTimeTotal == 0f)
                {
                    tween.SetElapsedTimeTotal(0f);
                }
            }

            updateDepth--;
        }

        private void ReleaseTweenToPool(TweenContainer tween)
        {
            tween.Reset();
            m_Pool.Enqueue(tween);
        }

        internal static TweenContainer FetchContainer()
        {
            return Instance.FetchContainer_internal();
        }

        private TweenContainer FetchContainer_internal()
        {
            var result = m_Pool.Count == 0 ? new TweenContainer() : m_Pool.Dequeue();
            result.id = ++m_LastId;
            return result;
        }
    }
}