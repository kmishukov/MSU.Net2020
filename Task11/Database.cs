using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Linq;

namespace Task11 {
    class Database {
        public void Add(ref List<Employee> db) {
            Employee person = new Employee();

            Console.WriteLine("Добавление сотрудника.");
            Console.Write("Имя: ");
            person.Name = Console.ReadLine();
            Console.Write("Фамилия: ");
            person.Surname = Console.ReadLine();
            Console.Write("Отчество: ");
            person.Fathersname = Console.ReadLine();
            Console.Write("Телефон: ");
            person.Phone = Console.ReadLine();
            Console.Write("Адресс: ");
            person.Address = Console.ReadLine();

            db.Add(person);
        }

        public List<Employee> Load(string fileName) {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(fileName, FileMode.Open)) {
                {
                    return (List<Employee>)binaryFormatter.Deserialize(stream);
                }
            }
        }

        public void Save(List<Employee> db, string fileName) {
            using (FileStream fs = new FileStream(fileName, FileMode.Create)) {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, db);
            }
        }

        public void Find(ref List<Employee> db) {
            string searchStr;

            Console.Write("Введите параметр поиска:");
            searchStr = Console.ReadLine();

            List<Employee> resultList = new List<Employee>();
            resultList = db.Where(e => e.Name.Contains(searchStr) || e.Surname.Contains(searchStr) || e.Fathersname.Contains(searchStr) || e.Phone.Contains(searchStr) || e.Address.Contains(searchStr)).ToList();

            if (resultList.Count > 0) {
                Console.WriteLine("Результаты поиска:");
                foreach (Employee emp in resultList) {
                    Console.WriteLine(emp.ToString());
                }
            } else {
                Console.WriteLine("Поиск не дал результатов.");
            }

        }
    }
}
