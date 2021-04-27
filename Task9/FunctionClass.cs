using System;
using System.Collections.Generic;
using System.Text;

namespace Task9 {
    class FunctionClass {

        public double InverseFunctionOutput(double a, double b, double y, double eps, Func<double, double> function) {
            
            double tmp;
            double ftmp;          
            double fa;
            double res;

            fa = function(a) - y;

            do {
                tmp = (a + b) / 2;
                ftmp = function(tmp) - y;
                if (fa * ftmp < 0) {
                    b = tmp;
                } else {
                    a = tmp;
                    fa = ftmp;
                }
                OnEpsReached(b - a);
            } while (b - a > eps);
            res = a;
            return res;
        }

        public event EventHandler<EpsilonEventArguments> EpsEvent;

        private void OnEpsReached(double eps) {
            EpsEvent?.Invoke(this, new EpsilonEventArguments(eps));
        }

    }
}
