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

        [Serializable]
        internal struct ShakeData
        {
            float t;
            bool sign;
            Vector3 from, to;
            float symmetryFactor;
            int falloffEaseInt;
            AnimationCurve customStrengthOverTime;
            Ease easeBetweenShakes;
            bool isPunch;
            const int disabledFalloff = -42;
            internal bool isAlive => frequency != 0f;
            internal Vector3 strengthPerAxis { get; private set; }
            internal float frequency { get; private set; }
            float prevInterpolationFactor;
            int prevCyclesDone;

            internal void Setup(ShakeSettings settings)
            {
                isPunch = settings.isPunch;
                symmetryFactor = Mathf.Clamp01(1 - settings.asymmetry);
                {
                    var _strength = settings.strength;
                    if (_strength == Vector3.zero)
                    {
                        Debug.LogError("Shake's strength is (0, 0, 0).");
                    }

                    strengthPerAxis = _strength;
                }
                {
                    var _frequency = settings.frequency;
                    if (_frequency <= 0)
                    {
                        Debug.LogError($"Shake's frequency should be > 0f, but was {_frequency}.");
                        _frequency = ShakeSettings.defaultFrequency;
                    }

                    frequency = _frequency;
                }
                {
                    if (settings.enableFalloff)
                    {
                        var _falloffEase = settings.falloffEase;
                        var _customStrengthOverTime = settings.strengthOverTime;
                        if (_falloffEase == Ease.Default)
                        {
                            _falloffEase = Ease.Linear;
                        }

                        if (_falloffEase == Ease.Custom)
                        {
                            if (_customStrengthOverTime == null || !TweenSettings.ValidateCustomCurve(_customStrengthOverTime))
                            {
                                Debug.LogError($"Shake falloff is Ease.Custom, but {nameof(ShakeSettings.strengthOverTime)} is not configured correctly. Using Ease.Linear instead.");
                                _falloffEase = Ease.Linear;
                            }
                        }

                        falloffEaseInt = (int)_falloffEase;
                        customStrengthOverTime = _customStrengthOverTime;
                    }
                    else
                    {
                        falloffEaseInt = disabledFalloff;
                    }
                }
                {
                    var _easeBetweenShakes = settings.easeBetweenShakes;
                    if (_easeBetweenShakes == Ease.Custom)
                    {
                        Debug.LogError($"{nameof(ShakeSettings.easeBetweenShakes)} doesn't support Ease.Custom.");
                        _easeBetweenShakes = Ease.OutQuad;
                    }

                    if (_easeBetweenShakes == Ease.Default)
                    {
                        _easeBetweenShakes = PrimeTweenManager.defaultShakeEase;
                    }

                    easeBetweenShakes = _easeBetweenShakes;
                }
                onCycleComplete();
            }

            internal void onCycleComplete()
            {
                Assert.IsTrue(isAlive);
                resetAfterCycle();
                sign = isPunch || Random.value < 0.5f;
                to = generateShakePoint();
            }

            static int getMainAxisIndex(Vector3 strengthByAxis)
            {
                int mainAxisIndex = -1;
                float maxStrength = float.NegativeInfinity;
                for (int i = 0; i < 3; i++)
                {
                    var strength = Mathf.Abs(strengthByAxis[i]);
                    if (strength > maxStrength)
                    {
                        maxStrength = strength;
                        mainAxisIndex = i;
                    }
                }

                Assert.IsTrue(mainAxisIndex >= 0);
                return mainAxisIndex;
            }

            internal Vector3 getNextVal([NotNull] ReusableTween tween)
            {
                var interpolationFactor = tween.easedInterpolationFactor;
                Assert.IsTrue(interpolationFactor <= 1);

                int cyclesDiff = tween.getCyclesDone() - prevCyclesDone;
                prevCyclesDone = tween.getCyclesDone();
                if (interpolationFactor == 0f || (cyclesDiff > 0 && tween.getCyclesDone() != tween.settings.cycles))
                {
                    onCycleComplete();
                    prevInterpolationFactor = interpolationFactor;
                }

                var dt = (interpolationFactor - prevInterpolationFactor) * tween.settings.duration;
                prevInterpolationFactor = interpolationFactor;

                var strengthOverTime = calcStrengthOverTime(interpolationFactor);
                var frequencyFactor = Mathf.Clamp01(strengthOverTime * 3f); // handpicked formula that describes the relationship between strength and frequency

                float getIniVelFactor()
                {
                    // The initial velocity should twice as big because the first shake starts from zero (twice as short as total range).
                    var elapsedTimeInterpolating = tween.easedInterpolationFactor * tween.settings.duration;
                    var halfShakeDuration = 0.5f / tween.shakeData.frequency;
                    return elapsedTimeInterpolating < halfShakeDuration ? 2f : 1f;
                }

                t += frequency * dt * frequencyFactor * getIniVelFactor();
                if (t < 0f || t >= 1f)
                {
                    sign = !sign;
                    if (t < 0f)
                    {
                        t = 1f;
                        to = from;
                        from = generateShakePoint();
                    }
                    else
                    {
                        t = 0f;
                        from = to;
                        to = generateShakePoint();
                    }
                }

                Vector3 result = default;
                for (int i = 0; i < 3; i++)
                {
                    result[i] = Mathf.Lerp(from[i], to[i], StandardEasing.Evaluate(t, easeBetweenShakes)) * strengthOverTime;
                }

                return result;
            }

            Vector3 generateShakePoint()
            {
                var mainAxisIndex = getMainAxisIndex(strengthPerAxis);
                Vector3 result = default;
                float signFloat = sign ? 1f : -1f;
                for (int i = 0; i < 3; i++)
                {
                    var strength = strengthPerAxis[i];
                    if (isPunch)
                    {
                        result[i] = clampBySymmetryFactor(strength * signFloat, strength, symmetryFactor);
                    }
                    else
                    {
                        result[i] = i == mainAxisIndex ? calcMainAxisEndVal(signFloat, strength, symmetryFactor) : calcNonMainAxisEndVal(strength, symmetryFactor);
                    }
                }

                return result;
            }

            float calcStrengthOverTime(float interpolationFactor)
            {
                if (falloffEaseInt == disabledFalloff)
                {
                    return 1;
                }

                var falloffEase = (Ease)falloffEaseInt;
                if (falloffEase != Ease.Custom)
                {
                    return 1 - StandardEasing.Evaluate(interpolationFactor, falloffEase);
                }

                Assert.IsNotNull(customStrengthOverTime);
                return customStrengthOverTime.Evaluate(interpolationFactor);
            }

            static float calcMainAxisEndVal(float velocity, float strength, float symmetryFactor)
            {
                var result = Mathf.Sign(velocity) * strength * Random.Range(0.6f, 1f); // doesn't matter if we're using strength or its abs because velocity alternates
                return clampBySymmetryFactor(result, strength, symmetryFactor);
            }

            static float clampBySymmetryFactor(float val, float strength, float symmetryFactor)
            {
                if (strength > 0)
                {
                    return Mathf.Clamp(val, -strength * symmetryFactor, strength);
                }

                return Mathf.Clamp(val, strength, -strength * symmetryFactor);
            }

            static float calcNonMainAxisEndVal(float strength, float symmetryFactor)
            {
                if (strength > 0)
                {
                    return Random.Range(-strength * symmetryFactor, strength);
                }

                return Random.Range(strength, -strength * symmetryFactor);
            }

            internal void Reset()
            {
                resetAfterCycle();
                customStrengthOverTime = null;
                frequency = 0f;
                prevInterpolationFactor = 0f;
                prevCyclesDone = 0;
            }

            void resetAfterCycle()
            {
                t = 0f;
                from = Vector3.zero;
            }
        }
    }
}