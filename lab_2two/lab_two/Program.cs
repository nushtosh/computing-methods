using System;

namespace lab_two
{
    class Program
    {
        static void Main(string[] args)
        {
            help cl = new help();
            Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №2: ЗАДАЧА АЛГЕБРАИЧЕСКОГО ИНТЕРПОЛИРОВАНИЯ\nвариант№1\nf(x)=exp(-x) – x^2/2   a=0   b=1   x=0.6   m=15   n=7");
            Start:
            Console.WriteLine("КАКИЕ ПАРАМЕТРЫ ВЫ ХОТИТЕ ИСПОЛЬЗОВАТЬ?\n1 - данные параметры\n2 - свои параметры\n0 - выход");
            
            int temp;
            temp = Convert.ToInt32(Console.ReadLine());
                if (temp == 1)
                {
                    cl.prep(0, 1, 14);
                    cl.bubblesort(0.6);
                    cl.newtons(0.6,7);
                    cl.lagr(7);
                cl.knots.Clear();
                    goto Start;
                }
                else if (temp == 2)
                {
                    Console.WriteLine("ВВЕДИТЕ НАЧАЛО ОТРЕЗКА:");
                    double a;
                    a = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("ВВЕДИТЕ КОНЕЦ ОТРЕЗКА:");
                    double b;
                    b = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("ВВЕДИТЕ ЧИСЛО ЗНАЧЕНИЙ В ТАБЛИЦЕ\n0 -выход:");
                    int m;
                    m = Convert.ToInt32(Console.ReadLine());
                    cl.prep(a, b, m - 1);
                while (m != 0)
                {
                    Console.WriteLine("ВВЕДИТЕ ТОЧКУ ИНТЕРПОЛИРОВАНИЯ Х:");
                    double x;
                
                    x = Convert.ToDouble(Console.ReadLine());
                
                    cl.bubblesort(x);
                    Console.WriteLine("ВВЕДИТЕ СТЕПЕНЬ ИТЕРПОЛЯЦИОННОГО МНОГОЧЛЕНА(<"+m+"):");
                    int n;
                    n = Convert.ToInt32(Console.ReadLine());
                    while (!(n < m))
                    {
                        Console.WriteLine("ВВЕДИТЕ ЗНАЧЕНИЕ < " + m + "):");
                        n = Convert.ToInt32(Console.ReadLine());
                    }
                    cl.newtons(x,n);
                    cl.lagr(n);
                }

                }
            
            
        }
    }
}
