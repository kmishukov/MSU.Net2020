using System;
using System.Diagnostics;

namespace Task1
{
    class Program
    {
        const int N = 1000; // Размер матриц
        static void Main(string[] args)
        {
            double[,] a, b, c; // Определение прямоугольных массивов
            // Создание массивов
            a = new double[N, N];
            b = new double[N, N];
            c = new double[N, N];
            // Заполнение матриц
            Random random = new Random();
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    a[i, j] = random.NextDouble();
                    b[i, j] = random.Next();
                }
            // Простое засечение времени
            Stopwatch sw = Stopwatch.StartNew(); // Запускает таймер
            // Умножение матриц
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    double cc = 0;
                    for (int k = 0; k < N; k++)
                        cc += a[i, k] * b[k, j];
                    c[i, j] = cc;
                }
            sw.Stop(); // Останавливает таймер
            long duration = sw.ElapsedMilliseconds; // Количество миллисекунд
            Console.WriteLine("Время умножения прямоугольных массивов " + duration + " мс");
            double performance = (N * N * N) / 2 / duration;
            Console.WriteLine("Производительность " + performance + " ГФлопс");

            // Вложенные массивы
            double[][] matrixA, matrixB, matrixC;
            matrixA = new double[N][];
            matrixB = new double[N][];
            matrixC = new double[N][];

            Random random2 = new Random();
            for (int i = 0; i < N; i++)
            {
                matrixA[i] = new double[N];
                matrixB[i] = new double[N];
                matrixC[i] = new double[N];
                for (int j = 0; j < N; j++)
                {
                    matrixA[i][j] = random2.NextDouble();
                    matrixB[i][j] = random2.Next();
                }
            }
            Stopwatch sw2 = Stopwatch.StartNew();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    double cc = 0;
                    for (int k = 0; k < N; k++)
                        cc += a[i, k] * b[k, j];
                    matrixC[i][j] = cc;
                }
            }
            sw2.Stop();
            long duration2 = sw2.ElapsedMilliseconds;
            Console.WriteLine("Время умножения вложенных массивов " + duration2 + " мс");
            double performance2 = (N * N * N) / 2 / duration2;
            Console.WriteLine("Производительность " + performance2 + " ГФлопс");
            Console.ReadLine();

        }
    }
}
