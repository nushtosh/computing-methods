using System;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0.0;
            double b = 1.0;
            int m = 100;
            int N = 5;
            helper help = new helper();
            Console.WriteLine("Лабораторная работа номер 5");
            Console.WriteLine("Приближённое вычисление интегралов при помощи квадратурных формул Наивысшей Алгебраической Степени Точности(КФ НАСТ)");
            Console.WriteLine("Предел интегрирования а = 0");
            Console.WriteLine("Предел интегрирования b = 1");
            Console.WriteLine("Функция f(x) = sinx");
            Console.WriteLine("Функция p(x) = x^(1/2)");
            Console.WriteLine("Количество промежутков деления m =100");
            Console.WriteLine();
            Console.WriteLine("Решение через КФ Гаусса");
            help.Gauss(a, b, m);
            Console.WriteLine();
            help.Moments(a, b, m);
            Console.WriteLine();

            help.Meller(-1.0, 1.0, N);
            Console.ReadKey();
        }
    }

}
