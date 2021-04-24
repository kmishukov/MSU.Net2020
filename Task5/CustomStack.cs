using System;
using System.Collections.Generic;
using System.Text;

namespace Task5 {
    class CustomStack<T> where T : ICloneable {
        public class Node {
            private Node _next;
            private T _value;

            public Node(T value) {
                this._value = value;
            }

            public Node next {
                get {
                    return _next;
                }
                set {
                    _next = value;
                }
            }

            public T value {
                get {
                    return _value;
                }
            }
        }

        private Node _head;
        private int _count;
        public CustomStack() {
            _head = null;
            _count = 0;
        }

        public void Push(T element) {
            if (_head == null) {
                _head = new Node(element);
            } else {
                Node newNode = new Node(element);
                newNode.next = newNode;
                _head = newNode;
            }
            _count++;
        }

        public T Pop() {
            if (_head == null) {
                Console.WriteLine("Ошибка: cтэк пуст.");
                throw new NullReferenceException();
            } else {
                T value = _head.value;
                if (_head.next == null) {
                    _head = null;
                } else {
                    _head = _head.next;
                }
                _count--;
                return value;
            }
        }

        public int Count() {
            return _count;
        }

        public void Print() {
            if (_head == null) {
                Console.WriteLine("Стэк пуст");
            } else {
                Node currentNode = _head;
                while (currentNode != null) {
                    Console.WriteLine(currentNode.value);
                    currentNode = currentNode.next;
                }
            }
        }

        private T Clone(T what) {
            return (T)what.Clone();
        }

        public T Top() {
            if (_head == null) {
                Console.WriteLine("Ошибка: cтэк пуст.");
                throw new NullReferenceException();
            } else {
                return Clone(_head.value);
            }
        }

    }
}
