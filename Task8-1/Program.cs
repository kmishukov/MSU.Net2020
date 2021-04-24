using System;
using System.IO;
using System.Linq;

namespace Task8_1
{
    class Program
    {
        static void Main(string[] args)
        {
                string fileAdress;

                if (args.Count() == 1)
                {
                    Console.WriteLine("Обработка файла: {0}\n", args[0]);
                    fileAdress = args[0];
                }
                else
                {
                    Console.WriteLine("Не найден параметр с адресом файла.");
                    return;
                }

                using (StreamReader sr = new StreamReader(fileAdress))
                {
                    int lineCounter = 0;
                    int correctMailCounter = 0;
                    int correctPhoneCounter = 0;

                    while (!sr.EndOfStream)
                    {
                        string textLine = sr.ReadLine();
                        if (lineCounter > 0)
                        {
                            string[] splitContent = textLine.Split('\t');
                            if (isCorrectEMailAddress(splitContent[1])) correctMailCounter++;
                            if (isCorrectPhoneNumber(splitContent[2])) correctPhoneCounter++;
                        }
                        lineCounter++;
                    }
                    Console.WriteLine($"Количество сотрудников: {lineCounter - 1}");
                    Console.WriteLine($"Количество правильных телефонов: {correctPhoneCounter}");
                    Console.WriteLine($"Количество правильных e-mail: {correctMailCounter}");

                }

                bool isCorrectEMailAddress(string email)
                {
                    string trimmed = email.Trim("\"".ToCharArray());
                    try
                    {
                        var addr = new System.Net.Mail.MailAddress(trimmed);
                        return addr.Address == trimmed;
                    }
                    catch
                    {
                        return false;
                    }
                }

                bool isCorrectPhoneNumber(string phone)
                {
                    return phone.All(Char.IsDigit);
                }

        }
    }
}
