using UnityEngine;

namespace SmoothTween
{
    public static partial class SmoothTweenConfig
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

        public static bool validateCustomCurves
        {
            set => Instance.validateCustomCurves = value;
        }

        internal const bool defaultUseUnscaledTimeForShakes = false;
    }
}