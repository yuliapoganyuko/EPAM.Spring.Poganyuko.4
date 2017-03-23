using System;

namespace Task2Logic
{
    /// <summary>
    /// Represents generic queue - data structure based on principle "First In First Out".
    /// </summary>
    /// <typeparam name="T"> Type of values.</typeparam>
    /// <remarks> Based on circular buffer (array).</remarks>
    public class CustomQueue<T>
    {
        #region Fields

        private T[] backingArray;
        private int first, last, size;

        #endregion
  

        #region Constructors

        /// <summary>
        /// Initializes new empty queue.
        /// </summary>
        /// <param name="capacity"> Capacity of the queue.</param>
        public CustomQueue(int capacity = 32)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException();
            backingArray = new T[capacity];
            first = 0;
            last = -1;
            size = 0; 
        }

        #endregion
        

        #region Properties

        /// <summary>
        /// Gets the number of values in the queue.
        /// </summary>
        public int Count
        {
            get
            {
                return size;
            }
        }

        #endregion


        #region Public methods

        /// <summary> Adds the value of T type to the queue.</summary>
        /// <param name="value"> The value to add.</param>
        /// <exception cref="T:System.ArgumentNullException"> The value is null.</exception>
        public void Enqueue(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            
            last = (last + 1) % backingArray.Length;
            backingArray[last] = value;
            if (last == first && size > 1)
            {
                first = (first + 1) % backingArray.Length;
                size--;
            }
            size++;
        }

        /// <summary> Gets the value from the top of the queue and removes it from the queue.</summary>
        /// <returns> The value from the top of the queue.</returns>
        /// <exception cref="T:System.InvalidOperationException"> The queue is empty.</exception>
        public T Dequeue()
        {
            if (size == 0)
                throw new InvalidOperationException();

            T value = backingArray[first];
            backingArray[first] = default(T);
            
            size--;
            if (size == 0)
            {
                first = 0;
                last = -1;
            }
            else
                first = (first + 1) % backingArray.Length;

            return value;
        }

        /// <summary> Gets the value from the top of the queue.</summary>
        /// <returns> The value from the top of the queue.</returns>
        /// <exception cref="T:System.InvalidOperationException"> The queue is empty.</exception>
        public T Peek()
        {
            if (size == 0)
                throw new InvalidOperationException();

            return backingArray[first];
        }
        #endregion
        
    }
}
