using SmoothTween.Runtime;
using UnityEngine;

namespace SmoothTween
{
    public static class SmoothConfig
    {
        internal static SmoothTweenManager Instance => SmoothTweenManager.Instance;

        public static Ease defaultEase
        {
            get => Instance.defaultEase;
            set
            {
                if (value == Ease.Custom || value == Ease.Default)
                {
                    Debug.LogError("defaultEase can't be Ease.Custom or Ease.Default.");
                    return;
                }

                Instance.defaultEase = value;
            }
        }

        public static bool warnTweenOnDisabledTarget
        {
            set => Instance.warnTweenOnDisabledTarget = value;
        }

        public static bool warnZeroDuration
        {
            internal get => Instance.warnZeroDuration;
            set => Instance.warnZeroDuration = value;
        }

        public static bool warnStructBoxingAllocationInCoroutine
        {
            set => Instance.warnStructBoxingAllocationInCoroutine = value;
        }

        public static bool validateCustomCurves
        {
            set => Instance.validateCustomCurves = value;
        }

        public static bool warnBenchmarkWithAsserts
        {
            set => Instance.warnBenchmarkWithAsserts = value;
        }

        internal const bool defaultUseUnscaledTimeForShakes = false;

        public static bool warnEndValueEqualsCurrent
        {
            set => Instance.warnEndValueEqualsCurrent = value;
        }
    }
}