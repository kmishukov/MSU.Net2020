using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_2 {
    public class Tetrahedron : Body3D {

        double _a;

        public Tetrahedron() {
            _a = 3;
        }

        public Tetrahedron(double a) {
            if (a <= 0) {
                Console.WriteLine("Сторона не может быть <= 0, выбрано значение по умолчанию 3.");
                _a = 3;
            } else {
                _a = a;
            }
        }

        // Override;
        public override double Area() {
            return Math.Sqrt(3) * Math.Pow(_a, 2);
        }

        public override double SidesLength() {
            return _a * 6;
        }

        public override double Volume() {
            return Math.Pow(_a, 3) / (6 * Math.Sqrt(2));
        }
    }
}
