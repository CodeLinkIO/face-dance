using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// An object pool for arrays, where you get objects from the pool based on the capacity you need
    /// </summary>
    /// <typeparam name="T">The data type of the array elements</typeparam>
    class BufferPool<T>
    {
        List<T[]> m_Buffers = new List<T[]>();

        /// <summary>
        /// Get or create a buffer of at least the capacity asked for.
        /// </summary>
        /// <param name="minimumCapacity">The required capacity</param>
        /// <returns>a buffer of equal or greater capacity than asked for</returns>
        public T[] Get(int minimumCapacity)
        {
            // the expected use case for this involves a relatively small number of recycled buffers,
            // so just do a linear search for a buffer that's close to the size asked for.
            var smallestDifference = int.MaxValue;
            var smallestDiffIndex = int.MinValue;
            for (var i = 0; i < m_Buffers.Count; i++)
            {
                var buffer = m_Buffers[i];
                if (buffer == null)
                    continue;
                var diff = buffer.Length - minimumCapacity;
                if (diff < 0)
                    continue;
                if (diff == 0)
                {
                    // if we found an exact size match, our search is done
                    m_Buffers.RemoveAt(i);
                    return buffer;
                }
                if (diff < smallestDifference)
                {
                    smallestDifference = diff;
                    smallestDiffIndex = i;
                }
            }

            // if we didn't find any buffers of the necessary or greater capacity, create a new one
            if (smallestDiffIndex == int.MinValue)
                return new T[minimumCapacity];

            var chosenBuffer = m_Buffers[smallestDiffIndex];
            m_Buffers.RemoveAt(smallestDiffIndex);
            return chosenBuffer;
        }

        public void Recycle(T[] buffer)
        {
            if (buffer == null)
                return;
            Array.Clear(buffer, 0, buffer.Length);
            m_Buffers.Add(buffer);
        }
    }
}
