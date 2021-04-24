using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex a = new Complex(0, 1);
            Complex b = new Complex(0, 0);

            Console.WriteLine(a.Equals(b) ? "Equals" : "Not equals");

            // Complex b = new Complex(1, 1);
            // Complex c = a + b;
            // Complex d = c - new Complex(5, 6);
            // Complex e = (d + new Complex(1, 0)) * a;
            //Console.WriteLine(new Complex(0));
            Console.ReadKey();
        }
    }
}
