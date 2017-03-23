using System;
using Task2Logic;

namespace Task2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomQueue<int> queue = new CustomQueue<int>(3);
            Console.WriteLine("The instanse of CustomQueue created (capacity = 3)");
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Console.WriteLine("Enqueue values 1, 2, 3, 4");
            Console.WriteLine($"Dequeued value: {queue.Dequeue()}");
            queue.Enqueue(5);
            Console.WriteLine("Enqueue value 5");
            Console.WriteLine($"Dequeued values: {queue.Dequeue()}, {queue.Dequeue()}, {queue.Dequeue()}");
            Console.ReadKey();
        }
    }
}
