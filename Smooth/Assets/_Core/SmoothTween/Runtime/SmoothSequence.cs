using System;

namespace SmoothTween
{
    [Serializable]
    public struct SmoothSequence
    {
        internal readonly Smooth root;
        internal bool IsCreated => root.IsCreated;
    }
}