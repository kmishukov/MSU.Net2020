using System;
using System.IO;
using System.Collections.Generic;

namespace Task11 {
    class Program {
        static void Main(string[] args) {

            string dbPath = "..\\..\\db.bin";
            if (!File.Exists(dbPath)) {
                File.Create(dbPath);
            } 

            List<Employee> employees;
            Database db = new Database();

            try {
                employees = db.Load(dbPath);
            } catch {
                employees = new List<Employee>();
            }

            Console.WriteLine("########################################");
            Console.WriteLine("1. Добавить сотрудника\n2. Поиск сотрудника\nQ/q - выход");
            Console.WriteLine("########################################");
            ConsoleKeyInfo input;
            do {
                Console.Write("Выберите [1 or 2 | Q]: ");
                input = Console.ReadKey();
                Console.WriteLine();
                try {
                    switch (input.Key) {
                        case ConsoleKey.D1:
                            db.Add(ref employees);
                            break;
                        case ConsoleKey.D2:
                            db.Find(ref employees);
                            break;
                    }
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            } while (input.Key != ConsoleKey.Q);

            Console.WriteLine("Сохранение..");
            db.Save(employees, dbPath);

            Console.ReadKey();
        }
    }
}
