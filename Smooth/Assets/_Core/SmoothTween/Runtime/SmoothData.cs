using System;
using UnityEngine;

namespace SmoothTween
{
    [Serializable]
    public struct SmoothData
    {
        public AnimationCurve customEase;
        public bool useUnscaledTime;
        public float startDelay;
    }
}