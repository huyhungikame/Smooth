using System;
using SmoothTween.Runtime;
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

        public SmoothData(float duration, Ease ease, Easing? customEasing, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0,
            bool useUnscaledTime = false, bool useFixedUpdate = false)
        {
            this.duration = duration;
            var curve = customEasing?.curve;
            if (ease == Ease.Custom && customEasing?.parametricEase == ParametricEase.None)
            {
                if (curve == null || !ValidateCustomCurveKeyframes(curve))
                {
                    Debug.LogError($"Ease is Ease.Custom, but {nameof(customEase)} is not configured correctly. Using Ease.Default instead.");
                    ease = Ease.Default;
                }
            }

            this.ease = ease;
            customEase = ease == Ease.Custom ? curve : null;
            this.cycles = cycles;
            this.cycleMode = cycleMode;
            this.startDelay = startDelay;
            this.endDelay = endDelay;
            this.useUnscaledTime = useUnscaledTime;
            parametricEase = customEasing?.parametricEase ?? ParametricEase.None;
            parametricEaseStrength = customEasing?.parametricEaseStrength ?? float.NaN;
            parametricEasePeriod = customEasing?.parametricEasePeriod ?? float.NaN;
            this.useFixedUpdate = useFixedUpdate;
        }

        internal void SetEasing(Easing easing)
        {
            ease = easing.ease;
            parametricEase = easing.parametricEase;
            parametricEaseStrength = easing.parametricEaseStrength;
            parametricEasePeriod = easing.parametricEasePeriod;
        }

        public SmoothData(float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false,
            bool useFixedUpdate = false)
            : this(duration, ease, null, cycles, cycleMode, startDelay, endDelay, useUnscaledTime, useFixedUpdate)
        {
        }

        public SmoothData(float duration, Easing easing, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false,
            bool useFixedUpdate = false)
            : this(duration, easing.ease, easing, cycles, cycleMode, startDelay, endDelay, useUnscaledTime, useFixedUpdate)
        {
        }

        internal static void SetCyclesTo1If0(ref int cycles)
        {
            if (cycles == 0)
            {
                cycles = 1;
            }
        }

        internal static bool ValidateCustomCurve(AnimationCurve curve)
        {
#if UNITY_ASSERTIONS && !PRIME_TWEEN_DISABLE_ASSERTIONS
            if (curve.length < 2)
            {
                Debug.LogError("Custom animation curve should have at least 2 keyframes, please edit the curve in Inspector.");
                return false;
            }

            return true;
#else
            return true;
#endif
        }

        internal static bool ValidateCustomCurveKeyframes(AnimationCurve curve)
        {
#if UNITY_ASSERTIONS && !PRIME_TWEEN_DISABLE_ASSERTIONS
            if (!ValidateCustomCurve(curve))
            {
                return false;
            }

            var instance = SmoothTweenManager.Instance;
            if (instance == null || instance.validateCustomCurves)
            {
                var error = getError();
                if (error != null)
                {
                    Debug.LogWarning($"Custom animation curve is not configured correctly which may have unexpected results: {error}.");
                }

                string getError()
                {
                    var start = curve[0];
                    if (!Mathf.Approximately(start.time, 0))
                    {
                        return "start time is not 0";
                    }

                    if (!Mathf.Approximately(start.value, 0) && !Mathf.Approximately(start.value, 1))
                    {
                        return "start value is not 0 or 1";
                    }

                    var end = curve[curve.length - 1];
                    if (!Mathf.Approximately(end.time, 1))
                    {
                        return "end time is not 1";
                    }

                    if (!Mathf.Approximately(end.value, 0) && !Mathf.Approximately(end.value, 1))
                    {
                        return "end value is not 0 or 1";
                    }

                    return null;
                }
            }

            return true;
#else
            return true;
#endif
        }
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