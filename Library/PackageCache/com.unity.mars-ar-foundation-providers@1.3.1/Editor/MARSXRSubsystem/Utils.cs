using System;

namespace Unity.MARS.XRSubsystem
{
    static class Utils
    {
        internal static void EnsureCapacity<T>(ref T[] buffer, int neededCapacity)
        {
            if(buffer.Length < neededCapacity)
                Array.Resize(ref buffer, neededCapacity);
        }
    }
}
