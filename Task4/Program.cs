using System;
using Task2;

namespace Task4 {
    class Program {
        static void Main(string[] args) {
            MyQueue queue = new MyQueue();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nДобавялем элементы:");
            Console.ForegroundColor = ConsoleColor.White;
            queue.Enqueue(new Complex(5));
            queue.Enqueue(new Complex(10, 10));
            queue.Enqueue(new Complex(20, 20));

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nDequeue():");
            Console.ForegroundColor = ConsoleColor.White;
            Complex firstObject = queue.Dequeue();
            Console.WriteLine($"Получен элемент: {firstObject.ToString()}");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPeek():");
            Console.ForegroundColor = ConsoleColor.White;
            Complex peek = queue.Peek();
            Console.WriteLine($"Получен элемент: {peek.ToString()}");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPrint():");
            Console.ForegroundColor = ConsoleColor.White;
            queue.Print();
        }
    }
}
