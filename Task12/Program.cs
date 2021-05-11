using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using FabulousCity.DataAccess;

namespace Task12 {
    class Program {

        const int portionSize = 100000;
        const string file1 = "output.txt";
        const string file2 = "output2.txt";

        static void SingleThread() {
            using (StreamWriter sw = new StreamWriter(file1)) {
                PersonProvider provider = new PersonProvider();
                Person[] persons = provider.GetPersons(1, portionSize);
                while (persons.Length > 0) {
                    for (int i = 0; i < persons.Length; i++) {
                        sw.WriteLine(persons[i]);
                    }
                    Person lastP = persons[persons.Length - 1];
                    persons = provider.GetPersons(lastP.Id + 1, portionSize);
                }
            }
        }

        static object _lockObject = new object();
        static Queue<Person[]> _pQueue = new Queue<Person[]>();
        static int _maxQueueSize = 1;
        static bool _personsReadEnded = false;

        static void GetPersons() {
            PersonProvider provider = new PersonProvider();
            Person[] persons = provider.GetPersons(1, portionSize);
            while (persons.Length > 0) {
                lock (_lockObject) {
                    if (_pQueue.Count < _maxQueueSize) {
                        _pQueue.Enqueue(persons);
                        Person lastP = persons[persons.Length - 1];
                        persons = provider.GetPersons(lastP.Id + 1, portionSize);
                    }
                }
            }
            lock (_lockObject) {
                _personsReadEnded = true;
            }
        }

        static void WritePersons() {
            using (StreamWriter sw = new StreamWriter(file2)) {
                Person[] persons = null;
                while (_personsReadEnded == false || _pQueue.Count != 0) {
                    lock (_lockObject) {
                        if (_pQueue.Count > 0) {
                            persons = _pQueue.Dequeue();
                        }
                    }
                    if (persons is not null) {
                        foreach (Person person in persons) {
                            sw.WriteLine(person);
                        }
                        persons = null;
                    }
                }
            }
        }

        static void LaunchSingleThread() {
            Console.WriteLine("Запуск последовательного выполнения.");
            Stopwatch t = new Stopwatch();
            t.Start();
            SingleThread();
            t.Stop();
            Console.WriteLine("\nЗатраченное время: " + t.ElapsedMilliseconds / 1000 + " сек");
        }

        static void LaunchMultiThread() {
            Console.WriteLine("\nЗапуск параллельного выполнения.");
            Stopwatch t = new Stopwatch();
            Thread getP = new Thread(GetPersons);
            Thread writeP = new Thread(WritePersons);
            t.Start();
            getP.Start();
            writeP.Start();
            getP.Join();
            writeP.Join();
            t.Stop();
            Console.WriteLine("\nЗатраченное время: " + (t.ElapsedMilliseconds / 1000) + " сек");
        }

        static void Main(string[] args) {
            LaunchSingleThread();
            LaunchMultiThread();
        }
    }
}
