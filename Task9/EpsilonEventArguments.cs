using System;
using System.Collections.Generic;
using System.Text;

namespace Task9 {
    class EpsilonEventArguments: EventArgs {
        private double _epsilon;

        public EpsilonEventArguments(double arg) {
            _epsilon = arg;
        }

        public double Eps {
            get {
                return _epsilon;
            }

            set {
                _epsilon = value;
            }
        }
    }
}
