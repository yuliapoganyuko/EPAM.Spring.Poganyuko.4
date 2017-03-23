using System;
using Task1Logic;

namespace Task1Console
{
    class Program
    {
        #region Public methods

        static void Main(string[] args)
        {
            int[] array = GetArray();
            MergeSort.Sort(array);
            Console.Write("Sorted array: ");
            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]} ");
            Console.ReadKey();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Gets the array of integers.
        /// </summary>
        /// <returns>The array consisting of integers.</returns>
        private static int[] GetArray()
        {
            Console.WriteLine("Enter the number of array elements:");
            int count = GetInt(true);

            int[] sortedArray = new int[count];

            Console.WriteLine("Enter array elements:");
            for (int index = 0; index < count; index++)
            {
                sortedArray[index] = GetInt(false);
            }
            return sortedArray;
        }

        /// <summary>
        /// Gets the integer value.
        /// </summary>
        /// <param name="isPositiveNumber">Boolean flag showing if the integer value should be positive.</param>
        /// <returns>The integer value.</returns>
        private static int GetInt(bool isPositiveNumber)
        {
            int number;
            while (!Int32.TryParse(Console.ReadLine(), out number) || (isPositiveNumber && number <= 0))
            {
                Console.WriteLine("Check your input");
            }
            return number;
        }

        #endregion
    }
}
