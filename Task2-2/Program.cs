using System;

namespace Task2_2 {
    class Program {
        static void Main(string[] args) {

            Body3D[] geometryFigures = new Body3D[3];

            // Sphere
            Body3D sphere = new Sphere(5);
            Console.WriteLine("-Создаём шар c радиусом 5.");
            Console.WriteLine("Объем шара: " + sphere.Volume());
            Console.WriteLine("Площадь шара: " + sphere.Area());
            geometryFigures[0] = sphere;

            // Cuboid
            Body3D cuboid = new Cuboid(10, 5, 3);
            Console.WriteLine("\n-Создаём параллелепипед прямоугольный cо сторонами 10, 5, 3.");
            Console.WriteLine("Объем параллелепипеда: " + cuboid.Volume());
            Console.WriteLine("Сумма длин рёбер параллелепипеда: " + cuboid.SidesLength());
            Console.WriteLine("Площадь параллелепипеда: " + cuboid.Area());
            geometryFigures[1] = cuboid;

            // Tetrahedron
            Body3D tetr = new Tetrahedron(10);
            Console.WriteLine("\n-Создаём тетраэдр со стороной 10.");
            Console.WriteLine("Объем тетраэдра: " + tetr.Volume());
            Console.WriteLine("Сумма длин рёбер тетраэдра: " + tetr.SidesLength());
            Console.WriteLine("Площадь тетраэдра: " + tetr.Area());
            geometryFigures[2] = tetr;


            double sumVolume = 0;
            double sumArea = 0;
            for (int i = 0; i < geometryFigures.Length; i++) {
                sumVolume += geometryFigures[i].Volume();
                sumArea += geometryFigures[i].Area();
            }

            Console.WriteLine("\nОбщий объем: " + sumVolume);
            Console.WriteLine("Общая площадь: " + sumArea);

            Console.ReadKey();
        }
    }
}
