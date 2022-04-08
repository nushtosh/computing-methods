using System;
using System.Collections.Generic;
using System.Text;


namespace lab_five
{
    class Program
    {
        static void Main(string[] args)
        {
            help cl = new help();
            meller mel = new meller();
        Start:

            Console.WriteLine("Kвадратурная формула Гаусса для sqrt(x)/1+x^2 - 1;\nКвадратурная формула Мелера для log(x+2) - 0");
            int g;
            g = Convert.ToInt32(Console.ReadLine());
            if (g == 1) goto Gauss;
            else goto Meller;
            Gauss:
            double eps;
            double a;
            double b;
                eps = Math.Pow(10, -12);
                a = -1;
                b = 1;
            
            
            cl.st();
            
            cl.tableknots();
            Console.WriteLine("Проверка точности для 3,4,5 узлов");
            cl.proof(3);
            cl.proof(4);
            cl.proof(5);
            Body:
            Console.WriteLine("ВВЕДИТЕ новые границы интеграла");
            int c;
            c = Convert.ToInt32(Console.ReadLine());
            int d;
            d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ВВЕДИТЕ КОЛИЧЕСТВО узлов");
            int N;
            N = Convert.ToInt32(Console.ReadLine());
            cl.alike(c, d,N);

            Console.WriteLine("Значение интеграла: "+cl.KFG(N));
            Console.WriteLine("Хотите ввести границы интеграла и количество узлов?(y/n)");
            string yn;
            yn = Console.ReadLine();
            cl.Sections = new List<double>();
            if (yn == "y") goto Body;
            else goto Start;
            Meller:
            Console.WriteLine("ВВЕДИТЕ КОЛИЧЕСТВО узлов");
            int N1;
            N1 = Convert.ToInt32(Console.ReadLine());
            mel.mel(N1);
            Console.WriteLine("Хотите ввести другое количество узлов?");
            string ny;
            ny = Console.ReadLine();
            if (ny == "y") goto Meller;
            else goto Start;
        }
    }
    
}
