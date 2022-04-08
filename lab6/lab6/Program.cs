using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            help cl = new help();
        Start:

            Console.WriteLine("Составная Kвадратурная формула Гаусса и КФ типа Гаусса с двумя узлами для f=sin(x);p=sin(2x)");
            Gauss:
            double eps;
            double a;
            double b;
                eps = Math.Pow(10, -12);
                a = 0;
                b = 1;
            
            
            cl.st();
            Console.WriteLine("ВВЕДИТЕ КОЛИЧЕСТВО узлов");
            int N;
            N = Convert.ToInt32(Console.ReadLine());
            cl.tableknots(N);
            //cl.alike(0, 1, N);
            Console.WriteLine("ВВЕДИТЕ КОЛИЧЕСТВО отрезков");
            int m;
            m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Значение интеграла: " + cl.SKFG(N, m));
            //cl.Gauss(a, b, m);
            Console.WriteLine();
            cl.Moments(a, b, m);
            Console.WriteLine();
            Console.WriteLine();
            //Console.WriteLine("Проверка");
            //cl.Momentsx(a, b, m);
            //Console.WriteLine();

            //Console.WriteLine("Хотите ввести границы интеграла и количество узлов?(y/n)");
            //string yn;
            //yn = Console.ReadLine();
            //cl.Sections = new List<double>();
            //if (yn == "y") goto Body;
            //else goto Start;
            //Meller:
            //Console.WriteLine("ВВЕДИТЕ КОЛИЧЕСТВО узлов");
            //int N1;
            //N1 = Convert.ToInt32(Console.ReadLine());
            //mel.mel(N1);
            //Console.WriteLine("Хотите ввести другое количество узлов?");
            //string ny;
            //ny = Console.ReadLine();
            //if (ny == "y") goto Meller;
            goto Start;
        }





    }
}
