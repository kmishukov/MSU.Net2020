using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_2 {
    public class Sphere : Body3D {

        double _r;

        public Sphere() {
            _r = 1;
        }

        public Sphere(double r) {
            if (r <= 0) {
                _r = 1;
            } else {
                _r = r;
            }
        }

        // Override;
        public override double Area() {
            return 4 * Math.PI * Math.Pow(_r,2);
        }

        public override double Volume() {
            return 4 / 3 * Math.PI * Math.Pow(_r, 3);
        }

        public override double SidesLength() {
            return 0;
        }

    }
}
