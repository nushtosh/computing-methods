using System;

namespace lab_two
{
    class Program
    {
        static void Main(string[] args)
        {
            help cl = new help();
        Start:
            Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №2: \n1 - Задача обратного интерполирования\n2 - Нахождение производных таблично-заданной функции по формулам численного дифференцирования\n0 - выход");
            int tempo;
            tempo = Convert.ToInt32(Console.ReadLine());
            if (tempo == 1) { 
                Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №2: ЗАДАЧА АЛГЕБРАИЧЕСКОГО ИНТЕРПОЛИРОВАНИЯ\nвариант№12\nf(x)=exp(-x) – x^2/2   a=0   b=1   y=0.6   m=15   n=7   e=10^(-9)");
        
            Console.WriteLine("КАКИЕ ПАРАМЕТРЫ ВЫ ХОТИТЕ ИСПОЛЬЗОВАТЬ?\n1 - данные параметры\n2 - свои параметры\n0 - выход");

            int temp;
            temp = Convert.ToInt32(Console.ReadLine());
                if (temp == 1)
                {
                    cl.prep(0, 1, 14);
                    cl.bubblesort(0.6);
                    cl.newtonsv(0.6, 7);
                    cl.bissection(0, 1, 0.000000001, 0.6, 7);
                    cl.knots.Clear();
                    cl.vals.Clear();
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
                        Console.WriteLine("ВВЕДИТЕ ТОЧКУ ОБРАТНОГО ИНТЕРПОЛИРОВАНИЯ У:");
                        double x;

                        x = Convert.ToDouble(Console.ReadLine());
                        cl.bubblesort(x);

                        Console.WriteLine("ВВЕДИТЕ ТОЧНОСТЬ РЕШЕНИЯ е:");
                        double e;

                        e = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("ВВЕДИТЕ СТЕПЕНЬ ИТЕРПОЛЯЦИОННОГО МНОГОЧЛЕНА(<" + m + "):");
                        int n;
                        n = Convert.ToInt32(Console.ReadLine());
                        while (!(n < m))
                        {
                            Console.WriteLine("ВВЕДИТЕ ЗНАЧЕНИЕ < " + m + "):");
                            n = Convert.ToInt32(Console.ReadLine());
                        }
                        cl.newtonsv(x, n);
                        cl.bissection(a, b, e, x, n);
                    }
                    cl.knots.Clear();
                    cl.vals.Clear();
                }

            }else if (tempo == 2)
            {
                Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №2: НАХОЖДЕНИЕ ПРОИЗВОДНЫХ\nвариант№12\nf(x)=exp^(1.5*3*x)   a=0   h=0.001   m=11");

                Console.WriteLine("КАКИЕ ПАРАМЕТРЫ ВЫ ХОТИТЕ ИСПОЛЬЗОВАТЬ?\n1 - данные параметры\n2 - свои параметры\n0 - выход");

                int temp;
                temp = Convert.ToInt32(Console.ReadLine());
                if (temp == 1)
                {
                    cl.prep1(0, 0.001, 10);
                    cl.printder(0.001);
                    cl.knots.Clear();
                    cl.vals.Clear();
                    goto Start;
                }
                else if (temp == 2)
                {
                    Console.WriteLine("ВВЕДИТЕ НАЧАЛО ОТРЕЗКА:");
                    double a;
                    a = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("ВВЕДИТЕ ШАГ:");
                    double h;
                    h = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("ВВЕДИТЕ ЧИСЛО ЗНАЧЕНИЙ В ТАБЛИЦЕ");
                    int m;
                    m = Convert.ToInt32(Console.ReadLine());

                    cl.prep1(a, h, m-1);
                    cl.printder(h);
                    cl.knots.Clear();
                    cl.vals.Clear();
                    goto Start;
                }
            }


        }
    }
}
