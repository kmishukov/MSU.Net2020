using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomStack<string> namesStack = new CustomStack<string>();

            namesStack.Push("Alex");
            namesStack.Push("Kostya");
            namesStack.Push("Christine");

            string topName = namesStack.Top();
            Console.WriteLine($"Top: {topName}, total: {namesStack.Count()}");
            string removedName = namesStack.Pop();
            Console.WriteLine($"Removed: {topName}");
            string topName2 = namesStack.Top();
            Console.WriteLine($"Top: {topName2},  total: {namesStack.Count()}");
        }
    }
}
