using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {

            var nameStack = new MyStack<string>();

            nameStack.Push("Alex");
            nameStack.Push("Kostya");
            nameStack.Push("Christine");

            string topName = nameStack.Top();
            Console.WriteLine($"Top: {topName}, total: {nameStack.Count()}");
            string removedName = nameStack.Pop();
            Console.WriteLine($"Removed: {topName}");
            string topName2 = nameStack.Top();
            Console.WriteLine($"Top: {topName2},  total: {nameStack.Count()}");


            var numbers = new MyStack<int>();
            numbers.Push(5);


        }
    }
}
