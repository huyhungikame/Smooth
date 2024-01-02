using System;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using SmoothTween;
using UnityEditor;
using UnityEngine;
using Assert = UnityEngine.Assertions.Assert;

internal class CodeGenerator : ScriptableObject
{
    [SerializeField] MonoScript methodsScript;
    [SerializeField] MethodGenerationData[] methodsData;
    [SerializeField] AdditiveMethodsGenerator additiveMethodsGenerator;
    [SerializeField] SpeedBasedMethodsGenerator speedBasedMethodsGenerator;

    [Serializable]
    class AdditiveMethodsGenerator
    {
        [SerializeField] AdditiveMethodsGeneratorData[] additiveMethods;

        [Serializable]
        class AdditiveMethodsGeneratorData
        {
            [SerializeField] internal string methodName;
            [SerializeField] internal PropType propertyType;
            [SerializeField] internal string setter;
        }


        internal string Generate()
        {
            string result = @"
#if PRIME_TWEEN_EXPERIMENTAL";
            foreach (var data in additiveMethods)
            {
                const string template = @"        
        public static Tween PositionAdditive( UnityEngine.Transform target, Single deltaValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionAdditive(target, deltaValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime));
        public static Tween PositionAdditive( UnityEngine.Transform target, Single deltaValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => PositionAdditive(target, deltaValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime));
        public static Tween PositionAdditive( UnityEngine.Transform target, Single deltaValue, TweenSettings settings) 
            => CustomAdditive(target, deltaValue, settings, (_target, delta) => additiveTweenSetter());
";
                result += template.Replace("Single", data.propertyType.ToFullTypeName())
                    .Replace("PositionAdditive", data.methodName)
                    .Replace("additiveTweenSetter()", data.setter);
            }

            result += "#endif";
            return result;
        }
    }

    [ContextMenu(nameof(generateAll))]
    internal void generateAll()
    {
        generateInternalMethods();
    }

    [ContextMenu(nameof(generateInternalMethods))]
    void generateInternalMethods()
    {
        generateMethods();
    }


    static string getMethodPrefix(Dependency dep)
    {
        switch (dep)
        {
            case Dependency.UNITY_UGUI_INSTALLED:
                return "UI";
            case Dependency.AUDIO_MODULE_INSTALLED:
                return "Audio";
            case Dependency.PHYSICS_MODULE_INSTALLED:
            case Dependency.PHYSICS2D_MODULE_INSTALLED:
                return nameof(Rigidbody);
            case Dependency.None:
            case Dependency.PRIME_TWEEN_EXPERIMENTAL:
            case Dependency.UI_ELEMENTS_MODULE_INSTALLED:
            case Dependency.TEXT_MESH_PRO_INSTALLED:
                return null;
        }

        return dep.ToString();
    }

    static bool shouldWrapInDefine(Dependency d)
    {
        switch (d)
        {
            case Dependency.UNITY_UGUI_INSTALLED:
            case Dependency.AUDIO_MODULE_INSTALLED:
            case Dependency.PHYSICS_MODULE_INSTALLED:
            case Dependency.PHYSICS2D_MODULE_INSTALLED:
            case Dependency.PRIME_TWEEN_EXPERIMENTAL:
            case Dependency.UI_ELEMENTS_MODULE_INSTALLED:
            case Dependency.TEXT_MESH_PRO_INSTALLED:
                return true;
        }

        return false;
    }

    const string overloadTemplateTo =
        @"        public static Tween METHOD_NAME( UnityEngine.Camera target, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => METHOD_NAME(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween METHOD_NAME( UnityEngine.Camera target, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => METHOD_NAME(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween METHOD_NAME( UnityEngine.Camera target, Single startValue, Single endValue, float duration, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => METHOD_NAME(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween METHOD_NAME( UnityEngine.Camera target, Single startValue, Single endValue, float duration, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => METHOD_NAME(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)));
        public static Tween METHOD_NAME( UnityEngine.Camera target, Single endValue, TweenSettings settings) => METHOD_NAME(target, new TweenSettings<float>(endValue, settings));
        public static Tween METHOD_NAME( UnityEngine.Camera target, Single startValue, Single endValue, TweenSettings settings) => METHOD_NAME(target, new TweenSettings<float>(startValue, endValue, settings));";

    const string fullTemplate = @"        public static Tween METHOD_NAME( UnityEngine.Camera target, TweenSettings<float> settings) {
            return animate(target, ref settings, _tween => {
                var _target = _tween.target as UnityEngine.Camera;
                var val = _tween.FloatVal;
                _target.orthographicSize = val;
            }, t => (t.target as UnityEngine.Camera).orthographicSize.ToContainer());
        }";

    void generateMethods()
    {
        var text = @"// This file is generated by CodeGenerator.cs
// ReSharper disable PossibleNullReferenceException
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedMethodReturnValue.Global
using System;
using JetBrains.Annotations;

namespace PrimeTween {
    public partial struct Tween {";

        text += generateWithDefines(generate);
        text = addCustomAnimationMethods(text);
        text += additiveMethodsGenerator.Generate();
        text += speedBasedMethodsGenerator.Generate();
        text += @"
    }
}";
        var script = methodsScript;
        var path = AssetDatabase.GetAssetPath(script);
        if (text == File.ReadAllText(path))
        {
            return;
        }

        File.WriteAllText(path, text);
        EditorUtility.SetDirty(methodsScript);
        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
    }


    string generateWithDefines(Func<MethodGenerationData, string> generator)
    {
        string result = "";
        foreach (var group in methodsData.GroupBy(_ => _.dependency))
        {
            result += generateWithDefines(generator, group);
        }

        return result;
    }


    static string generateWithDefines(Func<MethodGenerationData, string> generator, IGrouping<Dependency, MethodGenerationData> group)
    {
        var result = "";
        var dependency = group.Key;
        if (dependency != Dependency.None)
        {
            if (shouldWrapInDefine(dependency))
            {
                switch (dependency)
                {
                    case Dependency.PRIME_TWEEN_EXPERIMENTAL:
                    case Dependency.UI_ELEMENTS_MODULE_INSTALLED:
                    case Dependency.TEXT_MESH_PRO_INSTALLED:
                        result += $"\n        #if {dependency}";
                        break;
                    default:
                        result += $"\n        #if !UNITY_2019_1_OR_NEWER || {dependency}";
                        break;
                }
            }
        }

        foreach (var method in group)
        {
            var generated = generator(method);
            if (!string.IsNullOrEmpty(generated))
            {
                result += generated;
                result += "\n";
            }
        }

        if (dependency != Dependency.None)
        {
            if (shouldWrapInDefine(dependency))
            {
                result += "\n        #endif";
            }
        }

        return result;
    }


    static string generate(MethodGenerationData data)
    {
        Type getTargetType()
        {
            var targetType = data.targetType;
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .Select(_ => _.GetType(targetType))
                .Where(_ => _ != null)
                .Where(_ => _.FullName == targetType)
                .Distinct()
                .ToArray();
            switch (types.Length)
            {
                case 0:
                    throw new Exception($"target type ({targetType}) not found in any of the assemblies.\n" +
                                        "Please specify the full name of the type. For example, instead of 'Transform', use 'UnityEngine.Transform'.\n" +
                                        "Or install the target package in Package Manager.\n");
                case 1:
                    break;
                default:
                    throw new Exception($"More than one type found that match {targetType}. Found:\n"
                                        + string.Join("\n", types.Select(_ => $"{_.AssemblyQualifiedName}\n{_.Assembly.GetName().FullName}")));
            }

            var type = types.Single();
            Assert.IsNotNull(type, $"targetType ({targetType}) wasn't found in any assembly.");
            return type;
        }

        var methodName = data.methodName;
        Assert.IsTrue(System.CodeDom.Compiler.CodeGenerator.IsValidLanguageIndependentIdentifier(methodName), $"Method name is invalid: {methodName}.");
        var propertyName = data.propertyName;

        var overload = populateTemplate(overloadTemplateTo, data);
        var full = populateTemplate(fullTemplate, data);
        const string templatePropName = "orthographicSize";
        string replaced = "";
        if (data.generateOnlyOverloads)
        {
            replaced += "\n";
            replaced += overload;
        }
        else if (propertyName.Any())
        {
            checkFieldOrProp();
            Assert.IsFalse(data.propertyGetter.Any());
            Assert.IsFalse(data.propertySetter.Any());
            replaced += "\n";
            replaced += overload;
            replaced += "\n";
            replaced += full;
            replaced = replaced.Replace(templatePropName, propertyName);

            void checkFieldOrProp()
            {
                var type = getTargetType();
                Assert.IsNotNull(type);
                const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;
                var prop = type.GetProperty(propertyName, flags);
                Type expectedPropType;
                if (data.propertyType == PropType.Float)
                {
                    expectedPropType = typeof(float);
                }
                else if (data.propertyType == PropType.Int)
                {
                    expectedPropType = typeof(int);
                }
                else
                {
                    var typeName = $"{data.propertyType.ToFullTypeName()}, UnityEngine.CoreModule";
                    expectedPropType = Type.GetType(typeName);
                    Assert.IsNotNull(expectedPropType, typeName);
                }

                if (prop != null)
                {
                    Assert.AreEqual(expectedPropType, prop.PropertyType);
                    return;
                }

                var field = type.GetField(propertyName, flags);
                if (field != null)
                {
                    Assert.AreEqual(expectedPropType, field.FieldType, "Field type is incorrect.");
                    return;
                }

                throw new Exception($"Field or property with nane ({propertyName}) not found for type {type.FullName}. Generation data name: {data.name}.");
            }
        }
        else
        {
            Assert.IsTrue(data.propertySetter.Any());
            if (data.propertyGetter.Any())
            {
                replaced += "\n";
                replaced += replaceGetter(overload);
            }

            replaced += "\n";
            full = replaceSetter(full);
            replaced += replaceGetter(full);

            // ReSharper disable once AnnotateNotNullTypeMember
            string replaceGetter(string str)
            {
                while (true)
                {
                    var j = str.IndexOf(templatePropName, StringComparison.Ordinal);
                    if (j == -1)
                    {
                        break;
                    }

                    Assert.AreNotEqual(-1, j);
                    str = str.Remove(j, templatePropName.Length);
                    str = str.Insert(j, data.propertyGetter);
                }

                return str;
            }

            // ReSharper disable once AnnotateNotNullTypeMember
            string replaceSetter(string str)
            {
                while (true)
                {
                    var k = str.IndexOf("orthographicSize =", StringComparison.Ordinal);
                    if (k == -1)
                    {
                        break;
                    }

                    Assert.AreNotEqual(-1, k);
                    var endIndex = str.IndexOf(";", k, StringComparison.Ordinal);
                    Assert.AreNotEqual(-1, endIndex);
                    str = str.Remove(k, endIndex - k);
                    str = str.Insert(k, data.propertySetter);
                }

                return str;
            }
        }

        return replaced;
    }


    static string addCustomAnimationMethods(string text)
    {
        const string template =
            @"        public static Tween Custom_TEMPLATE(Single startValue, Single endValue, float duration,  Action<Single> onValueChange, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Custom_TEMPLATE(new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom_TEMPLATE(Single startValue, Single endValue, float duration,  Action<Single> onValueChange, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) 
            => Custom_TEMPLATE(new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom_TEMPLATE(Single startValue, Single endValue, TweenSettings settings,  Action<Single> onValueChange) => Custom_TEMPLATE(new TweenSettings<float>(startValue, endValue, settings), onValueChange);
        public static Tween Custom_TEMPLATE(TweenSettings<float> settings,  Action<Single> onValueChange) {
            Assert.IsNotNull(onValueChange);
            if (settings.startFromCurrent) {
                UnityEngine.Debug.LogWarning(Constants.customTweensDontSupportStartFromCurrentWarning);
            }
            var tween = PrimeTweenManager.fetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Float;
            tween.customOnValueChange = onValueChange;
            tween.Setup(PrimeTweenManager.dummyTarget, ref settings.settings, _tween => {
                var _onValueChange = _tween.customOnValueChange as Action<Single>;
                var val = _tween.FloatVal;
                try {
                    _onValueChange(val);
                } catch (Exception e) {
                    UnityEngine.Debug.LogError($""Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}"", _tween.unityTarget);
                    _tween.EmergencyStop();
                }
            }, null, false);
            return PrimeTweenManager.Animate(tween);
        }
        public static Tween Custom_TEMPLATE<T>( T target, Single startValue, Single endValue, float duration,  Action<T, Single> onValueChange, Ease ease = Ease.Default, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class 
            => Custom_internal(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom_TEMPLATE<T>( T target, Single startValue, Single endValue, float duration,  Action<T, Single> onValueChange, Easing ease, int cycles = 1, CycleMode cycleMode = CycleMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class 
            => Custom_internal(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, cycles, cycleMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
        public static Tween Custom_TEMPLATE<T>( T target, Single startValue, Single endValue, TweenSettings settings,  Action<T, Single> onValueChange) where T : class 
            => Custom_internal(target, new TweenSettings<float>(startValue, endValue, settings), onValueChange);
        public static Tween Custom_TEMPLATE<T>( T target, TweenSettings<float> settings,  Action<T, Single> onValueChange) where T : class 
            => Custom_internal(target, settings, onValueChange);
        #if PRIME_TWEEN_EXPERIMENTAL
        public static Tween CustomAdditive<T>( T target, Single deltaValue, TweenSettings settings,  Action<T, Single> onDeltaChange) where T : class 
            => Custom_internal(target, new TweenSettings<float>(default, deltaValue, settings), onDeltaChange, true);
        #endif
        static Tween Custom_internal<T>( T target, TweenSettings<float> settings,  Action<T, Single> onValueChange, bool isAdditive = false) where T : class {
            Assert.IsNotNull(onValueChange);
            if (settings.startFromCurrent) {
                UnityEngine.Debug.LogWarning(Constants.customTweensDontSupportStartFromCurrentWarning);
            }
            var tween = PrimeTweenManager.fetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Float;
            tween.customOnValueChange = onValueChange;
            tween.isAdditive = isAdditive;
            tween.Setup(target, ref settings.settings, _tween => {
                var _onValueChange = _tween.customOnValueChange as Action<T, Single>;
                var _target = _tween.target as T;
                Single val;
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
                    UnityEngine.Debug.LogError($""Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}"", _tween.unityTarget);
                    _tween.EmergencyStop();
                }
            }, null, false);
            return PrimeTweenManager.Animate(tween);
        }
        static Tween animate(object target, ref TweenSettings<float> settings,  Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter) {
            var tween = PrimeTweenManager.fetchTween();
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Float;
            tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent);
            return PrimeTweenManager.Animate(tween);
        }
        static Tween animateWithIntParam( object target, int intParam, ref TweenSettings<float> settings,  Action<ReusableTween> setter,  Func<ReusableTween, ValueContainer> getter) {
            var tween = PrimeTweenManager.fetchTween();
            tween.intParam = intParam;
            tween.startValue.CopyFrom(ref settings.startValue);
            tween.endValue.CopyFrom(ref settings.endValue);
            tween.propType = PropType.Float;
            tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent);
            return PrimeTweenManager.Animate(tween);
        }";

        var types = new[] { typeof(float), typeof(Color), typeof(Vector2), typeof(Vector3), typeof(Vector4), typeof(Quaternion), typeof(Rect) };
        foreach (var type in types)
        {
            text += "\n\n";
            var isFloat = type == typeof(float);
            var replaced = template;
            replaced = replaced.Replace("Single", isFloat ? "float" : type.FullName);
            if (!isFloat)
            {
                replaced = replaced.Replace("TweenSettings<float>", $"TweenSettings<{type.FullName}>");
                replaced = replaced.Replace(".FloatVal", $".{type.Name}Val");
                replaced = replaced.Replace("Single val;", $"{type.Name} val;");
                replaced = replaced.Replace("PropType.Float;", $"PropType.{type.Name};");
            }

            replaced = replaced.Replace("Custom_TEMPLATE", "Custom");
            text += replaced;
        }

        return text;
    }


    static string populateTemplate(string str, MethodGenerationData data)
    {
        var methodName = data.methodName;
        var prefix = getMethodPrefix(data.dependency);
        if (prefix != null && !data.placeInGlobalScope)
        {
            methodName = prefix + methodName;
        }

        var targetType = data.targetType;
        if (string.IsNullOrEmpty(targetType))
        {
            str = str.Replace(" UnityEngine.Camera target, ", "")
                .Replace("METHOD_NAME(target, ", "METHOD_NAME(");
        }
        else
        {
            str = str.Replace("UnityEngine.Camera", targetType);
        }

        str = str.Replace("METHOD_NAME", methodName);
        if (data.propertyType != PropType.Float)
        {
            str = str.Replace("Single", data.propertyType.ToFullTypeName());
            str = str.Replace("_tween.FloatVal", $"_tween.{data.propertyType.ToString()}Val");
            str = str.Replace("TweenSettings<float>", $"TweenSettings<{data.propertyType.ToFullTypeName()}>");
        }

        return str;
    }

    [Serializable]
    internal class SpeedBasedMethodsGenerator
    {
        [SerializeField] Data[] data;

        [Serializable]
        class Data
        {
            [SerializeField] internal string methodName;
            [SerializeField] internal PropType propType;
            [SerializeField] internal string propName;
            [SerializeField] internal string speedParamName;
        }


        internal string Generate()
        {
            string result = "";
            foreach (var d in data)
            {
                const string template = @"
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
                UnityEngine.Debug.LogError($""Invalid speed provided to the Tween.{nameof(PositionAtSpeed)}() method: {speed}."");
                return default;
            }
            if (settings.startFromCurrent) {
                settings.startFromCurrent = false;
                settings.startValue = target.position;
            }
            settings.settings.duration = Extensions.CalcDistance(settings.startValue, settings.endValue) / speed;
            return Tween.Position(target, settings);
        }
";
                result += template.Replace("PositionAtSpeed", $"{d.methodName}AtSpeed")
                        .Replace("UnityEngine.Vector3", d.propType.ToFullTypeName())
                        .Replace("Tween.Position", $"{d.methodName}")
                        .Replace("target.position", $"target.{d.propName}")
                        .Replace("averageSpeed", $"{d.speedParamName}")
                    ;
            }

            return result;
        }
    }
}

[Serializable]
class MethodGenerationData
{
    [UsedImplicitly] public string name;
    public string methodName;
    public string targetType;
    public PropType propertyType;

    public string propertyName;

    public string propertyGetter;
    public string propertySetter;
    public string dotweenMethodName;
    public Dependency dependency;
    public bool placeInGlobalScope;
    public bool generateOnlyOverloads;
}

[PublicAPI]
enum Dependency
{
    None,
    UNITY_UGUI_INSTALLED,
    AUDIO_MODULE_INSTALLED,
    PHYSICS_MODULE_INSTALLED,
    PHYSICS2D_MODULE_INSTALLED,
    Camera,
    Material,
    Light,
    PRIME_TWEEN_EXPERIMENTAL,
    UI_ELEMENTS_MODULE_INSTALLED,
    TEXT_MESH_PRO_INSTALLED
}

static class Ext
{
    internal static string ToFullTypeName(this PropType type)
    {
        Assert.AreNotEqual(PropType.Float, type);
        if (type == PropType.Int)
        {
            return "int";
        }

        return $"UnityEngine.{type}";
    }
}