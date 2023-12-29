using System;

namespace SmoothTween
{
    [Serializable]
    public partial struct Smooth
    {
        internal readonly int id;
        internal bool IsCreated => id != 0;
    }
}