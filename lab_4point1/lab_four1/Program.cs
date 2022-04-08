using System;

namespace lab_four
{
    class Program
    {
        static void Main(string[] args)
        {
            help cl = new help();
            Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №4: Приближённое вычисление интеграла по квадратурным формулам");
            Console.WriteLine("f(x)=- cos(x) + e^x    на отрезке [0,5]");
        Start:
            Console.WriteLine("ВВЕДИТЕ НАЧАЛО ОТРЕЗКА:");
            cl.a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("ВВЕДИТЕ КОНЕЦ ОТРЕЗКА:");
            cl.b = Convert.ToDouble(Console.ReadLine());
            cl.value();
            cl.left();
            cl.right();
            cl.middle();
            cl.trap();
            cl.simp();
            cl.three_eight();
            Console.WriteLine("Хотите ввести новые значения a, b, m? (y/n)");
            string yn;
            yn = Console.ReadLine();
            if (yn == "y") goto Start;

        }
    }
}
