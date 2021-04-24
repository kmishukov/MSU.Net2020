using System;
using Task2;

namespace Task4 {
    class MyQueue {

        private Node _head;
        private Node _tail;
        private int _count;

        // Constructors
        public MyQueue() {
            _head = null;
            _tail = null;
            _count = 0;
        }

        /// <summary>
        /// Добавляет комплексное число в конец очереди.
        /// </summary>
        public void Enqueue(Complex a) {
            Node newNode = new Node(a);
            if (_head == null) {
                _head = newNode;
                _tail = newNode;
            } else {
                _tail.next = newNode;
                _tail = newNode;
            }
            _count++;
            Console.WriteLine($"Добавлен элемент {a.ToString()}, кол-во элементов: {_count.ToString()}");
        }

        /// <summary>
        /// Выдаёт комплексное число из начала очереди и удаляет его из очереди.
        /// </summary>
        public Complex Dequeue() {
            if (_head == null) {
                return null;
            }

            Complex a = _head.value;
            _head = _head.next;
            _count--;
            Console.WriteLine($"Выдан элемент {a.ToString()}, кол-во элементов: {_count.ToString()}");

            return a;
        }

        /// <summary>
        /// Возвращает комплексное число, находящееся в начале очереди (не удаляя его).
        /// </summary>
        public Complex Peek() {
            if (_head == null) {
                return null;
            }
            return _head.value;
        }

        /// <summary>
        /// Возвращает кол-во элементов в очереди.
        /// </summary>
        public int Count() {
            return _count;
        }

        /// <summary>
        /// Печать содержимого очереди.
        /// </summary>
        public void Print() {
            if (_count == 0) {
                Console.WriteLine("Очередь пуста");
                return;
            }
            Console.WriteLine("Содержимое очереди:");

            Node currentNode = _head;
            while (currentNode != null) {
                Console.WriteLine(currentNode.value.ToString());
                currentNode = currentNode.next;
            }
        }

    }
}
