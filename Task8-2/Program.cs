using System;
using System.IO;
using System.Linq;

namespace Task8_2
{
    class Program
    {
        static void Main(string[] args)
        {

                if (args.Count() != 1)
                {
                    Console.WriteLine("Не найден параметр с адресом папки.");
                    return;
                }

                string path = args[0];

                Console.WriteLine("Path: {0}\n", path);

                string logFilePath = $"{path}\\log.cv";
                FileStream fileStream = File.Create(logFilePath);
                StreamWriter sw = new StreamWriter(fileStream);
                sw.WriteLine("Date, Time:\tName:\tChange Type:");
                sw.Close();

                using var watcher = new FileSystemWatcher(path);
                watcher.NotifyFilter = NotifyFilters.Attributes
                                     | NotifyFilters.CreationTime
                                     | NotifyFilters.DirectoryName
                                     | NotifyFilters.FileName
                                     | NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.Security
                                     | NotifyFilters.Size;

                watcher.Changed += (s, e) => OnChanged(s, e, logFilePath);
                watcher.Created += (s, e) => OnCreated(s, e, logFilePath);
                watcher.Deleted += (s, e) => OnDeleted(s, e, logFilePath);
                watcher.Renamed += (s, e) => OnRenamed(s, e, logFilePath);

                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;

                Console.ReadLine();
            }

            private static void OnChanged(object sender, FileSystemEventArgs e, string logFilePath)
            {
                if (e.ChangeType != WatcherChangeTypes.Changed || e.Name == "log.cv")
                {
                    return;
                }

                WriteToLog(logFilePath, e.Name, e.ChangeType);
            }

            private static void OnCreated(object sender, FileSystemEventArgs e, string logFilePath)
            {
                WriteToLog(logFilePath, e.Name, e.ChangeType);
            }

            private static void OnDeleted(object sender, FileSystemEventArgs e, string logFilePath)
            {
                if (e.Name == "log.cv")
                {
                    return;
                }
            }

            private static void OnRenamed(object sender, RenamedEventArgs e, string logFilePath)
            {
                WriteToLog(logFilePath, e.Name, e.ChangeType);
            }

            private static void WriteToLog(string logFilePath, string name, WatcherChangeTypes change)
            {
                using (StreamWriter sw = new StreamWriter(logFilePath, true))
                {
                    sw.WriteLine($"{DateTime.Now.ToString()}\t{name}\t{change.ToString().ToUpper()}");
                }
            }
    }
}
