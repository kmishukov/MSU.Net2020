using System;

namespace Task2 {
    public class Complex {
        private double _re, _im;

        // Properties
        public double Re {
            get {
                return _re;
            }
            set {
                _re = Re;
            }
        }

        public double Im {
            get {
                return _im;
            }
            set {
                _im = Im;
            }
        }

        public double Mod {
            get {
                return Math.Sqrt(_re * _re + _im * _im);
            }
        }

        public double Arg {
            get {
                if (_re == 0 && _im == 0) {
                    return 0;
                } else if (_re == 0) {
                    return (_im > 0) ? Math.PI / 2 : -Math.PI / 2;
                } else if (_im == 0) {
                    return (_re > 0) ? 0 : Math.PI;
                }

                if (_re > 0) {
                    return Math.Atan(_im / _re);
                } else {
                    if (_im > 0) {
                        return Math.PI + Math.Atan(_im / _re);
                    } else {
                        return -Math.PI + Math.Atan(_im / _re);
                    }
                }
            }
        }

        // Constructors
        public Complex(double re, double im) {
            this._re = re;
            this._im = im;
        }

        public Complex(double re) {
            this._re = re;
            this._im = 0;
        }

        public static Complex withModule(double m, double arg) {
            return new Complex(m * Math.Cos(arg), m * Math.Sin(arg));
        }

        // Override
        public static Complex operator +(Complex a, Complex b) {
            return new Complex(re: a.Re + b.Re, im: a.Im + b.Im);
        }

        public static Complex operator -(Complex a, Complex b) {
            return new Complex(re: a.Re - b.Re, im: a.Im - b.Im);
        }

        public static Complex operator *(Complex a, Complex b) {
            double re = a.Re * b.Re - a.Im * b.Im;
            double im = a.Re * b.Im + b.Re * b.Im;
            return new Complex(re: re, im: im);
        }

        public static Complex operator /(Complex a, Complex b) {
            double re = (a.Re * b.Re + a.Im * b.Im) / (b.Re * b.Re + b.Im * b.Im);
            double im = (a.Im * b.Re - a.Re * b.Im) / (b.Re * b.Re + b.Im * b.Im);
            return new Complex(re: re, im: im);
        }

        public static bool operator ==(Complex a, Complex b) {
            if (ReferenceEquals(a, null)) {
                return ReferenceEquals(b, null);
            }
            return (a.Equals(b));
        }

        public static bool operator !=(Complex a, Complex b) {
            return !(a == b);
        }

        // TypeCasting
        public static explicit operator double(Complex a) {
            if (a == null) return double.NaN;
            return a.Re;
        }
        public static explicit operator Complex(double a) {
            return new Complex(a);
        }

        public override string ToString() {
            string re = (this.Re != 0) ? this.Re.ToString() : "";
            string im;

            if (this.Im == 0) {
                im = "";
                if (re.Length == 0) return "0";
            } else if (Math.Abs(this.Im) == 1) {
                im = (this.Im > 0) ? "i" : "-i";
            } else {
                im = (re == "") ? this.Im.ToString() + "i" : ((this.Im > 0) ? "+" : "") + this.Im.ToString() + "i";
            }

            return re + im;
        }

        public bool Equals(Complex other) {
            return (_re == other.Re) && (_im == other.Im);
        }

    }
}
