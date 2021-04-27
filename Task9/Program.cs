using System;

namespace Task9 {
    class Program {
        static void Main(string[] args) {

            Func<double, double> function;
            double res;

            FunctionClass callback = new FunctionClass();
            callback.EpsEvent += PrintEpsilon;

            Console.WriteLine("Делегат. Функция cos(x).");
            function = new Func<double, double>(myFunc);
            res = callback.InverseFunctionOutput(-5, 5, 5, 0.001, myFunc);
            Console.WriteLine($"Результат = {res}\n");

            Console.WriteLine("Анонимный метод. Функция 8=x^2+sin(x-2).");
            function = delegate (double x) { return x * x + Math.Sin(x - 2) - 8; };
            res = callback.InverseFunctionOutput(2.5, 3.5, 8, 0.0001, function);
            Console.WriteLine($"Результат = {res}\n");

            Console.WriteLine("Лямбда выражение. Функция sin(x).");
            function = x => Math.Sin(x);
            res = callback.InverseFunctionOutput(0.1, 1.3, 0.5, 0.0001, function);
            Console.WriteLine($"Результат = {res}\n");

            callback.EpsEvent -= PrintEpsilon;
            Console.ReadKey();
        }

        private static double myFunc(double x) {
            return Math.Cos(x);
        }

        private static void PrintEpsilon(object sender, EpsilonEventArguments eventArgs) {
            Console.WriteLine($"Текущий eps = {eventArgs.Eps}");
        }

    }
}
