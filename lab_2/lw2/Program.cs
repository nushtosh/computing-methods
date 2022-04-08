using System;

namespace Vichi_LR3
{
    class Program
    {
        static void Main(string[] args)
        {
            helper help = new helper();
            Console.WriteLine("Для показа задачи 3.1 введите 1, для показа задачи 3.2 введите 2");
            int p = Convert.ToInt32(Console.ReadLine());
            if (p == 1)
            {
                Console.WriteLine("Лабораторная работа номер 3.1");
                Console.WriteLine("Задача обратного интерполирования");
                Console.WriteLine("Введите начало отрезка");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите конец отрезка");
                double b = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите количество узлов");
                int m = Convert.ToInt32(Console.ReadLine());
                help.Value_Table(a, b, m, 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Исходная таблица значений функции");
                Console.ResetColor();
                help.Write_Table();

                Console.WriteLine("Введите F знаечение функции для которой решается задача обратного интерполироания");
                double F = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Введите n степень интерполяционного многочлена");
                int n = Convert.ToInt32(Console.ReadLine());
                if (help.Monotone())
                {
                    help.Swap();
                    double res = help.Newtons(F, n, 1, 1);

                    Console.Write("Корень = ");
                    Console.WriteLine(res);

                    help.Swap();
                    Console.Write("Величина невязки = ");
                    Console.WriteLine(Math.Abs(help.Function(res, 1) - F));

                }
                else

                {
                    Console.WriteLine("Первый метод недоступен, так как функция не монотонна");
                }
                help.F1 = F;
                help.Half_Devision(a, b, 0.0000000001, n, 1);
            }

            else
            {
                Console.WriteLine("Лабораторная работа номер 3.2");
                Console.WriteLine("Нахождение производных таблично-заданной функции по формулам численного дифференцирования");
                Console.WriteLine("Введите начало отрезка");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите конец отрезка");
                double b = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите количество узлов");
                int m = Convert.ToInt32(Console.ReadLine());
                help.Value_Table(a, b, m, 2);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Исходная таблица значений функции");
                Console.ResetColor();
                help.Write_Table();
                Console.Write("шаг h = ", (b - a) / m);
                Console.WriteLine((b - a) / m);
                Console.Write("Погрешность h^2 = ");
                Console.WriteLine(Math.Pow((b - a) / m, 2));
                Console.WriteLine("Таблица производных для узлов функции");
                help.Print_Derivative_Table();
            }



        }
    }
}
