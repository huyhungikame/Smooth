using JetBrains.Annotations;
using UnityEngine;

namespace SmoothTween {
    /// Global PrimeTween configuration.
    [PublicAPI]
    public static partial class PrimeTweenConfig {
        internal static SmoothTweenManager Instance {
            get {
                #if UNITY_EDITOR
                Assert.IsFalse(Constants.noInstance, Constants.editModeWarning);
                #endif
                return SmoothTweenManager.Instance;
            }
        }

  
        public static Ease defaultEase {
            get => Instance.defaultEase;
            set {
                if (value == Ease.Custom || value == Ease.Default) {
                    Debug.LogError("defaultEase can't be Ease.Custom or Ease.Default.");
                    return;
                }
                Instance.defaultEase = value;
            }
        }
        

        


        public static bool validateCustomCurves {
            set => Instance.validateCustomCurves = value;
        }



        internal const bool defaultUseUnscaledTimeForShakes = false;


    }
}