using Task2;

namespace Task4 {
    class Node {
        private Node _next;
        private Complex _value;
        public Node(Complex c) {
            _value = c;
            _next = null;
        }

        public Node next {
            get {
                return _next;
            }
            set {
                _next = value;
            }
        }

        public Complex value {
            get {
                return _value;
            }
        }
    }
}
