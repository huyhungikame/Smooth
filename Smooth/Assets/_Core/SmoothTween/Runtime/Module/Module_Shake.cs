using SmoothTween.Runtime;

namespace SmoothTween
{
    public partial struct Smooth
    {
        internal static ValueContainer? TryGetStartValueFromOtherShake(TweenContainer newTween)
        {
            if (!newTween.shakeData.isAlive)
            {
                return null;
            }

            var target = newTween.target as Transform;
            if (target == null)
            {
                return null;
            }

            var manager = PrimeTweenManager.Instance;

            ValueContainer? findIn(List<ReusableTween> list)
            {
                foreach (var tween in list)
                {
                    if (tween != null && tween != newTween && tween._isAlive && ReferenceEquals(tween.unityTarget, target) && tween.tweenType == newTween.tweenType && !tween.startFromCurrent)
                    {
                        // Debug.Log($"tryGetStartValueFromOtherShake {tween.GetDescription()}, {tween.startValue}");
                        return tween.startValue;
                    }
                }

                return null;
            }

            return findIn(manager.tweens) ?? findIn(manager.fixedUpdateTweens);
        }
    }
}