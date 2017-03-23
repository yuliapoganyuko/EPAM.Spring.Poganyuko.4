using System;

namespace Task1Logic
{
    /// <summary>
    /// Provides functionality of merge sort.
    /// </summary>
    public static class MergeSort
    {
        #region Public methods

        /// <summary>
        /// Sorts array.
        /// </summary>
        /// <param name="array"> Input array</param>
        public static void Sort(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            Sort(array, 0, array.Length - 1);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Sorts array dividing it into parts. Part is determined by first and last positions in array
        /// </summary>
        /// <param name="array">Input array</param>
        /// <param name="firstPosition">Index of first position of part in input array</param>
        /// <param name="lastPosition">Index of last position of part in input array</param>
        private static void Sort(int[] array, int firstPosition, int lastPosition)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (firstPosition < 0 || firstPosition > array.Length - 1 || firstPosition > lastPosition
                || lastPosition < 0 || lastPosition > array.Length - 1)
                throw new ArgumentOutOfRangeException();

            if (firstPosition < lastPosition)
            {
                int middlePosition = (firstPosition + lastPosition) / 2;
                Sort(array, firstPosition, middlePosition);
                Sort(array, middlePosition + 1, lastPosition);
                Merge(array, firstPosition, middlePosition, lastPosition);
            }
        }

        /// <summary>
        /// Merges two successive sorted parts of array. 
        /// </summary>
        /// <param name="array">Input array</param>
        /// <param name="firstPosition">Index of first position of first part to merge in input array</param>
        /// <param name="middlePosition">Index of last position of first part to merge in input array</param>
        /// <param name="lastPosition">Index of last position of second part to merge in input array</param>
        private static void Merge(int[] array, int firstPosition, int middlePosition, int lastPosition)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (firstPosition < 0 || firstPosition > array.Length - 1 || firstPosition > lastPosition
                || lastPosition < 0 || lastPosition > array.Length - 1 || middlePosition > lastPosition
                || middlePosition < 0 || middlePosition > array.Length - 1 || middlePosition < firstPosition)
                throw new ArgumentOutOfRangeException();

            int[] temporaryArray = new int[array.Length];

            for (int i = firstPosition; i <= lastPosition; i++)
                temporaryArray[i] = array[i];

            int currentLeft = firstPosition, currentRight = middlePosition + 1;
            int currentPosition = firstPosition;

            while (currentLeft <= middlePosition && currentRight <= lastPosition)
            {
                if (temporaryArray[currentLeft] <= temporaryArray[currentRight])
                {
                    array[currentPosition] = temporaryArray[currentLeft];
                    currentLeft++;
                }
                else
                {
                    array[currentPosition] = temporaryArray[currentRight];
                    currentRight++;
                }
                currentPosition++;
            }

            int remaining = middlePosition - currentLeft;
            for (int i = 0; i <= remaining; i++)
                array[currentPosition + i] = temporaryArray[currentLeft + i];
        }

        #endregion

    }

}
