using System;
using System.Reflection;
using System.Numerics;
using System.IO;

namespace Task10 {
    class Program {
        static void Main(string[] args) {

            string modulesDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + "\\Task2\\bin\\Debug\\net5.0\\";
            string name = "Task2.dll";
            string path = Path.Combine(modulesDir, name);

            if (!File.Exists(path)) {
                Console.WriteLine("Не удалось открыть файл Task2.dll");
            }

            Assembly assembly = Assembly.LoadFrom(path);
            Type myComplex = assembly.GetType("Task2.Complex");

            Console.WriteLine("Без dynamic:");
            object x = Activator.CreateInstance(myComplex, 2, 3);
            object y = Activator.CreateInstance(myComplex, 14 * Math.Cos(Math.PI / 4.0), 14 * Math.Sin(Math.PI / 4.0));
            MethodInfo Addition = myComplex.GetMethod("op_Addition");
            MethodInfo Multiply = myComplex.GetMethod("op_Multiply");
            MethodInfo Division = myComplex.GetMethod("op_Division");
            MethodInfo ToString = myComplex.GetMethod("ToString");
            PropertyInfo Modulus = myComplex.GetProperty("Mod");
            PropertyInfo Argument = myComplex.GetProperty("Arg");

            object tmp1 = Addition.Invoke(null, new object[] { x, y });
            object tmp2 = Multiply.Invoke(null, new object[] { tmp1, tmp1 });
            object tmp3 = Activator.CreateInstance(myComplex, (double)27);
            object z = Division.Invoke(null, new object[] { tmp2, tmp3 });
            Console.WriteLine($"Обычный вид: {ToString.Invoke(z, new object[] { })}");
            Console.WriteLine($"Тригонометрический вид: {Modulus.GetValue(z)}(cos({Argument.GetValue(z)})+isin({Argument.GetValue(z)}))");

            Console.WriteLine("\nС dynamic:");
            dynamic a = Activator.CreateInstance(myComplex, 4, 1);
            dynamic b = Activator.CreateInstance(myComplex, 2 * Math.Cos(Math.PI / 3.0), 2 * Math.Sin(Math.PI / 3.0));
            dynamic tmp = a * a + b * b;
            dynamic c = (tmp * tmp) / (3 * b);
            Console.WriteLine($"Обычный вид: {c.ToString()}");
            Console.WriteLine($"Тригонометрический вид: {c.Mod}(cos({c.Arg})+isin({c.Arg}))");

            Console.ReadKey();
        }
    }
}
