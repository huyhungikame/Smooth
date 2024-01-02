
using System;

namespace SmoothTween 
{
    public partial struct Tween 
{
        public static Tween LightRange( UnityEngine.Light target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LightRange(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LightRange( UnityEngine.Light target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LightRange(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LightRange( UnityEngine.Light target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LightRange(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LightRange( UnityEngine.Light target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LightRange(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LightRange( UnityEngine.Light target, Single endValue, TweenSettings settings) => LightRange(target, new TweenSettings<float>(endValue, settings));
        public static Tween LightRange( UnityEngine.Light target, Single startValue, Single endValue, TweenSettings settings) => LightRange(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween LightRange( UnityEngine.Light target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Light;
                var val = _tween.FloatVal;
                _target.range = val;
            }, t => (t.target as UnityEngine.Light).range.ToContainer());
        }

        public static Tween LightShadowStrength( UnityEngine.Light target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LightShadowStrength(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LightShadowStrength( UnityEngine.Light target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LightShadowStrength(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LightShadowStrength( UnityEngine.Light target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LightShadowStrength(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LightShadowStrength( UnityEngine.Light target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LightShadowStrength(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LightShadowStrength( UnityEngine.Light target, Single endValue, TweenSettings settings) => LightShadowStrength(target, new TweenSettings<float>(endValue, settings));
        public static Tween LightShadowStrength( UnityEngine.Light target, Single startValue, Single endValue, TweenSettings settings) => LightShadowStrength(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween LightShadowStrength( UnityEngine.Light target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Light;
                var val = _tween.FloatVal;
                _target.shadowStrength = val;
            }, t => (t.target as UnityEngine.Light).shadowStrength.ToContainer());
        }

        public static Tween LightIntensity( UnityEngine.Light target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LightIntensity(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LightIntensity( UnityEngine.Light target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LightIntensity(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LightIntensity( UnityEngine.Light target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LightIntensity(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LightIntensity( UnityEngine.Light target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LightIntensity(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LightIntensity( UnityEngine.Light target, Single endValue, TweenSettings settings) => LightIntensity(target, new TweenSettings<float>(endValue, settings));
        public static Tween LightIntensity( UnityEngine.Light target, Single startValue, Single endValue, TweenSettings settings) => LightIntensity(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween LightIntensity( UnityEngine.Light target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Light;
                var val = _tween.FloatVal;
                _target.intensity = val;
            }, t => (t.target as UnityEngine.Light).intensity.ToContainer());
        }

        public static Tween LightColor( UnityEngine.Light target, UnityEngine.Color endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LightColor(target, new TweenSettings<UnityEngine.Color>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LightColor( UnityEngine.Light target, UnityEngine.Color endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LightColor(target, new TweenSettings<UnityEngine.Color>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LightColor( UnityEngine.Light target, UnityEngine.Color startValue, UnityEngine.Color endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LightColor(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LightColor( UnityEngine.Light target, UnityEngine.Color startValue, UnityEngine.Color endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LightColor(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LightColor( UnityEngine.Light target, UnityEngine.Color endValue, TweenSettings settings) => LightColor(target, new TweenSettings<UnityEngine.Color>(endValue, settings));
        public static Tween LightColor( UnityEngine.Light target, UnityEngine.Color startValue, UnityEngine.Color endValue, TweenSettings settings) => LightColor(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, settings));
        public static Tween LightColor( UnityEngine.Light target, TweenSettings<UnityEngine.Color> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Light;
                var val = _tween.ColorVal;
                _target.color = val;
            }, t => (t.target as UnityEngine.Light).color.ToContainer());
        }

        public static Tween CameraOrthographicSize( UnityEngine.Camera target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraOrthographicSize(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraOrthographicSize( UnityEngine.Camera target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraOrthographicSize(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraOrthographicSize( UnityEngine.Camera target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraOrthographicSize(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraOrthographicSize( UnityEngine.Camera target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraOrthographicSize(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraOrthographicSize( UnityEngine.Camera target, Single endValue, TweenSettings settings) => CameraOrthographicSize(target, new TweenSettings<float>(endValue, settings));
        public static Tween CameraOrthographicSize( UnityEngine.Camera target, Single startValue, Single endValue, TweenSettings settings) => CameraOrthographicSize(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween CameraOrthographicSize( UnityEngine.Camera target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Camera;
                var val = _tween.FloatVal;
                _target.orthographicSize = val;
            }, t => (t.target as UnityEngine.Camera).orthographicSize.ToContainer());
        }

        public static Tween CameraBackgroundColor( UnityEngine.Camera target, UnityEngine.Color endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraBackgroundColor(target, new TweenSettings<UnityEngine.Color>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraBackgroundColor( UnityEngine.Camera target, UnityEngine.Color endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraBackgroundColor(target, new TweenSettings<UnityEngine.Color>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraBackgroundColor( UnityEngine.Camera target, UnityEngine.Color startValue, UnityEngine.Color endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraBackgroundColor(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraBackgroundColor( UnityEngine.Camera target, UnityEngine.Color startValue, UnityEngine.Color endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraBackgroundColor(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraBackgroundColor( UnityEngine.Camera target, UnityEngine.Color endValue, TweenSettings settings) => CameraBackgroundColor(target, new TweenSettings<UnityEngine.Color>(endValue, settings));
        public static Tween CameraBackgroundColor( UnityEngine.Camera target, UnityEngine.Color startValue, UnityEngine.Color endValue, TweenSettings settings) => CameraBackgroundColor(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, settings));
        public static Tween CameraBackgroundColor( UnityEngine.Camera target, TweenSettings<UnityEngine.Color> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Camera;
                var val = _tween.ColorVal;
                _target.backgroundColor = val;
            }, t => (t.target as UnityEngine.Camera).backgroundColor.ToContainer());
        }

        public static Tween CameraAspect( UnityEngine.Camera target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraAspect(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraAspect( UnityEngine.Camera target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraAspect(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraAspect( UnityEngine.Camera target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraAspect(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraAspect( UnityEngine.Camera target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraAspect(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraAspect( UnityEngine.Camera target, Single endValue, TweenSettings settings) => CameraAspect(target, new TweenSettings<float>(endValue, settings));
        public static Tween CameraAspect( UnityEngine.Camera target, Single startValue, Single endValue, TweenSettings settings) => CameraAspect(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween CameraAspect( UnityEngine.Camera target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Camera;
                var val = _tween.FloatVal;
                _target.aspect = val;
            }, t => (t.target as UnityEngine.Camera).aspect.ToContainer());
        }

        public static Tween CameraFarClipPlane( UnityEngine.Camera target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraFarClipPlane(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraFarClipPlane( UnityEngine.Camera target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraFarClipPlane(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraFarClipPlane( UnityEngine.Camera target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraFarClipPlane(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraFarClipPlane( UnityEngine.Camera target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraFarClipPlane(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraFarClipPlane( UnityEngine.Camera target, Single endValue, TweenSettings settings) => CameraFarClipPlane(target, new TweenSettings<float>(endValue, settings));
        public static Tween CameraFarClipPlane( UnityEngine.Camera target, Single startValue, Single endValue, TweenSettings settings) => CameraFarClipPlane(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween CameraFarClipPlane( UnityEngine.Camera target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Camera;
                var val = _tween.FloatVal;
                _target.farClipPlane = val;
            }, t => (t.target as UnityEngine.Camera).farClipPlane.ToContainer());
        }

        public static Tween CameraFieldOfView( UnityEngine.Camera target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraFieldOfView(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraFieldOfView( UnityEngine.Camera target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraFieldOfView(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraFieldOfView( UnityEngine.Camera target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraFieldOfView(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraFieldOfView( UnityEngine.Camera target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraFieldOfView(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraFieldOfView( UnityEngine.Camera target, Single endValue, TweenSettings settings) => CameraFieldOfView(target, new TweenSettings<float>(endValue, settings));
        public static Tween CameraFieldOfView( UnityEngine.Camera target, Single startValue, Single endValue, TweenSettings settings) => CameraFieldOfView(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween CameraFieldOfView( UnityEngine.Camera target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Camera;
                var val = _tween.FloatVal;
                _target.fieldOfView = val;
            }, t => (t.target as UnityEngine.Camera).fieldOfView.ToContainer());
        }

        public static Tween CameraNearClipPlane( UnityEngine.Camera target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraNearClipPlane(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraNearClipPlane( UnityEngine.Camera target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraNearClipPlane(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraNearClipPlane( UnityEngine.Camera target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraNearClipPlane(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraNearClipPlane( UnityEngine.Camera target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraNearClipPlane(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraNearClipPlane( UnityEngine.Camera target, Single endValue, TweenSettings settings) => CameraNearClipPlane(target, new TweenSettings<float>(endValue, settings));
        public static Tween CameraNearClipPlane( UnityEngine.Camera target, Single startValue, Single endValue, TweenSettings settings) => CameraNearClipPlane(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween CameraNearClipPlane( UnityEngine.Camera target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Camera;
                var val = _tween.FloatVal;
                _target.nearClipPlane = val;
            }, t => (t.target as UnityEngine.Camera).nearClipPlane.ToContainer());
        }

        public static Tween CameraPixelRect( UnityEngine.Camera target, UnityEngine.Rect endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraPixelRect(target, new TweenSettings<UnityEngine.Rect>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraPixelRect( UnityEngine.Camera target, UnityEngine.Rect endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraPixelRect(target, new TweenSettings<UnityEngine.Rect>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraPixelRect( UnityEngine.Camera target, UnityEngine.Rect startValue, UnityEngine.Rect endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraPixelRect(target, new TweenSettings<UnityEngine.Rect>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraPixelRect( UnityEngine.Camera target, UnityEngine.Rect startValue, UnityEngine.Rect endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraPixelRect(target, new TweenSettings<UnityEngine.Rect>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraPixelRect( UnityEngine.Camera target, UnityEngine.Rect endValue, TweenSettings settings) => CameraPixelRect(target, new TweenSettings<UnityEngine.Rect>(endValue, settings));
        public static Tween CameraPixelRect( UnityEngine.Camera target, UnityEngine.Rect startValue, UnityEngine.Rect endValue, TweenSettings settings) => CameraPixelRect(target, new TweenSettings<UnityEngine.Rect>(startValue, endValue, settings));
        public static Tween CameraPixelRect( UnityEngine.Camera target, TweenSettings<UnityEngine.Rect> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Camera;
                var val = _tween.RectVal;
                _target.pixelRect = val;
            }, t => (t.target as UnityEngine.Camera).pixelRect.ToContainer());
        }

        public static Tween CameraRect( UnityEngine.Camera target, UnityEngine.Rect endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraRect(target, new TweenSettings<UnityEngine.Rect>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraRect( UnityEngine.Camera target, UnityEngine.Rect endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraRect(target, new TweenSettings<UnityEngine.Rect>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraRect( UnityEngine.Camera target, UnityEngine.Rect startValue, UnityEngine.Rect endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraRect(target, new TweenSettings<UnityEngine.Rect>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraRect( UnityEngine.Camera target, UnityEngine.Rect startValue, UnityEngine.Rect endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => CameraRect(target, new TweenSettings<UnityEngine.Rect>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween CameraRect( UnityEngine.Camera target, UnityEngine.Rect endValue, TweenSettings settings) => CameraRect(target, new TweenSettings<UnityEngine.Rect>(endValue, settings));
        public static Tween CameraRect( UnityEngine.Camera target, UnityEngine.Rect startValue, UnityEngine.Rect endValue, TweenSettings settings) => CameraRect(target, new TweenSettings<UnityEngine.Rect>(startValue, endValue, settings));
        public static Tween CameraRect( UnityEngine.Camera target, TweenSettings<UnityEngine.Rect> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Camera;
                var val = _tween.RectVal;
                _target.rect = val;
            }, t => (t.target as UnityEngine.Camera).rect.ToContainer());
        }

        public static Tween LocalRotation( UnityEngine.Transform target, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalRotation(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalRotation( UnityEngine.Transform target, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalRotation(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalRotation( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalRotation(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalRotation( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalRotation(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalRotation( UnityEngine.Transform target, UnityEngine.Vector3 endValue, TweenSettings settings) => LocalRotation(target, new TweenSettings<UnityEngine.Vector3>(endValue, settings));
        public static Tween LocalRotation( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, TweenSettings settings) => LocalRotation(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, settings));

        public static Tween Scale( UnityEngine.Transform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Scale(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Scale( UnityEngine.Transform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Scale(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Scale( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Scale(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Scale( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Scale(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Scale( UnityEngine.Transform target, Single endValue, TweenSettings settings) => Scale(target, new TweenSettings<float>(endValue, settings));
        public static Tween Scale( UnityEngine.Transform target, Single startValue, Single endValue, TweenSettings settings) => Scale(target, new TweenSettings<float>(startValue, endValue, settings));

        public static Tween Rotation( UnityEngine.Transform target, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Rotation(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Rotation( UnityEngine.Transform target, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Rotation(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Rotation( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Rotation(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Rotation( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Rotation(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Rotation( UnityEngine.Transform target, UnityEngine.Vector3 endValue, TweenSettings settings) => Rotation(target, new TweenSettings<UnityEngine.Vector3>(endValue, settings));
        public static Tween Rotation( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, TweenSettings settings) => Rotation(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, settings));

        public static Tween Position( UnityEngine.Transform target, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Position(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Position( UnityEngine.Transform target, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Position(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Position( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Position(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Position( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Position(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Position( UnityEngine.Transform target, UnityEngine.Vector3 endValue, TweenSettings settings) => Position(target, new TweenSettings<UnityEngine.Vector3>(endValue, settings));
        public static Tween Position( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, TweenSettings settings) => Position(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, settings));
        public static Tween Position( UnityEngine.Transform target, TweenSettings<UnityEngine.Vector3> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Transform;
                var val = _tween.Vector3Val;
                _target.position = val;
            }, t => (t.target as UnityEngine.Transform).position.ToContainer());
        }

        public static Tween PositionX( UnityEngine.Transform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween PositionX( UnityEngine.Transform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween PositionX( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween PositionX( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween PositionX( UnityEngine.Transform target, Single endValue, TweenSettings settings) => PositionX(target, new TweenSettings<float>(endValue, settings));
        public static Tween PositionX( UnityEngine.Transform target, Single startValue, Single endValue, TweenSettings settings) => PositionX(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween PositionX( UnityEngine.Transform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Transform;
                var val = _tween.FloatVal;
                _target.position = _target.position.WithComponent(0, val);
            }, t => (t.target as UnityEngine.Transform).position.x.ToContainer());
        }

        public static Tween PositionY( UnityEngine.Transform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween PositionY( UnityEngine.Transform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween PositionY( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween PositionY( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween PositionY( UnityEngine.Transform target, Single endValue, TweenSettings settings) => PositionY(target, new TweenSettings<float>(endValue, settings));
        public static Tween PositionY( UnityEngine.Transform target, Single startValue, Single endValue, TweenSettings settings) => PositionY(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween PositionY( UnityEngine.Transform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Transform;
                var val = _tween.FloatVal;
                _target.position = _target.position.WithComponent(1, val);
            }, t => (t.target as UnityEngine.Transform).position.y.ToContainer());
        }

        public static Tween PositionZ( UnityEngine.Transform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionZ(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween PositionZ( UnityEngine.Transform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionZ(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween PositionZ( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionZ(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween PositionZ( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionZ(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween PositionZ( UnityEngine.Transform target, Single endValue, TweenSettings settings) => PositionZ(target, new TweenSettings<float>(endValue, settings));
        public static Tween PositionZ( UnityEngine.Transform target, Single startValue, Single endValue, TweenSettings settings) => PositionZ(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween PositionZ( UnityEngine.Transform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Transform;
                var val = _tween.FloatVal;
                _target.position = _target.position.WithComponent(2, val);
            }, t => (t.target as UnityEngine.Transform).position.z.ToContainer());
        }

        public static Tween LocalPosition( UnityEngine.Transform target, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPosition(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPosition( UnityEngine.Transform target, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPosition(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPosition( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPosition(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPosition( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPosition(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPosition( UnityEngine.Transform target, UnityEngine.Vector3 endValue, TweenSettings settings) => LocalPosition(target, new TweenSettings<UnityEngine.Vector3>(endValue, settings));
        public static Tween LocalPosition( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, TweenSettings settings) => LocalPosition(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, settings));
        public static Tween LocalPosition( UnityEngine.Transform target, TweenSettings<UnityEngine.Vector3> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Transform;
                var val = _tween.Vector3Val;
                _target.localPosition = val;
            }, t => (t.target as UnityEngine.Transform).localPosition.ToContainer());
        }

        public static Tween LocalPositionX( UnityEngine.Transform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPositionX( UnityEngine.Transform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPositionX( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPositionX( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPositionX( UnityEngine.Transform target, Single endValue, TweenSettings settings) => LocalPositionX(target, new TweenSettings<float>(endValue, settings));
        public static Tween LocalPositionX( UnityEngine.Transform target, Single startValue, Single endValue, TweenSettings settings) => LocalPositionX(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween LocalPositionX( UnityEngine.Transform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Transform;
                var val = _tween.FloatVal;
                _target.localPosition = _target.localPosition.WithComponent(0, val);
            }, t => (t.target as UnityEngine.Transform).localPosition.x.ToContainer());
        }

        public static Tween LocalPositionY( UnityEngine.Transform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPositionY( UnityEngine.Transform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPositionY( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPositionY( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPositionY( UnityEngine.Transform target, Single endValue, TweenSettings settings) => LocalPositionY(target, new TweenSettings<float>(endValue, settings));
        public static Tween LocalPositionY( UnityEngine.Transform target, Single startValue, Single endValue, TweenSettings settings) => LocalPositionY(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween LocalPositionY( UnityEngine.Transform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Transform;
                var val = _tween.FloatVal;
                _target.localPosition = _target.localPosition.WithComponent(1, val);
            }, t => (t.target as UnityEngine.Transform).localPosition.y.ToContainer());
        }

        public static Tween LocalPositionZ( UnityEngine.Transform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionZ(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPositionZ( UnityEngine.Transform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionZ(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPositionZ( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionZ(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPositionZ( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionZ(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPositionZ( UnityEngine.Transform target, Single endValue, TweenSettings settings) => LocalPositionZ(target, new TweenSettings<float>(endValue, settings));
        public static Tween LocalPositionZ( UnityEngine.Transform target, Single startValue, Single endValue, TweenSettings settings) => LocalPositionZ(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween LocalPositionZ( UnityEngine.Transform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Transform;
                var val = _tween.FloatVal;
                _target.localPosition = _target.localPosition.WithComponent(2, val);
            }, t => (t.target as UnityEngine.Transform).localPosition.z.ToContainer());
        }

        public static Tween Rotation( UnityEngine.Transform target, UnityEngine.Quaternion endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Rotation(target, new TweenSettings<UnityEngine.Quaternion>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Rotation( UnityEngine.Transform target, UnityEngine.Quaternion endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Rotation(target, new TweenSettings<UnityEngine.Quaternion>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Rotation( UnityEngine.Transform target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Rotation(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Rotation( UnityEngine.Transform target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Rotation(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Rotation( UnityEngine.Transform target, UnityEngine.Quaternion endValue, TweenSettings settings) => Rotation(target, new TweenSettings<UnityEngine.Quaternion>(endValue, settings));
        public static Tween Rotation( UnityEngine.Transform target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, TweenSettings settings) => Rotation(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, settings));
        public static Tween Rotation( UnityEngine.Transform target, TweenSettings<UnityEngine.Quaternion> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Transform;
                var val = _tween.QuaternionVal;
                _target.rotation = val;
            }, t => (t.target as UnityEngine.Transform).rotation.ToContainer());
        }

        public static Tween LocalRotation( UnityEngine.Transform target, UnityEngine.Quaternion endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalRotation(target, new TweenSettings<UnityEngine.Quaternion>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalRotation( UnityEngine.Transform target, UnityEngine.Quaternion endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalRotation(target, new TweenSettings<UnityEngine.Quaternion>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalRotation( UnityEngine.Transform target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalRotation(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalRotation( UnityEngine.Transform target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalRotation(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalRotation( UnityEngine.Transform target, UnityEngine.Quaternion endValue, TweenSettings settings) => LocalRotation(target, new TweenSettings<UnityEngine.Quaternion>(endValue, settings));
        public static Tween LocalRotation( UnityEngine.Transform target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, TweenSettings settings) => LocalRotation(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, settings));
        public static Tween LocalRotation( UnityEngine.Transform target, TweenSettings<UnityEngine.Quaternion> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Transform;
                var val = _tween.QuaternionVal;
                _target.localRotation = val;
            }, t => (t.target as UnityEngine.Transform).localRotation.ToContainer());
        }

        public static Tween Scale( UnityEngine.Transform target, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Scale(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Scale( UnityEngine.Transform target, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Scale(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Scale( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Scale(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Scale( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Scale(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Scale( UnityEngine.Transform target, UnityEngine.Vector3 endValue, TweenSettings settings) => Scale(target, new TweenSettings<UnityEngine.Vector3>(endValue, settings));
        public static Tween Scale( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, TweenSettings settings) => Scale(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, settings));
        public static Tween Scale( UnityEngine.Transform target, TweenSettings<UnityEngine.Vector3> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Transform;
                var val = _tween.Vector3Val;
                _target.localScale = val;
            }, t => (t.target as UnityEngine.Transform).localScale.ToContainer());
        }

        public static Tween ScaleX( UnityEngine.Transform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => ScaleX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween ScaleX( UnityEngine.Transform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => ScaleX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween ScaleX( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => ScaleX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween ScaleX( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => ScaleX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween ScaleX( UnityEngine.Transform target, Single endValue, TweenSettings settings) => ScaleX(target, new TweenSettings<float>(endValue, settings));
        public static Tween ScaleX( UnityEngine.Transform target, Single startValue, Single endValue, TweenSettings settings) => ScaleX(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween ScaleX( UnityEngine.Transform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Transform;
                var val = _tween.FloatVal;
                _target.localScale = _target.localScale.WithComponent(0, val);
            }, t => (t.target as UnityEngine.Transform).localScale.x.ToContainer());
        }

        public static Tween ScaleY( UnityEngine.Transform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => ScaleY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween ScaleY( UnityEngine.Transform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => ScaleY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween ScaleY( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => ScaleY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween ScaleY( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => ScaleY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween ScaleY( UnityEngine.Transform target, Single endValue, TweenSettings settings) => ScaleY(target, new TweenSettings<float>(endValue, settings));
        public static Tween ScaleY( UnityEngine.Transform target, Single startValue, Single endValue, TweenSettings settings) => ScaleY(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween ScaleY( UnityEngine.Transform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Transform;
                var val = _tween.FloatVal;
                _target.localScale = _target.localScale.WithComponent(1, val);
            }, t => (t.target as UnityEngine.Transform).localScale.y.ToContainer());
        }

        public static Tween ScaleZ( UnityEngine.Transform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => ScaleZ(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween ScaleZ( UnityEngine.Transform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => ScaleZ(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween ScaleZ( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => ScaleZ(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween ScaleZ( UnityEngine.Transform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => ScaleZ(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween ScaleZ( UnityEngine.Transform target, Single endValue, TweenSettings settings) => ScaleZ(target, new TweenSettings<float>(endValue, settings));
        public static Tween ScaleZ( UnityEngine.Transform target, Single startValue, Single endValue, TweenSettings settings) => ScaleZ(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween ScaleZ( UnityEngine.Transform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Transform;
                var val = _tween.FloatVal;
                _target.localScale = _target.localScale.WithComponent(2, val);
            }, t => (t.target as UnityEngine.Transform).localScale.z.ToContainer());
        }

        public static Tween Color( UnityEngine.SpriteRenderer target, UnityEngine.Color endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Color(target, new TweenSettings<UnityEngine.Color>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Color( UnityEngine.SpriteRenderer target, UnityEngine.Color endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Color(target, new TweenSettings<UnityEngine.Color>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Color( UnityEngine.SpriteRenderer target, UnityEngine.Color startValue, UnityEngine.Color endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Color(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Color( UnityEngine.SpriteRenderer target, UnityEngine.Color startValue, UnityEngine.Color endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Color(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Color( UnityEngine.SpriteRenderer target, UnityEngine.Color endValue, TweenSettings settings) => Color(target, new TweenSettings<UnityEngine.Color>(endValue, settings));
        public static Tween Color( UnityEngine.SpriteRenderer target, UnityEngine.Color startValue, UnityEngine.Color endValue, TweenSettings settings) => Color(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, settings));
        public static Tween Color( UnityEngine.SpriteRenderer target, TweenSettings<UnityEngine.Color> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.SpriteRenderer;
                var val = _tween.ColorVal;
                _target.color = val;
            }, t => (t.target as UnityEngine.SpriteRenderer).color.ToContainer());
        }

        public static Tween Alpha( UnityEngine.SpriteRenderer target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Alpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Alpha( UnityEngine.SpriteRenderer target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Alpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Alpha( UnityEngine.SpriteRenderer target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Alpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Alpha( UnityEngine.SpriteRenderer target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Alpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Alpha( UnityEngine.SpriteRenderer target, Single endValue, TweenSettings settings) => Alpha(target, new TweenSettings<float>(endValue, settings));
        public static Tween Alpha( UnityEngine.SpriteRenderer target, Single startValue, Single endValue, TweenSettings settings) => Alpha(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween Alpha( UnityEngine.SpriteRenderer target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.SpriteRenderer;
                var val = _tween.FloatVal;
                _target.color = _target.color.WithAlpha(val);
            }, t => (t.target as UnityEngine.SpriteRenderer).color.a.ToContainer());
        }

        public static Tween TweenTimeScale( SmoothTween.Tween target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => TweenTimeScale(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween TweenTimeScale( SmoothTween.Tween target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => TweenTimeScale(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween TweenTimeScale( SmoothTween.Tween target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => TweenTimeScale(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween TweenTimeScale( SmoothTween.Tween target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => TweenTimeScale(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween TweenTimeScale( SmoothTween.Tween target, Single endValue, TweenSettings settings) => TweenTimeScale(target, new TweenSettings<float>(endValue, settings));
        public static Tween TweenTimeScale( SmoothTween.Tween target, Single startValue, Single endValue, TweenSettings settings) => TweenTimeScale(target, new TweenSettings<float>(startValue, endValue, settings));

        public static Tween TweenTimeScale( SmoothTween.Sequence target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => TweenTimeScale(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween TweenTimeScale( SmoothTween.Sequence target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => TweenTimeScale(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween TweenTimeScale( SmoothTween.Sequence target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => TweenTimeScale(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween TweenTimeScale( SmoothTween.Sequence target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => TweenTimeScale(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween TweenTimeScale( SmoothTween.Sequence target, Single endValue, TweenSettings settings) => TweenTimeScale(target, new TweenSettings<float>(endValue, settings));
        public static Tween TweenTimeScale( SmoothTween.Sequence target, Single startValue, Single endValue, TweenSettings settings) => TweenTimeScale(target, new TweenSettings<float>(startValue, endValue, settings));

        #if !UNITY_2019_1_OR_NEWER || UNITY_UGUI_INSTALLED
        public static Tween UISliderValue( UnityEngine.UI.Slider target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UISliderValue(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UISliderValue( UnityEngine.UI.Slider target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UISliderValue(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UISliderValue( UnityEngine.UI.Slider target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UISliderValue(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UISliderValue( UnityEngine.UI.Slider target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UISliderValue(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UISliderValue( UnityEngine.UI.Slider target, Single endValue, TweenSettings settings) => UISliderValue(target, new TweenSettings<float>(endValue, settings));
        public static Tween UISliderValue( UnityEngine.UI.Slider target, Single startValue, Single endValue, TweenSettings settings) => UISliderValue(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UISliderValue( UnityEngine.UI.Slider target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.Slider;
                var val = _tween.FloatVal;
                _target.value = val;
            }, t => (t.target as UnityEngine.UI.Slider).value.ToContainer());
        }

        public static Tween UINormalizedPosition( UnityEngine.UI.ScrollRect target, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UINormalizedPosition(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UINormalizedPosition( UnityEngine.UI.ScrollRect target, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UINormalizedPosition(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UINormalizedPosition( UnityEngine.UI.ScrollRect target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UINormalizedPosition(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UINormalizedPosition( UnityEngine.UI.ScrollRect target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UINormalizedPosition(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UINormalizedPosition( UnityEngine.UI.ScrollRect target, UnityEngine.Vector2 endValue, TweenSettings settings) => UINormalizedPosition(target, new TweenSettings<UnityEngine.Vector2>(endValue, settings));
        public static Tween UINormalizedPosition( UnityEngine.UI.ScrollRect target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings) => UINormalizedPosition(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings));
        public static Tween UINormalizedPosition( UnityEngine.UI.ScrollRect target, TweenSettings<UnityEngine.Vector2> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.ScrollRect;
                var val = _tween.Vector2Val;
                _target.SetNormalizedPosition(val);
            }, t => (t.target as UnityEngine.UI.ScrollRect).GetNormalizedPosition().ToContainer());
        }

        public static Tween UIHorizontalNormalizedPosition( UnityEngine.UI.ScrollRect target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIHorizontalNormalizedPosition(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIHorizontalNormalizedPosition( UnityEngine.UI.ScrollRect target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIHorizontalNormalizedPosition(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIHorizontalNormalizedPosition( UnityEngine.UI.ScrollRect target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIHorizontalNormalizedPosition(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIHorizontalNormalizedPosition( UnityEngine.UI.ScrollRect target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIHorizontalNormalizedPosition(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIHorizontalNormalizedPosition( UnityEngine.UI.ScrollRect target, Single endValue, TweenSettings settings) => UIHorizontalNormalizedPosition(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIHorizontalNormalizedPosition( UnityEngine.UI.ScrollRect target, Single startValue, Single endValue, TweenSettings settings) => UIHorizontalNormalizedPosition(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIHorizontalNormalizedPosition( UnityEngine.UI.ScrollRect target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.ScrollRect;
                var val = _tween.FloatVal;
                _target.horizontalNormalizedPosition = val;
            }, t => (t.target as UnityEngine.UI.ScrollRect).horizontalNormalizedPosition.ToContainer());
        }

        public static Tween UIVerticalNormalizedPosition( UnityEngine.UI.ScrollRect target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIVerticalNormalizedPosition(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIVerticalNormalizedPosition( UnityEngine.UI.ScrollRect target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIVerticalNormalizedPosition(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIVerticalNormalizedPosition( UnityEngine.UI.ScrollRect target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIVerticalNormalizedPosition(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIVerticalNormalizedPosition( UnityEngine.UI.ScrollRect target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIVerticalNormalizedPosition(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIVerticalNormalizedPosition( UnityEngine.UI.ScrollRect target, Single endValue, TweenSettings settings) => UIVerticalNormalizedPosition(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIVerticalNormalizedPosition( UnityEngine.UI.ScrollRect target, Single startValue, Single endValue, TweenSettings settings) => UIVerticalNormalizedPosition(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIVerticalNormalizedPosition( UnityEngine.UI.ScrollRect target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.ScrollRect;
                var val = _tween.FloatVal;
                _target.verticalNormalizedPosition = val;
            }, t => (t.target as UnityEngine.UI.ScrollRect).verticalNormalizedPosition.ToContainer());
        }

        public static Tween UIPivotX( UnityEngine.RectTransform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPivotX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPivotX( UnityEngine.RectTransform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPivotX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPivotX( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPivotX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPivotX( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPivotX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPivotX( UnityEngine.RectTransform target, Single endValue, TweenSettings settings) => UIPivotX(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIPivotX( UnityEngine.RectTransform target, Single startValue, Single endValue, TweenSettings settings) => UIPivotX(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIPivotX( UnityEngine.RectTransform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.FloatVal;
                _target.pivot = _target.pivot.WithComponent(0, val);
            }, t => (t.target as UnityEngine.RectTransform).pivot[0].ToContainer());
        }

        public static Tween UIPivotY( UnityEngine.RectTransform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPivotY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPivotY( UnityEngine.RectTransform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPivotY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPivotY( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPivotY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPivotY( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPivotY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPivotY( UnityEngine.RectTransform target, Single endValue, TweenSettings settings) => UIPivotY(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIPivotY( UnityEngine.RectTransform target, Single startValue, Single endValue, TweenSettings settings) => UIPivotY(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIPivotY( UnityEngine.RectTransform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.FloatVal;
                _target.pivot = _target.pivot.WithComponent(1, val);
            }, t => (t.target as UnityEngine.RectTransform).pivot[1].ToContainer());
        }

        public static Tween UIPivot( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPivot(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPivot( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPivot(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPivot( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPivot(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPivot( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPivot(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPivot( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, TweenSettings settings) => UIPivot(target, new TweenSettings<UnityEngine.Vector2>(endValue, settings));
        public static Tween UIPivot( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings) => UIPivot(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings));
        public static Tween UIPivot( UnityEngine.RectTransform target, TweenSettings<UnityEngine.Vector2> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.Vector2Val;
                _target.pivot = val;
            }, t => (t.target as UnityEngine.RectTransform).pivot.ToContainer());
        }

        public static Tween UIAnchorMax( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchorMax(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchorMax( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchorMax(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchorMax( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchorMax(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchorMax( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchorMax(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchorMax( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, TweenSettings settings) => UIAnchorMax(target, new TweenSettings<UnityEngine.Vector2>(endValue, settings));
        public static Tween UIAnchorMax( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings) => UIAnchorMax(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings));
        public static Tween UIAnchorMax( UnityEngine.RectTransform target, TweenSettings<UnityEngine.Vector2> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.Vector2Val;
                _target.anchorMax = val;
            }, t => (t.target as UnityEngine.RectTransform).anchorMax.ToContainer());
        }

        public static Tween UIAnchorMin( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchorMin(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchorMin( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchorMin(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchorMin( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchorMin(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchorMin( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchorMin(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchorMin( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, TweenSettings settings) => UIAnchorMin(target, new TweenSettings<UnityEngine.Vector2>(endValue, settings));
        public static Tween UIAnchorMin( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings) => UIAnchorMin(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings));
        public static Tween UIAnchorMin( UnityEngine.RectTransform target, TweenSettings<UnityEngine.Vector2> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.Vector2Val;
                _target.anchorMin = val;
            }, t => (t.target as UnityEngine.RectTransform).anchorMin.ToContainer());
        }

        public static Tween UIAnchoredPosition3D( UnityEngine.RectTransform target, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition3D(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition3D( UnityEngine.RectTransform target, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition3D(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition3D( UnityEngine.RectTransform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition3D(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition3D( UnityEngine.RectTransform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition3D(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition3D( UnityEngine.RectTransform target, UnityEngine.Vector3 endValue, TweenSettings settings) => UIAnchoredPosition3D(target, new TweenSettings<UnityEngine.Vector3>(endValue, settings));
        public static Tween UIAnchoredPosition3D( UnityEngine.RectTransform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, TweenSettings settings) => UIAnchoredPosition3D(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, settings));
        public static Tween UIAnchoredPosition3D( UnityEngine.RectTransform target, TweenSettings<UnityEngine.Vector3> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.Vector3Val;
                _target.anchoredPosition3D = val;
            }, t => (t.target as UnityEngine.RectTransform).anchoredPosition3D.ToContainer());
        }

        public static Tween UIAnchoredPosition3DX( UnityEngine.RectTransform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition3DX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition3DX( UnityEngine.RectTransform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition3DX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition3DX( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition3DX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition3DX( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition3DX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition3DX( UnityEngine.RectTransform target, Single endValue, TweenSettings settings) => UIAnchoredPosition3DX(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIAnchoredPosition3DX( UnityEngine.RectTransform target, Single startValue, Single endValue, TweenSettings settings) => UIAnchoredPosition3DX(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIAnchoredPosition3DX( UnityEngine.RectTransform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.FloatVal;
                _target.anchoredPosition3D = _target.anchoredPosition3D.WithComponent(0, val);
            }, t => (t.target as UnityEngine.RectTransform).anchoredPosition3D[0].ToContainer());
        }

        public static Tween UIAnchoredPosition3DY( UnityEngine.RectTransform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition3DY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition3DY( UnityEngine.RectTransform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition3DY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition3DY( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition3DY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition3DY( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition3DY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition3DY( UnityEngine.RectTransform target, Single endValue, TweenSettings settings) => UIAnchoredPosition3DY(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIAnchoredPosition3DY( UnityEngine.RectTransform target, Single startValue, Single endValue, TweenSettings settings) => UIAnchoredPosition3DY(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIAnchoredPosition3DY( UnityEngine.RectTransform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.FloatVal;
                _target.anchoredPosition3D = _target.anchoredPosition3D.WithComponent(1, val);
            }, t => (t.target as UnityEngine.RectTransform).anchoredPosition3D[1].ToContainer());
        }

        public static Tween UIAnchoredPosition3DZ( UnityEngine.RectTransform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition3DZ(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition3DZ( UnityEngine.RectTransform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition3DZ(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition3DZ( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition3DZ(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition3DZ( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition3DZ(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition3DZ( UnityEngine.RectTransform target, Single endValue, TweenSettings settings) => UIAnchoredPosition3DZ(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIAnchoredPosition3DZ( UnityEngine.RectTransform target, Single startValue, Single endValue, TweenSettings settings) => UIAnchoredPosition3DZ(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIAnchoredPosition3DZ( UnityEngine.RectTransform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.FloatVal;
                _target.anchoredPosition3D = _target.anchoredPosition3D.WithComponent(2, val);
            }, t => (t.target as UnityEngine.RectTransform).anchoredPosition3D[2].ToContainer());
        }

        public static Tween UIEffectDistance( UnityEngine.UI.Shadow target, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIEffectDistance(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIEffectDistance( UnityEngine.UI.Shadow target, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIEffectDistance(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIEffectDistance( UnityEngine.UI.Shadow target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIEffectDistance(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIEffectDistance( UnityEngine.UI.Shadow target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIEffectDistance(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIEffectDistance( UnityEngine.UI.Shadow target, UnityEngine.Vector2 endValue, TweenSettings settings) => UIEffectDistance(target, new TweenSettings<UnityEngine.Vector2>(endValue, settings));
        public static Tween UIEffectDistance( UnityEngine.UI.Shadow target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings) => UIEffectDistance(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings));
        public static Tween UIEffectDistance( UnityEngine.UI.Shadow target, TweenSettings<UnityEngine.Vector2> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.Shadow;
                var val = _tween.Vector2Val;
                _target.effectDistance = val;
            }, t => (t.target as UnityEngine.UI.Shadow).effectDistance.ToContainer());
        }

        public static Tween Alpha( UnityEngine.UI.Shadow target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Alpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Alpha( UnityEngine.UI.Shadow target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Alpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Alpha( UnityEngine.UI.Shadow target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Alpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Alpha( UnityEngine.UI.Shadow target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Alpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Alpha( UnityEngine.UI.Shadow target, Single endValue, TweenSettings settings) => Alpha(target, new TweenSettings<float>(endValue, settings));
        public static Tween Alpha( UnityEngine.UI.Shadow target, Single startValue, Single endValue, TweenSettings settings) => Alpha(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween Alpha( UnityEngine.UI.Shadow target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.Shadow;
                var val = _tween.FloatVal;
                _target.effectColor = _target.effectColor.WithAlpha(val);
            }, t => (t.target as UnityEngine.UI.Shadow).effectColor.a.ToContainer());
        }

        public static Tween Color( UnityEngine.UI.Shadow target, UnityEngine.Color endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Color(target, new TweenSettings<UnityEngine.Color>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Color( UnityEngine.UI.Shadow target, UnityEngine.Color endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Color(target, new TweenSettings<UnityEngine.Color>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Color( UnityEngine.UI.Shadow target, UnityEngine.Color startValue, UnityEngine.Color endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Color(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Color( UnityEngine.UI.Shadow target, UnityEngine.Color startValue, UnityEngine.Color endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Color(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Color( UnityEngine.UI.Shadow target, UnityEngine.Color endValue, TweenSettings settings) => Color(target, new TweenSettings<UnityEngine.Color>(endValue, settings));
        public static Tween Color( UnityEngine.UI.Shadow target, UnityEngine.Color startValue, UnityEngine.Color endValue, TweenSettings settings) => Color(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, settings));
        public static Tween Color( UnityEngine.UI.Shadow target, TweenSettings<UnityEngine.Color> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.Shadow;
                var val = _tween.ColorVal;
                _target.effectColor = val;
            }, t => (t.target as UnityEngine.UI.Shadow).effectColor.ToContainer());
        }

        public static Tween UIPreferredSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPreferredSize(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPreferredSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPreferredSize(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPreferredSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPreferredSize(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPreferredSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPreferredSize(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPreferredSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 endValue, TweenSettings settings) => UIPreferredSize(target, new TweenSettings<UnityEngine.Vector2>(endValue, settings));
        public static Tween UIPreferredSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings) => UIPreferredSize(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings));
        public static Tween UIPreferredSize( UnityEngine.UI.LayoutElement target, TweenSettings<UnityEngine.Vector2> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.LayoutElement;
                var val = _tween.Vector2Val;
                _target.SetPreferredSize(val);
            }, t => (t.target as UnityEngine.UI.LayoutElement).GetPreferredSize().ToContainer());
        }

        public static Tween UIPreferredWidth( UnityEngine.UI.LayoutElement target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPreferredWidth(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPreferredWidth( UnityEngine.UI.LayoutElement target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPreferredWidth(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPreferredWidth( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPreferredWidth(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPreferredWidth( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPreferredWidth(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPreferredWidth( UnityEngine.UI.LayoutElement target, Single endValue, TweenSettings settings) => UIPreferredWidth(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIPreferredWidth( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, TweenSettings settings) => UIPreferredWidth(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIPreferredWidth( UnityEngine.UI.LayoutElement target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.LayoutElement;
                var val = _tween.FloatVal;
                _target.preferredWidth = val;
            }, t => (t.target as UnityEngine.UI.LayoutElement).preferredWidth.ToContainer());
        }

        public static Tween UIPreferredHeight( UnityEngine.UI.LayoutElement target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPreferredHeight(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPreferredHeight( UnityEngine.UI.LayoutElement target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPreferredHeight(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPreferredHeight( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPreferredHeight(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPreferredHeight( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIPreferredHeight(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIPreferredHeight( UnityEngine.UI.LayoutElement target, Single endValue, TweenSettings settings) => UIPreferredHeight(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIPreferredHeight( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, TweenSettings settings) => UIPreferredHeight(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIPreferredHeight( UnityEngine.UI.LayoutElement target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.LayoutElement;
                var val = _tween.FloatVal;
                _target.preferredHeight = val;
            }, t => (t.target as UnityEngine.UI.LayoutElement).preferredHeight.ToContainer());
        }

        public static Tween UIFlexibleSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIFlexibleSize(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIFlexibleSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIFlexibleSize(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIFlexibleSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIFlexibleSize(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIFlexibleSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIFlexibleSize(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIFlexibleSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 endValue, TweenSettings settings) => UIFlexibleSize(target, new TweenSettings<UnityEngine.Vector2>(endValue, settings));
        public static Tween UIFlexibleSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings) => UIFlexibleSize(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings));
        public static Tween UIFlexibleSize( UnityEngine.UI.LayoutElement target, TweenSettings<UnityEngine.Vector2> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.LayoutElement;
                var val = _tween.Vector2Val;
                _target.SetFlexibleSize(val);
            }, t => (t.target as UnityEngine.UI.LayoutElement).GetFlexibleSize().ToContainer());
        }

        public static Tween UIFlexibleWidth( UnityEngine.UI.LayoutElement target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIFlexibleWidth(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIFlexibleWidth( UnityEngine.UI.LayoutElement target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIFlexibleWidth(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIFlexibleWidth( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIFlexibleWidth(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIFlexibleWidth( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIFlexibleWidth(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIFlexibleWidth( UnityEngine.UI.LayoutElement target, Single endValue, TweenSettings settings) => UIFlexibleWidth(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIFlexibleWidth( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, TweenSettings settings) => UIFlexibleWidth(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIFlexibleWidth( UnityEngine.UI.LayoutElement target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.LayoutElement;
                var val = _tween.FloatVal;
                _target.flexibleWidth = val;
            }, t => (t.target as UnityEngine.UI.LayoutElement).flexibleWidth.ToContainer());
        }

        public static Tween UIFlexibleHeight( UnityEngine.UI.LayoutElement target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIFlexibleHeight(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIFlexibleHeight( UnityEngine.UI.LayoutElement target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIFlexibleHeight(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIFlexibleHeight( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIFlexibleHeight(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIFlexibleHeight( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIFlexibleHeight(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIFlexibleHeight( UnityEngine.UI.LayoutElement target, Single endValue, TweenSettings settings) => UIFlexibleHeight(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIFlexibleHeight( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, TweenSettings settings) => UIFlexibleHeight(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIFlexibleHeight( UnityEngine.UI.LayoutElement target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.LayoutElement;
                var val = _tween.FloatVal;
                _target.flexibleHeight = val;
            }, t => (t.target as UnityEngine.UI.LayoutElement).flexibleHeight.ToContainer());
        }

        public static Tween UIMinSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIMinSize(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIMinSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIMinSize(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIMinSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIMinSize(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIMinSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIMinSize(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIMinSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 endValue, TweenSettings settings) => UIMinSize(target, new TweenSettings<UnityEngine.Vector2>(endValue, settings));
        public static Tween UIMinSize( UnityEngine.UI.LayoutElement target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings) => UIMinSize(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings));
        public static Tween UIMinSize( UnityEngine.UI.LayoutElement target, TweenSettings<UnityEngine.Vector2> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.LayoutElement;
                var val = _tween.Vector2Val;
                _target.SetMinSize(val);
            }, t => (t.target as UnityEngine.UI.LayoutElement).GetMinSize().ToContainer());
        }

        public static Tween UIMinWidth( UnityEngine.UI.LayoutElement target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIMinWidth(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIMinWidth( UnityEngine.UI.LayoutElement target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIMinWidth(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIMinWidth( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIMinWidth(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIMinWidth( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIMinWidth(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIMinWidth( UnityEngine.UI.LayoutElement target, Single endValue, TweenSettings settings) => UIMinWidth(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIMinWidth( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, TweenSettings settings) => UIMinWidth(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIMinWidth( UnityEngine.UI.LayoutElement target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.LayoutElement;
                var val = _tween.FloatVal;
                _target.minWidth = val;
            }, t => (t.target as UnityEngine.UI.LayoutElement).minWidth.ToContainer());
        }

        public static Tween UIMinHeight( UnityEngine.UI.LayoutElement target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIMinHeight(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIMinHeight( UnityEngine.UI.LayoutElement target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIMinHeight(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIMinHeight( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIMinHeight(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIMinHeight( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIMinHeight(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIMinHeight( UnityEngine.UI.LayoutElement target, Single endValue, TweenSettings settings) => UIMinHeight(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIMinHeight( UnityEngine.UI.LayoutElement target, Single startValue, Single endValue, TweenSettings settings) => UIMinHeight(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIMinHeight( UnityEngine.UI.LayoutElement target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.LayoutElement;
                var val = _tween.FloatVal;
                _target.minHeight = val;
            }, t => (t.target as UnityEngine.UI.LayoutElement).minHeight.ToContainer());
        }

        public static Tween Color( UnityEngine.UI.Graphic target, UnityEngine.Color endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Color(target, new TweenSettings<UnityEngine.Color>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Color( UnityEngine.UI.Graphic target, UnityEngine.Color endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Color(target, new TweenSettings<UnityEngine.Color>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Color( UnityEngine.UI.Graphic target, UnityEngine.Color startValue, UnityEngine.Color endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Color(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Color( UnityEngine.UI.Graphic target, UnityEngine.Color startValue, UnityEngine.Color endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Color(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Color( UnityEngine.UI.Graphic target, UnityEngine.Color endValue, TweenSettings settings) => Color(target, new TweenSettings<UnityEngine.Color>(endValue, settings));
        public static Tween Color( UnityEngine.UI.Graphic target, UnityEngine.Color startValue, UnityEngine.Color endValue, TweenSettings settings) => Color(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, settings));
        public static Tween Color( UnityEngine.UI.Graphic target, TweenSettings<UnityEngine.Color> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.Graphic;
                var val = _tween.ColorVal;
                _target.color = val;
            }, t => (t.target as UnityEngine.UI.Graphic).color.ToContainer());
        }

        public static Tween UIAnchoredPosition( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPosition(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPosition( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, TweenSettings settings) => UIAnchoredPosition(target, new TweenSettings<UnityEngine.Vector2>(endValue, settings));
        public static Tween UIAnchoredPosition( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings) => UIAnchoredPosition(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings));
        public static Tween UIAnchoredPosition( UnityEngine.RectTransform target, TweenSettings<UnityEngine.Vector2> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.Vector2Val;
                _target.anchoredPosition = val;
            }, t => (t.target as UnityEngine.RectTransform).anchoredPosition.ToContainer());
        }

        public static Tween UIAnchoredPositionX( UnityEngine.RectTransform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPositionX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPositionX( UnityEngine.RectTransform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPositionX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPositionX( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPositionX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPositionX( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPositionX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPositionX( UnityEngine.RectTransform target, Single endValue, TweenSettings settings) => UIAnchoredPositionX(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIAnchoredPositionX( UnityEngine.RectTransform target, Single startValue, Single endValue, TweenSettings settings) => UIAnchoredPositionX(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIAnchoredPositionX( UnityEngine.RectTransform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.FloatVal;
                _target.anchoredPosition = _target.anchoredPosition.WithComponent(0, val);
            }, t => (t.target as UnityEngine.RectTransform).anchoredPosition.x.ToContainer());
        }

        public static Tween UIAnchoredPositionY( UnityEngine.RectTransform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPositionY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPositionY( UnityEngine.RectTransform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPositionY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPositionY( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPositionY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPositionY( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIAnchoredPositionY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIAnchoredPositionY( UnityEngine.RectTransform target, Single endValue, TweenSettings settings) => UIAnchoredPositionY(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIAnchoredPositionY( UnityEngine.RectTransform target, Single startValue, Single endValue, TweenSettings settings) => UIAnchoredPositionY(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIAnchoredPositionY( UnityEngine.RectTransform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.FloatVal;
                _target.anchoredPosition = _target.anchoredPosition.WithComponent(1, val);
            }, t => (t.target as UnityEngine.RectTransform).anchoredPosition.y.ToContainer());
        }

        public static Tween UISizeDelta( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UISizeDelta(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UISizeDelta( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UISizeDelta(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UISizeDelta( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UISizeDelta(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UISizeDelta( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UISizeDelta(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UISizeDelta( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, TweenSettings settings) => UISizeDelta(target, new TweenSettings<UnityEngine.Vector2>(endValue, settings));
        public static Tween UISizeDelta( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings) => UISizeDelta(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings));
        public static Tween UISizeDelta( UnityEngine.RectTransform target, TweenSettings<UnityEngine.Vector2> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.Vector2Val;
                _target.sizeDelta = val;
            }, t => (t.target as UnityEngine.RectTransform).sizeDelta.ToContainer());
        }

        public static Tween Alpha( UnityEngine.CanvasGroup target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Alpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Alpha( UnityEngine.CanvasGroup target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Alpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Alpha( UnityEngine.CanvasGroup target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Alpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Alpha( UnityEngine.CanvasGroup target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Alpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Alpha( UnityEngine.CanvasGroup target, Single endValue, TweenSettings settings) => Alpha(target, new TweenSettings<float>(endValue, settings));
        public static Tween Alpha( UnityEngine.CanvasGroup target, Single startValue, Single endValue, TweenSettings settings) => Alpha(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween Alpha( UnityEngine.CanvasGroup target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.CanvasGroup;
                var val = _tween.FloatVal;
                _target.alpha = val;
            }, t => (t.target as UnityEngine.CanvasGroup).alpha.ToContainer());
        }

        public static Tween Alpha( UnityEngine.UI.Graphic target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Alpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Alpha( UnityEngine.UI.Graphic target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Alpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Alpha( UnityEngine.UI.Graphic target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Alpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Alpha( UnityEngine.UI.Graphic target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Alpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Alpha( UnityEngine.UI.Graphic target, Single endValue, TweenSettings settings) => Alpha(target, new TweenSettings<float>(endValue, settings));
        public static Tween Alpha( UnityEngine.UI.Graphic target, Single startValue, Single endValue, TweenSettings settings) => Alpha(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween Alpha( UnityEngine.UI.Graphic target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.Graphic;
                var val = _tween.FloatVal;
                _target.color = _target.color.WithAlpha(val);
            }, t => (t.target as UnityEngine.UI.Graphic).color.a.ToContainer());
        }

        public static Tween UIFillAmount( UnityEngine.UI.Image target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIFillAmount(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIFillAmount( UnityEngine.UI.Image target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIFillAmount(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIFillAmount( UnityEngine.UI.Image target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIFillAmount(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIFillAmount( UnityEngine.UI.Image target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIFillAmount(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIFillAmount( UnityEngine.UI.Image target, Single endValue, TweenSettings settings) => UIFillAmount(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIFillAmount( UnityEngine.UI.Image target, Single startValue, Single endValue, TweenSettings settings) => UIFillAmount(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIFillAmount( UnityEngine.UI.Image target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UI.Image;
                var val = _tween.FloatVal;
                _target.fillAmount = val;
            }, t => (t.target as UnityEngine.UI.Image).fillAmount.ToContainer());
        }

        public static Tween UIOffsetMin( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMin(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMin( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMin(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMin( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMin(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMin( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMin(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMin( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, TweenSettings settings) => UIOffsetMin(target, new TweenSettings<UnityEngine.Vector2>(endValue, settings));
        public static Tween UIOffsetMin( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings) => UIOffsetMin(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings));
        public static Tween UIOffsetMin( UnityEngine.RectTransform target, TweenSettings<UnityEngine.Vector2> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.Vector2Val;
                _target.offsetMin = val;
            }, t => (t.target as UnityEngine.RectTransform).offsetMin.ToContainer());
        }

        public static Tween UIOffsetMinX( UnityEngine.RectTransform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMinX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMinX( UnityEngine.RectTransform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMinX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMinX( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMinX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMinX( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMinX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMinX( UnityEngine.RectTransform target, Single endValue, TweenSettings settings) => UIOffsetMinX(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIOffsetMinX( UnityEngine.RectTransform target, Single startValue, Single endValue, TweenSettings settings) => UIOffsetMinX(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIOffsetMinX( UnityEngine.RectTransform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.FloatVal;
                _target.offsetMin = _target.offsetMin.WithComponent(0, val);
            }, t => (t.target as UnityEngine.RectTransform).offsetMin[0].ToContainer());
        }

        public static Tween UIOffsetMinY( UnityEngine.RectTransform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMinY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMinY( UnityEngine.RectTransform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMinY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMinY( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMinY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMinY( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMinY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMinY( UnityEngine.RectTransform target, Single endValue, TweenSettings settings) => UIOffsetMinY(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIOffsetMinY( UnityEngine.RectTransform target, Single startValue, Single endValue, TweenSettings settings) => UIOffsetMinY(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIOffsetMinY( UnityEngine.RectTransform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.FloatVal;
                _target.offsetMin = _target.offsetMin.WithComponent(1, val);
            }, t => (t.target as UnityEngine.RectTransform).offsetMin[1].ToContainer());
        }

        public static Tween UIOffsetMax( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMax(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMax( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMax(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMax( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMax(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMax( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMax(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMax( UnityEngine.RectTransform target, UnityEngine.Vector2 endValue, TweenSettings settings) => UIOffsetMax(target, new TweenSettings<UnityEngine.Vector2>(endValue, settings));
        public static Tween UIOffsetMax( UnityEngine.RectTransform target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings) => UIOffsetMax(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings));
        public static Tween UIOffsetMax( UnityEngine.RectTransform target, TweenSettings<UnityEngine.Vector2> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.Vector2Val;
                _target.offsetMax = val;
            }, t => (t.target as UnityEngine.RectTransform).offsetMax.ToContainer());
        }

        public static Tween UIOffsetMaxX( UnityEngine.RectTransform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMaxX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMaxX( UnityEngine.RectTransform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMaxX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMaxX( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMaxX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMaxX( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMaxX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMaxX( UnityEngine.RectTransform target, Single endValue, TweenSettings settings) => UIOffsetMaxX(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIOffsetMaxX( UnityEngine.RectTransform target, Single startValue, Single endValue, TweenSettings settings) => UIOffsetMaxX(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIOffsetMaxX( UnityEngine.RectTransform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.FloatVal;
                _target.offsetMax = _target.offsetMax.WithComponent(0, val);
            }, t => (t.target as UnityEngine.RectTransform).offsetMax[0].ToContainer());
        }

        public static Tween UIOffsetMaxY( UnityEngine.RectTransform target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMaxY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMaxY( UnityEngine.RectTransform target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMaxY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMaxY( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMaxY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMaxY( UnityEngine.RectTransform target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => UIOffsetMaxY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween UIOffsetMaxY( UnityEngine.RectTransform target, Single endValue, TweenSettings settings) => UIOffsetMaxY(target, new TweenSettings<float>(endValue, settings));
        public static Tween UIOffsetMaxY( UnityEngine.RectTransform target, Single startValue, Single endValue, TweenSettings settings) => UIOffsetMaxY(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween UIOffsetMaxY( UnityEngine.RectTransform target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.RectTransform;
                var val = _tween.FloatVal;
                _target.offsetMax = _target.offsetMax.WithComponent(1, val);
            }, t => (t.target as UnityEngine.RectTransform).offsetMax[1].ToContainer());
        }

        #endif
        #if !UNITY_2019_1_OR_NEWER || PHYSICS_MODULE_INSTALLED
        public static Tween RigidbodyMovePosition( UnityEngine.Rigidbody target, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RigidbodyMovePosition(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RigidbodyMovePosition( UnityEngine.Rigidbody target, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RigidbodyMovePosition(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RigidbodyMovePosition( UnityEngine.Rigidbody target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RigidbodyMovePosition(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RigidbodyMovePosition( UnityEngine.Rigidbody target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RigidbodyMovePosition(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RigidbodyMovePosition( UnityEngine.Rigidbody target, UnityEngine.Vector3 endValue, TweenSettings settings) => RigidbodyMovePosition(target, new TweenSettings<UnityEngine.Vector3>(endValue, settings));
        public static Tween RigidbodyMovePosition( UnityEngine.Rigidbody target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, TweenSettings settings) => RigidbodyMovePosition(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, settings));
        public static Tween RigidbodyMovePosition( UnityEngine.Rigidbody target, TweenSettings<UnityEngine.Vector3> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Rigidbody;
                var val = _tween.Vector3Val;
                _target.MovePosition(val);
            }, t => (t.target as UnityEngine.Rigidbody).position.ToContainer());
        }

        public static Tween RigidbodyMoveRotation( UnityEngine.Rigidbody target, UnityEngine.Quaternion endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RigidbodyMoveRotation(target, new TweenSettings<UnityEngine.Quaternion>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RigidbodyMoveRotation( UnityEngine.Rigidbody target, UnityEngine.Quaternion endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RigidbodyMoveRotation(target, new TweenSettings<UnityEngine.Quaternion>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RigidbodyMoveRotation( UnityEngine.Rigidbody target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RigidbodyMoveRotation(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RigidbodyMoveRotation( UnityEngine.Rigidbody target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RigidbodyMoveRotation(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RigidbodyMoveRotation( UnityEngine.Rigidbody target, UnityEngine.Quaternion endValue, TweenSettings settings) => RigidbodyMoveRotation(target, new TweenSettings<UnityEngine.Quaternion>(endValue, settings));
        public static Tween RigidbodyMoveRotation( UnityEngine.Rigidbody target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, TweenSettings settings) => RigidbodyMoveRotation(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, settings));
        public static Tween RigidbodyMoveRotation( UnityEngine.Rigidbody target, TweenSettings<UnityEngine.Quaternion> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Rigidbody;
                var val = _tween.QuaternionVal;
                _target.MoveRotation(val);
            }, t => (t.target as UnityEngine.Rigidbody).rotation.ToContainer());
        }

        #endif
        #if !UNITY_2019_1_OR_NEWER || PHYSICS2D_MODULE_INSTALLED
        public static Tween RigidbodyMovePosition( UnityEngine.Rigidbody2D target, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RigidbodyMovePosition(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RigidbodyMovePosition( UnityEngine.Rigidbody2D target, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RigidbodyMovePosition(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RigidbodyMovePosition( UnityEngine.Rigidbody2D target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RigidbodyMovePosition(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RigidbodyMovePosition( UnityEngine.Rigidbody2D target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RigidbodyMovePosition(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RigidbodyMovePosition( UnityEngine.Rigidbody2D target, UnityEngine.Vector2 endValue, TweenSettings settings) => RigidbodyMovePosition(target, new TweenSettings<UnityEngine.Vector2>(endValue, settings));
        public static Tween RigidbodyMovePosition( UnityEngine.Rigidbody2D target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings) => RigidbodyMovePosition(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings));
        public static Tween RigidbodyMovePosition( UnityEngine.Rigidbody2D target, TweenSettings<UnityEngine.Vector2> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Rigidbody2D;
                var val = _tween.Vector2Val;
                _target.MovePosition(val);
            }, t => (t.target as UnityEngine.Rigidbody2D).position.ToContainer());
        }

        public static Tween RigidbodyMoveRotation( UnityEngine.Rigidbody2D target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RigidbodyMoveRotation(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RigidbodyMoveRotation( UnityEngine.Rigidbody2D target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RigidbodyMoveRotation(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RigidbodyMoveRotation( UnityEngine.Rigidbody2D target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RigidbodyMoveRotation(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RigidbodyMoveRotation( UnityEngine.Rigidbody2D target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RigidbodyMoveRotation(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RigidbodyMoveRotation( UnityEngine.Rigidbody2D target, Single endValue, TweenSettings settings) => RigidbodyMoveRotation(target, new TweenSettings<float>(endValue, settings));
        public static Tween RigidbodyMoveRotation( UnityEngine.Rigidbody2D target, Single startValue, Single endValue, TweenSettings settings) => RigidbodyMoveRotation(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween RigidbodyMoveRotation( UnityEngine.Rigidbody2D target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Rigidbody2D;
                var val = _tween.FloatVal;
                _target.MoveRotation(val);
            }, t => (t.target as UnityEngine.Rigidbody2D).rotation.ToContainer());
        }

        #endif
        public static Tween MaterialColor( UnityEngine.Material target, UnityEngine.Color endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => MaterialColor(target, new TweenSettings<UnityEngine.Color>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween MaterialColor( UnityEngine.Material target, UnityEngine.Color endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => MaterialColor(target, new TweenSettings<UnityEngine.Color>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween MaterialColor( UnityEngine.Material target, UnityEngine.Color startValue, UnityEngine.Color endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => MaterialColor(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween MaterialColor( UnityEngine.Material target, UnityEngine.Color startValue, UnityEngine.Color endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => MaterialColor(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween MaterialColor( UnityEngine.Material target, UnityEngine.Color endValue, TweenSettings settings) => MaterialColor(target, new TweenSettings<UnityEngine.Color>(endValue, settings));
        public static Tween MaterialColor( UnityEngine.Material target, UnityEngine.Color startValue, UnityEngine.Color endValue, TweenSettings settings) => MaterialColor(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, settings));
        public static Tween MaterialColor( UnityEngine.Material target, TweenSettings<UnityEngine.Color> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Material;
                var val = _tween.ColorVal;
                _target.color = val;
            }, t => (t.target as UnityEngine.Material).color.ToContainer());
        }

        public static Tween MaterialAlpha( UnityEngine.Material target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => MaterialAlpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween MaterialAlpha( UnityEngine.Material target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => MaterialAlpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween MaterialAlpha( UnityEngine.Material target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => MaterialAlpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween MaterialAlpha( UnityEngine.Material target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => MaterialAlpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween MaterialAlpha( UnityEngine.Material target, Single endValue, TweenSettings settings) => MaterialAlpha(target, new TweenSettings<float>(endValue, settings));
        public static Tween MaterialAlpha( UnityEngine.Material target, Single startValue, Single endValue, TweenSettings settings) => MaterialAlpha(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween MaterialAlpha( UnityEngine.Material target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Material;
                var val = _tween.FloatVal;
                _target.color = _target.color.WithAlpha(val);
            }, t => (t.target as UnityEngine.Material).color.a.ToContainer());
        }

        public static Tween MaterialMainTextureOffset( UnityEngine.Material target, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => MaterialMainTextureOffset(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween MaterialMainTextureOffset( UnityEngine.Material target, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => MaterialMainTextureOffset(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween MaterialMainTextureOffset( UnityEngine.Material target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => MaterialMainTextureOffset(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween MaterialMainTextureOffset( UnityEngine.Material target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => MaterialMainTextureOffset(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween MaterialMainTextureOffset( UnityEngine.Material target, UnityEngine.Vector2 endValue, TweenSettings settings) => MaterialMainTextureOffset(target, new TweenSettings<UnityEngine.Vector2>(endValue, settings));
        public static Tween MaterialMainTextureOffset( UnityEngine.Material target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings) => MaterialMainTextureOffset(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings));
        public static Tween MaterialMainTextureOffset( UnityEngine.Material target, TweenSettings<UnityEngine.Vector2> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Material;
                var val = _tween.Vector2Val;
                _target.mainTextureOffset = val;
            }, t => (t.target as UnityEngine.Material).mainTextureOffset.ToContainer());
        }

        public static Tween MaterialMainTextureScale( UnityEngine.Material target, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => MaterialMainTextureScale(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween MaterialMainTextureScale( UnityEngine.Material target, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => MaterialMainTextureScale(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween MaterialMainTextureScale( UnityEngine.Material target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => MaterialMainTextureScale(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween MaterialMainTextureScale( UnityEngine.Material target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => MaterialMainTextureScale(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween MaterialMainTextureScale( UnityEngine.Material target, UnityEngine.Vector2 endValue, TweenSettings settings) => MaterialMainTextureScale(target, new TweenSettings<UnityEngine.Vector2>(endValue, settings));
        public static Tween MaterialMainTextureScale( UnityEngine.Material target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings) => MaterialMainTextureScale(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings));
        public static Tween MaterialMainTextureScale( UnityEngine.Material target, TweenSettings<UnityEngine.Vector2> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Material;
                var val = _tween.Vector2Val;
                _target.mainTextureScale = val;
            }, t => (t.target as UnityEngine.Material).mainTextureScale.ToContainer());
        }

        #if !UNITY_2019_1_OR_NEWER || AUDIO_MODULE_INSTALLED
        public static Tween AudioVolume( UnityEngine.AudioSource target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => AudioVolume(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween AudioVolume( UnityEngine.AudioSource target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => AudioVolume(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween AudioVolume( UnityEngine.AudioSource target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => AudioVolume(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween AudioVolume( UnityEngine.AudioSource target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => AudioVolume(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween AudioVolume( UnityEngine.AudioSource target, Single endValue, TweenSettings settings) => AudioVolume(target, new TweenSettings<float>(endValue, settings));
        public static Tween AudioVolume( UnityEngine.AudioSource target, Single startValue, Single endValue, TweenSettings settings) => AudioVolume(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween AudioVolume( UnityEngine.AudioSource target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.AudioSource;
                var val = _tween.FloatVal;
                _target.volume = val;
            }, t => (t.target as UnityEngine.AudioSource).volume.ToContainer());
        }

        public static Tween AudioPitch( UnityEngine.AudioSource target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => AudioPitch(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween AudioPitch( UnityEngine.AudioSource target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => AudioPitch(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween AudioPitch( UnityEngine.AudioSource target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => AudioPitch(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween AudioPitch( UnityEngine.AudioSource target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => AudioPitch(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween AudioPitch( UnityEngine.AudioSource target, Single endValue, TweenSettings settings) => AudioPitch(target, new TweenSettings<float>(endValue, settings));
        public static Tween AudioPitch( UnityEngine.AudioSource target, Single startValue, Single endValue, TweenSettings settings) => AudioPitch(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween AudioPitch( UnityEngine.AudioSource target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.AudioSource;
                var val = _tween.FloatVal;
                _target.pitch = val;
            }, t => (t.target as UnityEngine.AudioSource).pitch.ToContainer());
        }

        public static Tween AudioPanStereo( UnityEngine.AudioSource target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => AudioPanStereo(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween AudioPanStereo( UnityEngine.AudioSource target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => AudioPanStereo(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween AudioPanStereo( UnityEngine.AudioSource target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => AudioPanStereo(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween AudioPanStereo( UnityEngine.AudioSource target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => AudioPanStereo(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween AudioPanStereo( UnityEngine.AudioSource target, Single endValue, TweenSettings settings) => AudioPanStereo(target, new TweenSettings<float>(endValue, settings));
        public static Tween AudioPanStereo( UnityEngine.AudioSource target, Single startValue, Single endValue, TweenSettings settings) => AudioPanStereo(target, new TweenSettings<float>(startValue, endValue, settings));
        public static Tween AudioPanStereo( UnityEngine.AudioSource target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.AudioSource;
                var val = _tween.FloatVal;
                _target.panStereo = val;
            }, t => (t.target as UnityEngine.AudioSource).panStereo.ToContainer());
        }

        #endif
        #if UI_ELEMENTS_MODULE_INSTALLED
        public static Tween VisualElementLayout( UnityEngine.UIElements.VisualElement target, UnityEngine.Rect endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => VisualElementLayout(target, new TweenSettings<UnityEngine.Rect>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween VisualElementLayout( UnityEngine.UIElements.VisualElement target, UnityEngine.Rect endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => VisualElementLayout(target, new TweenSettings<UnityEngine.Rect>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween VisualElementLayout( UnityEngine.UIElements.VisualElement target, UnityEngine.Rect startValue, UnityEngine.Rect endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => VisualElementLayout(target, new TweenSettings<UnityEngine.Rect>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween VisualElementLayout( UnityEngine.UIElements.VisualElement target, UnityEngine.Rect startValue, UnityEngine.Rect endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => VisualElementLayout(target, new TweenSettings<UnityEngine.Rect>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween VisualElementLayout( UnityEngine.UIElements.VisualElement target, UnityEngine.Rect endValue, TweenSettings settings) => VisualElementLayout(target, new TweenSettings<UnityEngine.Rect>(endValue, settings));
        public static Tween VisualElementLayout( UnityEngine.UIElements.VisualElement target, UnityEngine.Rect startValue, UnityEngine.Rect endValue, TweenSettings settings) => VisualElementLayout(target, new TweenSettings<UnityEngine.Rect>(startValue, endValue, settings));
        public static Tween VisualElementLayout( UnityEngine.UIElements.VisualElement target, TweenSettings<UnityEngine.Rect> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UIElements.VisualElement;
                var val = _tween.RectVal;
                _target.SetStyleRect(val);
            }, t => (t.target as UnityEngine.UIElements.VisualElement).GetResolvedStyleRect().ToContainer());
        }

        public static Tween Position( UnityEngine.UIElements.ITransform target, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Position(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Position( UnityEngine.UIElements.ITransform target, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Position(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Position( UnityEngine.UIElements.ITransform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Position(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Position( UnityEngine.UIElements.ITransform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Position(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Position( UnityEngine.UIElements.ITransform target, UnityEngine.Vector3 endValue, TweenSettings settings) => Position(target, new TweenSettings<UnityEngine.Vector3>(endValue, settings));
        public static Tween Position( UnityEngine.UIElements.ITransform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, TweenSettings settings) => Position(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, settings));
        public static Tween Position( UnityEngine.UIElements.ITransform target, TweenSettings<UnityEngine.Vector3> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UIElements.ITransform;
                var val = _tween.Vector3Val;
                _target.position = val;
            }, t => (t.target as UnityEngine.UIElements.ITransform).position.ToContainer());
        }

        public static Tween Rotation( UnityEngine.UIElements.ITransform target, UnityEngine.Quaternion endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Rotation(target, new TweenSettings<UnityEngine.Quaternion>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Rotation( UnityEngine.UIElements.ITransform target, UnityEngine.Quaternion endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Rotation(target, new TweenSettings<UnityEngine.Quaternion>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Rotation( UnityEngine.UIElements.ITransform target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Rotation(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Rotation( UnityEngine.UIElements.ITransform target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Rotation(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Rotation( UnityEngine.UIElements.ITransform target, UnityEngine.Quaternion endValue, TweenSettings settings) => Rotation(target, new TweenSettings<UnityEngine.Quaternion>(endValue, settings));
        public static Tween Rotation( UnityEngine.UIElements.ITransform target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, TweenSettings settings) => Rotation(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, settings));
        public static Tween Rotation( UnityEngine.UIElements.ITransform target, TweenSettings<UnityEngine.Quaternion> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UIElements.ITransform;
                var val = _tween.QuaternionVal;
                _target.rotation = val;
            }, t => (t.target as UnityEngine.UIElements.ITransform).rotation.ToContainer());
        }

        public static Tween Scale( UnityEngine.UIElements.ITransform target, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Scale(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Scale( UnityEngine.UIElements.ITransform target, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Scale(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Scale( UnityEngine.UIElements.ITransform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Scale(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Scale( UnityEngine.UIElements.ITransform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Scale(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween Scale( UnityEngine.UIElements.ITransform target, UnityEngine.Vector3 endValue, TweenSettings settings) => Scale(target, new TweenSettings<UnityEngine.Vector3>(endValue, settings));
        public static Tween Scale( UnityEngine.UIElements.ITransform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, TweenSettings settings) => Scale(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, settings));
        public static Tween Scale( UnityEngine.UIElements.ITransform target, TweenSettings<UnityEngine.Vector3> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UIElements.ITransform;
                var val = _tween.Vector3Val;
                _target.scale = val;
            }, t => (t.target as UnityEngine.UIElements.ITransform).scale.ToContainer());
        }

        public static Tween VisualElementSize( UnityEngine.UIElements.VisualElement target, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => VisualElementSize(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween VisualElementSize( UnityEngine.UIElements.VisualElement target, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => VisualElementSize(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween VisualElementSize( UnityEngine.UIElements.VisualElement target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => VisualElementSize(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween VisualElementSize( UnityEngine.UIElements.VisualElement target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => VisualElementSize(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween VisualElementSize( UnityEngine.UIElements.VisualElement target, UnityEngine.Vector2 endValue, TweenSettings settings) => VisualElementSize(target, new TweenSettings<UnityEngine.Vector2>(endValue, settings));
        public static Tween VisualElementSize( UnityEngine.UIElements.VisualElement target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings) => VisualElementSize(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings));
        public static Tween VisualElementSize( UnityEngine.UIElements.VisualElement target, TweenSettings<UnityEngine.Vector2> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UIElements.VisualElement;
                var val = _tween.Vector2Val;
                _target.style.width = val.x; _target.style.height = val.y;
            }, t => (t.target as UnityEngine.UIElements.VisualElement).layout.size.ToContainer());
        }

        public static Tween VisualElementTopLeft( UnityEngine.UIElements.VisualElement target, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => VisualElementTopLeft(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween VisualElementTopLeft( UnityEngine.UIElements.VisualElement target, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => VisualElementTopLeft(target, new TweenSettings<UnityEngine.Vector2>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween VisualElementTopLeft( UnityEngine.UIElements.VisualElement target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => VisualElementTopLeft(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween VisualElementTopLeft( UnityEngine.UIElements.VisualElement target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => VisualElementTopLeft(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween VisualElementTopLeft( UnityEngine.UIElements.VisualElement target, UnityEngine.Vector2 endValue, TweenSettings settings) => VisualElementTopLeft(target, new TweenSettings<UnityEngine.Vector2>(endValue, settings));
        public static Tween VisualElementTopLeft( UnityEngine.UIElements.VisualElement target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings) => VisualElementTopLeft(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings));
        public static Tween VisualElementTopLeft( UnityEngine.UIElements.VisualElement target, TweenSettings<UnityEngine.Vector2> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.UIElements.VisualElement;
                var val = _tween.Vector2Val;
                _target.SetTopLeft(val);
            }, t => (t.target as UnityEngine.UIElements.VisualElement).GetTopLeft().ToContainer());
        }

        #endif
        #if TEXT_MESH_PRO_INSTALLED
        public static Tween TextMaxVisibleCharacters( TMPro.TMP_Text target, int endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => TextMaxVisibleCharacters(target, new TweenSettings<int>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween TextMaxVisibleCharacters( TMPro.TMP_Text target, int endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => TextMaxVisibleCharacters(target, new TweenSettings<int>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween TextMaxVisibleCharacters( TMPro.TMP_Text target, int startValue, int endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => TextMaxVisibleCharacters(target, new TweenSettings<int>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween TextMaxVisibleCharacters( TMPro.TMP_Text target, int startValue, int endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => TextMaxVisibleCharacters(target, new TweenSettings<int>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween TextMaxVisibleCharacters( TMPro.TMP_Text target, int endValue, TweenSettings settings) => TextMaxVisibleCharacters(target, new TweenSettings<int>(endValue, settings));
        public static Tween TextMaxVisibleCharacters( TMPro.TMP_Text target, int startValue, int endValue, TweenSettings settings) => TextMaxVisibleCharacters(target, new TweenSettings<int>(startValue, endValue, settings));

        #endif

        public static Tween Custom(float startValue, float endValue, float duration,  Action<float> onValueChange, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Custom(new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom(float startValue, float endValue, float duration,  Action<float> onValueChange, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Custom(new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom(float startValue, float endValue, TweenSettings settings,  Action<float> onValueChange) => Custom(new TweenSettings<float>(startValue, endValue, settings), onValueChange);
        public static Tween Custom(TweenSettings<float> settings,  Action<float> onValueChange) {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Float;
            tween.customOnValueChange = onValueChange;
            tween.Setup(SmoothTweenManager.dummyTarget, ref settings.settings, _tween => {
                var _onValueChange = _tween.customOnValueChange as Action<float>;
                var val = _tween.FloatVal;
                try {
                    _onValueChange(val);
                } catch (Exception e) {
                    UnityEngine.Debug.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}", _tween.unityTarget);
                    _tween.EmergencyStop();
                }
            }, null, false);
            return SmoothTweenManager.Animate(tween);
        }
        public static Tween Custom<T>( T target, float startValue, float endValue, float duration,  Action<T, float> onValueChange, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class 
            => Custom_internal(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom<T>( T target, float startValue, float endValue, float duration,  Action<T, float> onValueChange, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class 
            => Custom_internal(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom<T>( T target, float startValue, float endValue, TweenSettings settings,  Action<T, float> onValueChange) where T : class 
            => Custom_internal(target, new TweenSettings<float>(startValue, endValue, settings), onValueChange);
        public static Tween Custom<T>( T target, TweenSettings<float> settings,  Action<T, float> onValueChange) where T : class 
            => Custom_internal(target, settings, onValueChange);
        #if SMOOTH_TWEEN_EXPERIMENTAL
        public static Tween CustomAdditive<T>( T target, float deltaValue, TweenSettings settings,  Action<T, float> onDeltaChange) where T : class 
            => Custom_internal(target, new TweenSettings<float>(default, deltaValue, settings), onDeltaChange, true);
        #endif
        static Tween Custom_internal<T>( T target, TweenSettings<float> settings,  Action<T, float> onValueChange, bool isAdditive = false) where T : class {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Float;
            tween.customOnValueChange = onValueChange;
            tween.isAdditive = isAdditive;
            tween.Setup(target, ref settings.settings, _tween => {
                var _onValueChange = _tween.customOnValueChange as Action<T, float>;
                var _target = _tween.target as T;
                float val;
                if (_tween.isAdditive) {
                    var newVal = _tween.FloatVal;
                    val = newVal.calcDelta(_tween.prevVal);
                    _tween.prevVal.FloatVal = newVal;
                } else {
                    val = _tween.FloatVal;
                }
                try {
                    _onValueChange(_target, val);
                } catch (Exception e) {
                    UnityEngine.Debug.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}", _tween.unityTarget);
                    _tween.EmergencyStop();
                }
            }, null, false);
            return SmoothTweenManager.Animate(tween);
        }
        static Tween animate(object target, ref TweenSettings<float> settings,  Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter) {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Float;
            tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent);
            return SmoothTweenManager.Animate(tween);
        }
        static Tween animateWithIntParam( object target, int intParam, ref TweenSettings<float> settings,  Action<ReusableTween> setter,  Func<ReusableTween, ValueContainer> getter) {
            var tween = SmoothTweenManager.FetchTween();
            tween.intParam = intParam;
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Float;
            tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent);
            return SmoothTweenManager.Animate(tween);
        }

        public static Tween Custom(UnityEngine.Color startValue, UnityEngine.Color endValue, float duration,  Action<UnityEngine.Color> onValueChange, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Custom(new TweenSettings<UnityEngine.Color>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom(UnityEngine.Color startValue, UnityEngine.Color endValue, float duration,  Action<UnityEngine.Color> onValueChange, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Custom(new TweenSettings<UnityEngine.Color>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom(UnityEngine.Color startValue, UnityEngine.Color endValue, TweenSettings settings,  Action<UnityEngine.Color> onValueChange) => Custom(new TweenSettings<UnityEngine.Color>(startValue, endValue, settings), onValueChange);
        public static Tween Custom(TweenSettings<UnityEngine.Color> settings,  Action<UnityEngine.Color> onValueChange) {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Color;
            tween.customOnValueChange = onValueChange;
            tween.Setup(SmoothTweenManager.dummyTarget, ref settings.settings, _tween => {
                var _onValueChange = _tween.customOnValueChange as Action<UnityEngine.Color>;
                var val = _tween.ColorVal;
                try {
                    _onValueChange(val);
                } catch (Exception e) {
                    UnityEngine.Debug.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}", _tween.unityTarget);
                    _tween.EmergencyStop();
                }
            }, null, false);
            return SmoothTweenManager.Animate(tween);
        }
        public static Tween Custom<T>( T target, UnityEngine.Color startValue, UnityEngine.Color endValue, float duration,  Action<T, UnityEngine.Color> onValueChange, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom<T>( T target, UnityEngine.Color startValue, UnityEngine.Color endValue, float duration,  Action<T, UnityEngine.Color> onValueChange, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom<T>( T target, UnityEngine.Color startValue, UnityEngine.Color endValue, TweenSettings settings,  Action<T, UnityEngine.Color> onValueChange) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Color>(startValue, endValue, settings), onValueChange);
        public static Tween Custom<T>( T target, TweenSettings<UnityEngine.Color> settings,  Action<T, UnityEngine.Color> onValueChange) where T : class 
            => Custom_internal(target, settings, onValueChange);
        #if SMOOTH_TWEEN_EXPERIMENTAL
        public static Tween CustomAdditive<T>( T target, UnityEngine.Color deltaValue, TweenSettings settings,  Action<T, UnityEngine.Color> onDeltaChange) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Color>(default, deltaValue, settings), onDeltaChange, true);
        #endif
        static Tween Custom_internal<T>( T target, TweenSettings<UnityEngine.Color> settings,  Action<T, UnityEngine.Color> onValueChange, bool isAdditive = false) where T : class {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Color;
            tween.customOnValueChange = onValueChange;
            tween.isAdditive = isAdditive;
            tween.Setup(target, ref settings.settings, _tween => {
                var _onValueChange = _tween.customOnValueChange as Action<T, UnityEngine.Color>;
                var _target = _tween.target as T;
                UnityEngine.Color val;
                if (_tween.isAdditive) {
                    var newVal = _tween.ColorVal;
                    val = newVal.calcDelta(_tween.prevVal);
                    _tween.prevVal.ColorVal = newVal;
                } else {
                    val = _tween.ColorVal;
                }
                try {
                    _onValueChange(_target, val);
                } catch (Exception e) {
                    UnityEngine.Debug.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}", _tween.unityTarget);
                    _tween.EmergencyStop();
                }
            }, null, false);
            return SmoothTweenManager.Animate(tween);
        }
        static Tween animate(object target, ref TweenSettings<UnityEngine.Color> settings,  Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter) {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Color;
            tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent);
            return SmoothTweenManager.Animate(tween);
        }
        static Tween animateWithIntParam( object target, int intParam, ref TweenSettings<UnityEngine.Color> settings,  Action<ReusableTween> setter,  Func<ReusableTween, ValueContainer> getter) {
            var tween = SmoothTweenManager.FetchTween();
            tween.intParam = intParam;
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Color;
            tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent);
            return SmoothTweenManager.Animate(tween);
        }

        public static Tween Custom(UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration,  Action<UnityEngine.Vector2> onValueChange, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Custom(new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom(UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration,  Action<UnityEngine.Vector2> onValueChange, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Custom(new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom(UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings,  Action<UnityEngine.Vector2> onValueChange) => Custom(new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings), onValueChange);
        public static Tween Custom(TweenSettings<UnityEngine.Vector2> settings,  Action<UnityEngine.Vector2> onValueChange) {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Vector2;
            tween.customOnValueChange = onValueChange;
            tween.Setup(SmoothTweenManager.dummyTarget, ref settings.settings, _tween => {
                var _onValueChange = _tween.customOnValueChange as Action<UnityEngine.Vector2>;
                var val = _tween.Vector2Val;
                try {
                    _onValueChange(val);
                } catch (Exception e) {
                    UnityEngine.Debug.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}", _tween.unityTarget);
                    _tween.EmergencyStop();
                }
            }, null, false);
            return SmoothTweenManager.Animate(tween);
        }
        public static Tween Custom<T>( T target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration,  Action<T, UnityEngine.Vector2> onValueChange, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom<T>( T target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, float duration,  Action<T, UnityEngine.Vector2> onValueChange, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom<T>( T target, UnityEngine.Vector2 startValue, UnityEngine.Vector2 endValue, TweenSettings settings,  Action<T, UnityEngine.Vector2> onValueChange) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Vector2>(startValue, endValue, settings), onValueChange);
        public static Tween Custom<T>( T target, TweenSettings<UnityEngine.Vector2> settings,  Action<T, UnityEngine.Vector2> onValueChange) where T : class 
            => Custom_internal(target, settings, onValueChange);
        #if SMOOTH_TWEEN_EXPERIMENTAL
        public static Tween CustomAdditive<T>( T target, UnityEngine.Vector2 deltaValue, TweenSettings settings,  Action<T, UnityEngine.Vector2> onDeltaChange) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Vector2>(default, deltaValue, settings), onDeltaChange, true);
        #endif
        static Tween Custom_internal<T>( T target, TweenSettings<UnityEngine.Vector2> settings,  Action<T, UnityEngine.Vector2> onValueChange, bool isAdditive = false) where T : class {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Vector2;
            tween.customOnValueChange = onValueChange;
            tween.isAdditive = isAdditive;
            tween.Setup(target, ref settings.settings, _tween => {
                var _onValueChange = _tween.customOnValueChange as Action<T, UnityEngine.Vector2>;
                var _target = _tween.target as T;
                UnityEngine.Vector2 val;
                if (_tween.isAdditive) {
                    var newVal = _tween.Vector2Val;
                    val = newVal.calcDelta(_tween.prevVal);
                    _tween.prevVal.Vector2Val = newVal;
                } else {
                    val = _tween.Vector2Val;
                }
                try {
                    _onValueChange(_target, val);
                } catch (Exception e) {
                    UnityEngine.Debug.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}", _tween.unityTarget);
                    _tween.EmergencyStop();
                }
            }, null, false);
            return SmoothTweenManager.Animate(tween);
        }
        static Tween animate(object target, ref TweenSettings<UnityEngine.Vector2> settings,  Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter) {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Vector2;
            tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent);
            return SmoothTweenManager.Animate(tween);
        }
        static Tween animateWithIntParam( object target, int intParam, ref TweenSettings<UnityEngine.Vector2> settings,  Action<ReusableTween> setter,  Func<ReusableTween, ValueContainer> getter) {
            var tween = SmoothTweenManager.FetchTween();
            tween.intParam = intParam;
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Vector2;
            tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent);
            return SmoothTweenManager.Animate(tween);
        }

        public static Tween Custom(UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration,  Action<UnityEngine.Vector3> onValueChange, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Custom(new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom(UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration,  Action<UnityEngine.Vector3> onValueChange, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Custom(new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom(UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, TweenSettings settings,  Action<UnityEngine.Vector3> onValueChange) => Custom(new TweenSettings<UnityEngine.Vector3>(startValue, endValue, settings), onValueChange);
        public static Tween Custom(TweenSettings<UnityEngine.Vector3> settings,  Action<UnityEngine.Vector3> onValueChange) {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Vector3;
            tween.customOnValueChange = onValueChange;
            tween.Setup(SmoothTweenManager.dummyTarget, ref settings.settings, _tween => {
                var _onValueChange = _tween.customOnValueChange as Action<UnityEngine.Vector3>;
                var val = _tween.Vector3Val;
                try {
                    _onValueChange(val);
                } catch (Exception e) {
                    UnityEngine.Debug.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}", _tween.unityTarget);
                    _tween.EmergencyStop();
                }
            }, null, false);
            return SmoothTweenManager.Animate(tween);
        }
        public static Tween Custom<T>( T target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration,  Action<T, UnityEngine.Vector3> onValueChange, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom<T>( T target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float duration,  Action<T, UnityEngine.Vector3> onValueChange, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom<T>( T target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, TweenSettings settings,  Action<T, UnityEngine.Vector3> onValueChange) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, settings), onValueChange);
        public static Tween Custom<T>( T target, TweenSettings<UnityEngine.Vector3> settings,  Action<T, UnityEngine.Vector3> onValueChange) where T : class 
            => Custom_internal(target, settings, onValueChange);
        #if SMOOTH_TWEEN_EXPERIMENTAL
        public static Tween CustomAdditive<T>( T target, UnityEngine.Vector3 deltaValue, TweenSettings settings,  Action<T, UnityEngine.Vector3> onDeltaChange) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Vector3>(default, deltaValue, settings), onDeltaChange, true);
        #endif
        static Tween Custom_internal<T>( T target, TweenSettings<UnityEngine.Vector3> settings,  Action<T, UnityEngine.Vector3> onValueChange, bool isAdditive = false) where T : class {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Vector3;
            tween.customOnValueChange = onValueChange;
            tween.isAdditive = isAdditive;
            tween.Setup(target, ref settings.settings, _tween => {
                var _onValueChange = _tween.customOnValueChange as Action<T, UnityEngine.Vector3>;
                var _target = _tween.target as T;
                UnityEngine.Vector3 val;
                if (_tween.isAdditive) {
                    var newVal = _tween.Vector3Val;
                    val = newVal.calcDelta(_tween.prevVal);
                    _tween.prevVal.Vector3Val = newVal;
                } else {
                    val = _tween.Vector3Val;
                }
                try {
                    _onValueChange(_target, val);
                } catch (Exception e) {
                    UnityEngine.Debug.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}", _tween.unityTarget);
                    _tween.EmergencyStop();
                }
            }, null, false);
            return SmoothTweenManager.Animate(tween);
        }
        static Tween animate(object target, ref TweenSettings<UnityEngine.Vector3> settings,  Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter) {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Vector3;
            tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent);
            return SmoothTweenManager.Animate(tween);
        }
        static Tween animateWithIntParam( object target, int intParam, ref TweenSettings<UnityEngine.Vector3> settings,  Action<ReusableTween> setter,  Func<ReusableTween, ValueContainer> getter) {
            var tween = SmoothTweenManager.FetchTween();
            tween.intParam = intParam;
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Vector3;
            tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent);
            return SmoothTweenManager.Animate(tween);
        }

        public static Tween Custom(UnityEngine.Vector4 startValue, UnityEngine.Vector4 endValue, float duration,  Action<UnityEngine.Vector4> onValueChange, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Custom(new TweenSettings<UnityEngine.Vector4>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom(UnityEngine.Vector4 startValue, UnityEngine.Vector4 endValue, float duration,  Action<UnityEngine.Vector4> onValueChange, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Custom(new TweenSettings<UnityEngine.Vector4>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom(UnityEngine.Vector4 startValue, UnityEngine.Vector4 endValue, TweenSettings settings,  Action<UnityEngine.Vector4> onValueChange) => Custom(new TweenSettings<UnityEngine.Vector4>(startValue, endValue, settings), onValueChange);
        public static Tween Custom(TweenSettings<UnityEngine.Vector4> settings,  Action<UnityEngine.Vector4> onValueChange) {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Vector4;
            tween.customOnValueChange = onValueChange;
            tween.Setup(SmoothTweenManager.dummyTarget, ref settings.settings, _tween => {
                var _onValueChange = _tween.customOnValueChange as Action<UnityEngine.Vector4>;
                var val = _tween.Vector4Val;
                try {
                    _onValueChange(val);
                } catch (Exception e) {
                    UnityEngine.Debug.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}", _tween.unityTarget);
                    _tween.EmergencyStop();
                }
            }, null, false);
            return SmoothTweenManager.Animate(tween);
        }
        public static Tween Custom<T>( T target, UnityEngine.Vector4 startValue, UnityEngine.Vector4 endValue, float duration,  Action<T, UnityEngine.Vector4> onValueChange, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Vector4>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom<T>( T target, UnityEngine.Vector4 startValue, UnityEngine.Vector4 endValue, float duration,  Action<T, UnityEngine.Vector4> onValueChange, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Vector4>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom<T>( T target, UnityEngine.Vector4 startValue, UnityEngine.Vector4 endValue, TweenSettings settings,  Action<T, UnityEngine.Vector4> onValueChange) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Vector4>(startValue, endValue, settings), onValueChange);
        public static Tween Custom<T>( T target, TweenSettings<UnityEngine.Vector4> settings,  Action<T, UnityEngine.Vector4> onValueChange) where T : class 
            => Custom_internal(target, settings, onValueChange);
        #if SMOOTH_TWEEN_EXPERIMENTAL
        public static Tween CustomAdditive<T>( T target, UnityEngine.Vector4 deltaValue, TweenSettings settings,  Action<T, UnityEngine.Vector4> onDeltaChange) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Vector4>(default, deltaValue, settings), onDeltaChange, true);
        #endif
        static Tween Custom_internal<T>( T target, TweenSettings<UnityEngine.Vector4> settings,  Action<T, UnityEngine.Vector4> onValueChange, bool isAdditive = false) where T : class {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Vector4;
            tween.customOnValueChange = onValueChange;
            tween.isAdditive = isAdditive;
            tween.Setup(target, ref settings.settings, _tween => {
                var _onValueChange = _tween.customOnValueChange as Action<T, UnityEngine.Vector4>;
                var _target = _tween.target as T;
                UnityEngine.Vector4 val;
                if (_tween.isAdditive) {
                    var newVal = _tween.Vector4Val;
                    val = newVal.calcDelta(_tween.prevVal);
                    _tween.prevVal.Vector4Val = newVal;
                } else {
                    val = _tween.Vector4Val;
                }
                try {
                    _onValueChange(_target, val);
                } catch (Exception e) {
                    UnityEngine.Debug.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}", _tween.unityTarget);
                    _tween.EmergencyStop();
                }
            }, null, false);
            return SmoothTweenManager.Animate(tween);
        }
        static Tween animate(object target, ref TweenSettings<UnityEngine.Vector4> settings,  Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter) {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Vector4;
            tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent);
            return SmoothTweenManager.Animate(tween);
        }
        static Tween animateWithIntParam( object target, int intParam, ref TweenSettings<UnityEngine.Vector4> settings,  Action<ReusableTween> setter,  Func<ReusableTween, ValueContainer> getter) {
            var tween = SmoothTweenManager.FetchTween();
            tween.intParam = intParam;
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Vector4;
            tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent);
            return SmoothTweenManager.Animate(tween);
        }

        public static Tween Custom(UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, float duration,  Action<UnityEngine.Quaternion> onValueChange, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Custom(new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom(UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, float duration,  Action<UnityEngine.Quaternion> onValueChange, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Custom(new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom(UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, TweenSettings settings,  Action<UnityEngine.Quaternion> onValueChange) => Custom(new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, settings), onValueChange);
        public static Tween Custom(TweenSettings<UnityEngine.Quaternion> settings,  Action<UnityEngine.Quaternion> onValueChange) {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Quaternion;
            tween.customOnValueChange = onValueChange;
            tween.Setup(SmoothTweenManager.dummyTarget, ref settings.settings, _tween => {
                var _onValueChange = _tween.customOnValueChange as Action<UnityEngine.Quaternion>;
                var val = _tween.QuaternionVal;
                try {
                    _onValueChange(val);
                } catch (Exception e) {
                    UnityEngine.Debug.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}", _tween.unityTarget);
                    _tween.EmergencyStop();
                }
            }, null, false);
            return SmoothTweenManager.Animate(tween);
        }
        public static Tween Custom<T>( T target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, float duration,  Action<T, UnityEngine.Quaternion> onValueChange, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom<T>( T target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, float duration,  Action<T, UnityEngine.Quaternion> onValueChange, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom<T>( T target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, TweenSettings settings,  Action<T, UnityEngine.Quaternion> onValueChange) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, settings), onValueChange);
        public static Tween Custom<T>( T target, TweenSettings<UnityEngine.Quaternion> settings,  Action<T, UnityEngine.Quaternion> onValueChange) where T : class 
            => Custom_internal(target, settings, onValueChange);
        #if SMOOTH_TWEEN_EXPERIMENTAL
        public static Tween CustomAdditive<T>( T target, UnityEngine.Quaternion deltaValue, TweenSettings settings,  Action<T, UnityEngine.Quaternion> onDeltaChange) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Quaternion>(default, deltaValue, settings), onDeltaChange, true);
        #endif
        static Tween Custom_internal<T>( T target, TweenSettings<UnityEngine.Quaternion> settings,  Action<T, UnityEngine.Quaternion> onValueChange, bool isAdditive = false) where T : class {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Quaternion;
            tween.customOnValueChange = onValueChange;
            tween.isAdditive = isAdditive;
            tween.Setup(target, ref settings.settings, _tween => {
                var _onValueChange = _tween.customOnValueChange as Action<T, UnityEngine.Quaternion>;
                var _target = _tween.target as T;
                UnityEngine.Quaternion val;
                if (_tween.isAdditive) {
                    var newVal = _tween.QuaternionVal;
                    val = newVal.calcDelta(_tween.prevVal);
                    _tween.prevVal.QuaternionVal = newVal;
                } else {
                    val = _tween.QuaternionVal;
                }
                try {
                    _onValueChange(_target, val);
                } catch (Exception e) {
                    UnityEngine.Debug.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}", _tween.unityTarget);
                    _tween.EmergencyStop();
                }
            }, null, false);
            return SmoothTweenManager.Animate(tween);
        }
        static Tween animate(object target, ref TweenSettings<UnityEngine.Quaternion> settings,  Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter) {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Quaternion;
            tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent);
            return SmoothTweenManager.Animate(tween);
        }
        static Tween animateWithIntParam( object target, int intParam, ref TweenSettings<UnityEngine.Quaternion> settings,  Action<ReusableTween> setter,  Func<ReusableTween, ValueContainer> getter) {
            var tween = SmoothTweenManager.FetchTween();
            tween.intParam = intParam;
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Quaternion;
            tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent);
            return SmoothTweenManager.Animate(tween);
        }

        public static Tween Custom(UnityEngine.Rect startValue, UnityEngine.Rect endValue, float duration,  Action<UnityEngine.Rect> onValueChange, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Custom(new TweenSettings<UnityEngine.Rect>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom(UnityEngine.Rect startValue, UnityEngine.Rect endValue, float duration,  Action<UnityEngine.Rect> onValueChange, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Custom(new TweenSettings<UnityEngine.Rect>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom(UnityEngine.Rect startValue, UnityEngine.Rect endValue, TweenSettings settings,  Action<UnityEngine.Rect> onValueChange) => Custom(new TweenSettings<UnityEngine.Rect>(startValue, endValue, settings), onValueChange);
        public static Tween Custom(TweenSettings<UnityEngine.Rect> settings,  Action<UnityEngine.Rect> onValueChange) {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Rect;
            tween.customOnValueChange = onValueChange;
            tween.Setup(SmoothTweenManager.dummyTarget, ref settings.settings, _tween => {
                var _onValueChange = _tween.customOnValueChange as Action<UnityEngine.Rect>;
                var val = _tween.RectVal;
                try {
                    _onValueChange(val);
                } catch (Exception e) {
                    UnityEngine.Debug.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}", _tween.unityTarget);
                    _tween.EmergencyStop();
                }
            }, null, false);
            return SmoothTweenManager.Animate(tween);
        }
        public static Tween Custom<T>( T target, UnityEngine.Rect startValue, UnityEngine.Rect endValue, float duration,  Action<T, UnityEngine.Rect> onValueChange, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Rect>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom<T>( T target, UnityEngine.Rect startValue, UnityEngine.Rect endValue, float duration,  Action<T, UnityEngine.Rect> onValueChange, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Rect>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom<T>( T target, UnityEngine.Rect startValue, UnityEngine.Rect endValue, TweenSettings settings,  Action<T, UnityEngine.Rect> onValueChange) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Rect>(startValue, endValue, settings), onValueChange);
        public static Tween Custom<T>( T target, TweenSettings<UnityEngine.Rect> settings,  Action<T, UnityEngine.Rect> onValueChange) where T : class 
            => Custom_internal(target, settings, onValueChange);
        #if SMOOTH_TWEEN_EXPERIMENTAL
        public static Tween CustomAdditive<T>( T target, UnityEngine.Rect deltaValue, TweenSettings settings,  Action<T, UnityEngine.Rect> onDeltaChange) where T : class 
            => Custom_internal(target, new TweenSettings<UnityEngine.Rect>(default, deltaValue, settings), onDeltaChange, true);
        #endif
        static Tween Custom_internal<T>( T target, TweenSettings<UnityEngine.Rect> settings,  Action<T, UnityEngine.Rect> onValueChange, bool isAdditive = false) where T : class {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Rect;
            tween.customOnValueChange = onValueChange;
            tween.isAdditive = isAdditive;
            tween.Setup(target, ref settings.settings, _tween => {
                var _onValueChange = _tween.customOnValueChange as Action<T, UnityEngine.Rect>;
                var _target = _tween.target as T;
                UnityEngine.Rect val;
                if (_tween.isAdditive) {
                    var newVal = _tween.RectVal;
                    val = newVal.calcDelta(_tween.prevVal);
                    _tween.prevVal.RectVal = newVal;
                } else {
                    val = _tween.RectVal;
                }
                try {
                    _onValueChange(_target, val);
                } catch (Exception e) {
                    UnityEngine.Debug.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}", _tween.unityTarget);
                    _tween.EmergencyStop();
                }
            }, null, false);
            return SmoothTweenManager.Animate(tween);
        }
        static Tween animate(object target, ref TweenSettings<UnityEngine.Rect> settings,  Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter) {
            var tween = SmoothTweenManager.FetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Rect;
            tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent);
            return SmoothTweenManager.Animate(tween);
        }
        static Tween animateWithIntParam( object target, int intParam, ref TweenSettings<UnityEngine.Rect> settings,  Action<ReusableTween> setter,  Func<ReusableTween, ValueContainer> getter) {
            var tween = SmoothTweenManager.FetchTween();
            tween.intParam = intParam;
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Rect;
            tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent);
            return SmoothTweenManager.Animate(tween);
        }
#if SMOOTH_TWEEN_EXPERIMENTAL        
        public static Tween PositionAdditive( UnityEngine.Transform target, UnityEngine.Vector3 deltaValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionAdditive(target, deltaValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime));
        public static Tween PositionAdditive( UnityEngine.Transform target, UnityEngine.Vector3 deltaValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionAdditive(target, deltaValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime));
        public static Tween PositionAdditive( UnityEngine.Transform target, UnityEngine.Vector3 deltaValue, TweenSettings settings) 
            => CustomAdditive(target, deltaValue, settings, (_target, delta) => _target.position += delta);
        
        public static Tween LocalPositionAdditive( UnityEngine.Transform target, UnityEngine.Vector3 deltaValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionAdditive(target, deltaValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime));
        public static Tween LocalPositionAdditive( UnityEngine.Transform target, UnityEngine.Vector3 deltaValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionAdditive(target, deltaValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime));
        public static Tween LocalPositionAdditive( UnityEngine.Transform target, UnityEngine.Vector3 deltaValue, TweenSettings settings) 
            => CustomAdditive(target, deltaValue, settings, (_target, delta) => _target.localPosition += delta);
        
        public static Tween ScaleAdditive( UnityEngine.Transform target, UnityEngine.Vector3 deltaValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => ScaleAdditive(target, deltaValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime));
        public static Tween ScaleAdditive( UnityEngine.Transform target, UnityEngine.Vector3 deltaValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => ScaleAdditive(target, deltaValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime));
        public static Tween ScaleAdditive( UnityEngine.Transform target, UnityEngine.Vector3 deltaValue, TweenSettings settings) 
            => CustomAdditive(target, deltaValue, settings, (_target, delta) => _target.localScale += delta);
        
        public static Tween RotationAdditive( UnityEngine.Transform target, UnityEngine.Vector3 deltaValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RotationAdditive(target, deltaValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime));
        public static Tween RotationAdditive( UnityEngine.Transform target, UnityEngine.Vector3 deltaValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RotationAdditive(target, deltaValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime));
        public static Tween RotationAdditive( UnityEngine.Transform target, UnityEngine.Vector3 deltaValue, TweenSettings settings) 
            => CustomAdditive(target, deltaValue, settings, (_target, delta) => _target.rotation *= UnityEngine.Quaternion.Euler(delta));
        
        public static Tween LocalRotationAdditive( UnityEngine.Transform target, UnityEngine.Vector3 deltaValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalRotationAdditive(target, deltaValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime));
        public static Tween LocalRotationAdditive( UnityEngine.Transform target, UnityEngine.Vector3 deltaValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalRotationAdditive(target, deltaValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime));
        public static Tween LocalRotationAdditive( UnityEngine.Transform target, UnityEngine.Vector3 deltaValue, TweenSettings settings) 
            => CustomAdditive(target, deltaValue, settings, (_target, delta) => _target.localRotation *= UnityEngine.Quaternion.Euler(delta));
        
        public static Tween RotationAdditive( UnityEngine.Transform target, UnityEngine.Quaternion deltaValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RotationAdditive(target, deltaValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime));
        public static Tween RotationAdditive( UnityEngine.Transform target, UnityEngine.Quaternion deltaValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RotationAdditive(target, deltaValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime));
        public static Tween RotationAdditive( UnityEngine.Transform target, UnityEngine.Quaternion deltaValue, TweenSettings settings) 
            => CustomAdditive(target, deltaValue, settings, (_target, delta) => _target.rotation *= delta);
        
        public static Tween LocalRotationAdditive( UnityEngine.Transform target, UnityEngine.Quaternion deltaValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalRotationAdditive(target, deltaValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime));
        public static Tween LocalRotationAdditive( UnityEngine.Transform target, UnityEngine.Quaternion deltaValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalRotationAdditive(target, deltaValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime));
        public static Tween LocalRotationAdditive( UnityEngine.Transform target, UnityEngine.Quaternion deltaValue, TweenSettings settings) 
            => CustomAdditive(target, deltaValue, settings, (_target, delta) => _target.localRotation *= delta);
#endif
        public static Tween PositionAtSpeed( UnityEngine.Transform target, UnityEngine.Vector3 endValue, float averageSpeed, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionAtSpeed(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(averageSpeed, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween PositionAtSpeed( UnityEngine.Transform target, UnityEngine.Vector3 endValue, float averageSpeed, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionAtSpeed(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(averageSpeed, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween PositionAtSpeed( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float averageSpeed, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionAtSpeed(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(averageSpeed, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween PositionAtSpeed( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float averageSpeed, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionAtSpeed(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(averageSpeed, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        static Tween PositionAtSpeed( UnityEngine.Transform target, TweenSettings<UnityEngine.Vector3> settings) {
            var speed = settings.settings.duration;
            if (speed <= 0) {
                UnityEngine.Debug.LogError($"Invalid speed provided to the Tween.{nameof(PositionAtSpeed)}() method: {speed}.");
                return default;
            }
            if (settings.startFromCurrent) {
                settings.startFromCurrent = false;
                settings.startValue = target.position;
            }
            settings.settings.duration = Extensions.CalcDistance(settings.startValue, settings.endValue) / speed;
            return Position(target, settings);
        }

        public static Tween LocalPositionAtSpeed( UnityEngine.Transform target, UnityEngine.Vector3 endValue, float averageSpeed, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionAtSpeed(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(averageSpeed, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPositionAtSpeed( UnityEngine.Transform target, UnityEngine.Vector3 endValue, float averageSpeed, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionAtSpeed(target, new TweenSettings<UnityEngine.Vector3>(endValue, new TweenSettings(averageSpeed, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPositionAtSpeed( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float averageSpeed, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionAtSpeed(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(averageSpeed, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalPositionAtSpeed( UnityEngine.Transform target, UnityEngine.Vector3 startValue, UnityEngine.Vector3 endValue, float averageSpeed, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalPositionAtSpeed(target, new TweenSettings<UnityEngine.Vector3>(startValue, endValue, new TweenSettings(averageSpeed, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        static Tween LocalPositionAtSpeed( UnityEngine.Transform target, TweenSettings<UnityEngine.Vector3> settings) {
            var speed = settings.settings.duration;
            if (speed <= 0) {
                UnityEngine.Debug.LogError($"Invalid speed provided to the Tween.{nameof(LocalPositionAtSpeed)}() method: {speed}.");
                return default;
            }
            if (settings.startFromCurrent) {
                settings.startFromCurrent = false;
                settings.startValue = target.localPosition;
            }
            settings.settings.duration = Extensions.CalcDistance(settings.startValue, settings.endValue) / speed;
            return LocalPosition(target, settings);
        }

        public static Tween RotationAtSpeed( UnityEngine.Transform target, UnityEngine.Quaternion endValue, float averageAngularSpeed, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RotationAtSpeed(target, new TweenSettings<UnityEngine.Quaternion>(endValue, new TweenSettings(averageAngularSpeed, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RotationAtSpeed( UnityEngine.Transform target, UnityEngine.Quaternion endValue, float averageAngularSpeed, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RotationAtSpeed(target, new TweenSettings<UnityEngine.Quaternion>(endValue, new TweenSettings(averageAngularSpeed, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RotationAtSpeed( UnityEngine.Transform target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, float averageAngularSpeed, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RotationAtSpeed(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, new TweenSettings(averageAngularSpeed, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween RotationAtSpeed( UnityEngine.Transform target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, float averageAngularSpeed, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => RotationAtSpeed(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, new TweenSettings(averageAngularSpeed, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        static Tween RotationAtSpeed( UnityEngine.Transform target, TweenSettings<UnityEngine.Quaternion> settings) {
            var speed = settings.settings.duration;
            if (speed <= 0) {
                UnityEngine.Debug.LogError($"Invalid speed provided to the Tween.{nameof(RotationAtSpeed)}() method: {speed}.");
                return default;
            }
            if (settings.startFromCurrent) {
                settings.startFromCurrent = false;
                settings.startValue = target.rotation;
            }
            settings.settings.duration = Extensions.CalcDistance(settings.startValue, settings.endValue) / speed;
            return Rotation(target, settings);
        }

        public static Tween LocalRotationAtSpeed( UnityEngine.Transform target, UnityEngine.Quaternion endValue, float averageAngularSpeed, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalRotationAtSpeed(target, new TweenSettings<UnityEngine.Quaternion>(endValue, new TweenSettings(averageAngularSpeed, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalRotationAtSpeed( UnityEngine.Transform target, UnityEngine.Quaternion endValue, float averageAngularSpeed, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalRotationAtSpeed(target, new TweenSettings<UnityEngine.Quaternion>(endValue, new TweenSettings(averageAngularSpeed, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalRotationAtSpeed( UnityEngine.Transform target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, float averageAngularSpeed, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalRotationAtSpeed(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, new TweenSettings(averageAngularSpeed, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween LocalRotationAtSpeed( UnityEngine.Transform target, UnityEngine.Quaternion startValue, UnityEngine.Quaternion endValue, float averageAngularSpeed, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => LocalRotationAtSpeed(target, new TweenSettings<UnityEngine.Quaternion>(startValue, endValue, new TweenSettings(averageAngularSpeed, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        static Tween LocalRotationAtSpeed( UnityEngine.Transform target, TweenSettings<UnityEngine.Quaternion> settings) {
            var speed = settings.settings.duration;
            if (speed <= 0) {
                UnityEngine.Debug.LogError($"Invalid speed provided to the Tween.{nameof(LocalRotationAtSpeed)}() method: {speed}.");
                return default;
            }
            if (settings.startFromCurrent) {
                settings.startFromCurrent = false;
                settings.startValue = target.localRotation;
            }
            settings.settings.duration = Extensions.CalcDistance(settings.startValue, settings.endValue) / speed;
            return LocalRotation(target, settings);
        }

    }
}