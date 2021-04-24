using System;
using System.Collections.Generic;
using Task2;

namespace Task4
{
    class MyQueue
    {
        private List<Complex> _numbers;
        private int _count;

        // Constructors
        public MyQueue()
        {
            _numbers = new List<Complex>();
            _count = 0;
        }

        // Methods
        public void Enqueue(Complex a)
        {
            _numbers.Add(a);
            _count++;
            Console.WriteLine($"Добавлен элемент {a.ToString()}, кол-во элементов: {_count.ToString()}");
        }

        public Complex Dequeue()
        {
            if (_count == 0)
            {
                return null;
            }

            Complex a = _numbers[0];
            _numbers.RemoveAt(0);
            _count--;
            Console.WriteLine($"Выдан элемент {a.ToString()}, кол-во элементов: {_count.ToString()}");

            return a;
        }

        public Complex Peek()
        {
            return (_count > 0) ? _numbers[0] : null;
        }

        public int Count()
        {
            return _count;
        }

        public void Print()
        {
            if (_count == 0)
            {
                Console.WriteLine("Очередь пуста");
                return;
            }
            Console.WriteLine("Содержимое очереди:");
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine($"{i}. {_numbers[i]}");
            }
        }

    }
}
