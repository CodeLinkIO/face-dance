using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Settings;
using UnityEngine;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Stores a record of all valid assignment combinations for a given context set.
    /// </summary>
    class SetMatchesBuffer : IDisposable
    {
        /// <summary>
        /// Each SetSize-count slice of this array, where the first index 'n' of the slice is less than
        /// Count * SetSize, represents a valid combination of assignments for the members of a context set.
        /// index n is local member index 0, n + 1 is local member index 1, and so on.
        /// </summary>
        public int[] DataIds;

        /// <summary>
        /// Each index 'n' in this, where n less than Count, represents the reduced score
        /// of the assignment combination found from DataIds[n * SetSize] to DataIds[n * SetSize + SetSize]
        /// </summary>
        public float[] Ratings;

        /// <summary>
        /// The number of valid entries in currently in the buffer
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// The number of members in the set
        /// </summary>
        public int SetSize { get; }

        /// <summary>
        /// The number of valid combinations that can be stored by this buffer before resizing
        /// </summary>
        public int Capacity { get; private set; }

        public SetMatchesBuffer(int setSize, int capacity)
        {
            SetSize = setSize;
            Capacity = capacity;
            DataIds = Pools.IntBuffers.Get(capacity * setSize);
            Ratings = Pools.FloatBuffers.Get(capacity);
        }

        ~SetMatchesBuffer()
        {
            Dispose();
        }

        public void Dispose()
        {
            Pools.IntBuffers?.Recycle(DataIds);
            Pools.FloatBuffers?.Recycle(Ratings);
        }

        public void Reset()
        {
            // We don't clear the arrays when we reset - we just overwrite the previous data next time
            Count = 0;
        }

        // This function uses int-float KVPs, but ignores the values.
        // That's because the combination coming from the enumerator is in this kvp-array format
        /// <summary>
        /// Add a validated assignment set to the buffer
        /// </summary>
        /// <param name="combination">The set of keys to add.  Only keys are used, values are ignored</param>
        /// <param name="rating">The rating for the set of keys</param>
        public void Add(KeyValuePair<int, float>[] combination, float rating)
        {
            if (Count >= Capacity)
            {
                const int growFactor = 2;
                Capacity *= growFactor;
                Array.Resize(ref Ratings, Capacity);
                Array.Resize(ref DataIds, SetSize * Capacity);
            }

            var start = Count * SetSize;
            for (var i = 0; i < combination.Length; i++)
            {
                DataIds[start + i] = combination[i].Key;
            }

            Ratings[Count] = rating;
            Count++;
        }

        /// <summary>
        /// Find the highest rating in the buffer, and all indices that had that rating
        /// </summary>
        /// <param name="tieIndicesBuffer">A buffer to add tie indices to</param>
        /// <returns>A key-value pair where the key is the highest rating, and the value is the count of ties</returns>
        public KeyValuePair<float, int> FindHighestRated(ref int[] tieIndicesBuffer)
        {
            if(tieIndicesBuffer.Length < Count)
                Array.Resize(ref tieIndicesBuffer, Count + MARSMemoryOptions.ResizeHeadroom);

            var highestRating = 0f;
            var tieCounter = 0;
            for (var i = 0; i < Count; i++)
            {
                var rating = Ratings[i];
                if (rating > highestRating)
                {
                    highestRating = rating;
                    tieCounter = 1;
                    tieIndicesBuffer[0] = i;
                }
                // exact fp comparison is intentional for now - we may want an epsilon for considering it a tie
                else if (rating == highestRating)
                {
                    tieIndicesBuffer[tieCounter] = i;
                    tieCounter++;
                }
            }

            return new KeyValuePair<float, int>(highestRating, tieCounter);
        }

        /// <summary>
        /// Find the highest rating in the buffer, and all indices that had that rating, and choose between them
        /// </summary>
        /// <param name="tieIndicesBuffer">A buffer to add tie indices to</param>
        /// <param name="behavior"></param>
        /// <returns>
        /// A key-value pair where the key is the chosen index into the ratings buffer,
        /// and the value is the highest rating
        /// </returns>
        public KeyValuePair<int, float> ChooseHighestRated(int[] tieIndicesBuffer, TieChoiceBehavior behavior)
        {
            var ratingToCount = FindHighestRated(ref tieIndicesBuffer);

            var chosenIndex = ratingToCount.Value > 1 && behavior == TieChoiceBehavior.Random
                ? tieIndicesBuffer[UnityEngine.Random.Range(0, ratingToCount.Value)]
                : tieIndicesBuffer[0];

            return new KeyValuePair<int, float>(chosenIndex, ratingToCount.Key);
        }

        public void CombinationAtRatingIndex(int index, int[] combinationOutput)
        {
            var start = index * SetSize;
            for (var i = 0; i < SetSize; i++)
            {
                combinationOutput[i] = DataIds[start + i];
            }
        }
    }
}
