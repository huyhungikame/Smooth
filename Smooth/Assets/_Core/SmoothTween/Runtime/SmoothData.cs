using System;
using UnityEngine;

namespace SmoothTween
{
    [Serializable]
    public struct SmoothData
    {
        public float duration;
        public Ease ease;
        public AnimationCurve customEase;
        public bool useUnscaledTime;
        public float startDelay;
        public float endDelay;
        public int cycles;
        public bool useFixedUpdate;
        public CycleMode cycleMode;
        [NonSerialized] internal ParametricEase parametricEase;
        [NonSerialized] internal float parametricEaseStrength;
        [NonSerialized] internal float parametricEasePeriod;
    }

    public enum CycleMode
    {
        Restart,
        Yoyo,
        Incremental,
        Rewind
    }

    public enum Ease
    {
        Custom = -1,
        Default = 0,
        Linear = 1,
        InSine,
        OutSine,
        InOutSine,
        InQuad,
        OutQuad,
        InOutQuad,
        InCubic,
        OutCubic,
        InOutCubic,
        InQuart,
        OutQuart,
        InOutQuart,
        InQuint,
        OutQuint,
        InOutQuint,
        InExpo,
        OutExpo,
        InOutExpo,
        InCirc,
        OutCirc,
        InOutCirc,
        InElastic,
        OutElastic,
        InOutElastic,
        InBack,
        OutBack,
        InOutBack,
        InBounce,
        OutBounce,
        InOutBounce
    }

    internal enum ParametricEase
    {
        None = 0,
        Overshoot = 5,
        Bounce = 7,
        Elastic = 11,
        BounceExact
    }
}