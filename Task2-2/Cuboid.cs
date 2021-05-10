using System;

namespace Task2_2 {
    public class Cuboid : Body3D {

        double _x, _y, _z;

        public Cuboid() {
            _x = 5;
            _y = 3;
            _z = 2;
        }

        public Cuboid(double x, double y, double z) {
            if (x <= 0 || y <= 0 || z <= 0) {
                Console.WriteLine("Значение стороны не может быть <=0, размеры заданы по умолчанию 5,3,2.");
                _x = 5;
                _y = 3;
                _z = 2;
            } else {
                _x = x;
                _y = y;
                _z = z;
            }
        }

        // Override;
        public override double Area() {
            return 2 * (_x * _y + _x * _z + _y * _z);
        }

        public override double SidesLength() {
            return (_x + _y + _z) * 4;
        }

        public override double Volume() {
            return _x * _y * _z;
        }
    }
}
