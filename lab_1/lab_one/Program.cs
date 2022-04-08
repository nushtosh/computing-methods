using System;


namespace lab_one
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №1\nЧИСЛЕННЫЕ МЕТОДЫ РЕШЕНИЯ НЕЛИНЕЙНЫХ УРАВНЕНИЙ \nf(x)= 2^(-x) + 0,5x^2-10\n[A, B] = [-3;5]   e= 10^(-8)\n");
            help cl = new help();
            Start:
            Console.WriteLine("ХОТИТЕ ИСПОЛЬЗОВАТЬ СТАНДАРТНЫЕ ПАРАМЕТРЫ?\n1 - ДА\n2 - НЕТ\n");
            int temp;
            temp = Convert.ToInt32(Console.ReadLine());
            double eps;
            double a;
            double b;
            if (temp == 2)
            {
                Console.WriteLine("ВВЕДИТЕ ТОЧНОСТЬ ВЫЧИСЛЕНИЙ");
                eps =Convert.ToDouble( Console.ReadLine());
                Console.WriteLine("ВВЕДИТЕ НАЧАЛО ОТРЕЗКА");
                a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("ВВЕДИТЕ КОНЕЦ ОТРЕЗКА");
                b = Convert.ToDouble(Console.ReadLine());
            }
            else
            {
                eps = Math.Pow(10,-8);
                a = -3;
                b = 5;
            }
            Console.WriteLine("ВВЕДИТЕ КОЛИЧЕСТВО ОТРЕЗКОВ ДЛЯ ОТДЕЛЕНИЯ КОРНЕЙ");
            int N;
            N = Convert.ToInt32(Console.ReadLine());

            cl.p1(a, b, N);//root quantity and sections



            //Console.WriteLine("ВЫБЕРИТЕ МЕТОД ДЛЯ УТОЧНЕНИЯ КОРНЕЙ\n1 - БИССЕКЦИЯ\n2 - МЕТОД НЬЮТОНА\n3 - МОДИФИЦИРОВАННЫЙ МЕТОД НЬЮТОНА\n4 - МЕТОД СЕКУЩИХ\n5 - ВСЁ СРАЗУ\n");
            //int t;
            //t= Convert.ToInt32(Console.ReadLine());

            //if (t == 1)
            //{
            //    Console.WriteLine("БИССЕКЦИЯ");
            //    for (int i = 0; i < cl.Sections.Count; i++)
            //        cl.bissection(cl.Sections[i], cl.Sections[++i], eps);
            //}
            //else if (t == 2)
            //{
            //    Console.WriteLine("МЕТОД НЬЮТОНА");
            //    for (int i = 0; i < cl.Sections.Count; i++)
            //        cl.newt(cl.Sections[i], cl.Sections[++i], eps);
            //}
            //else if (t == 3)
            //{
            //    Console.WriteLine("МОДИФИЦИРОВАННЫЙ МЕТОД НЬЮТОНА");
            //    for (int i = 0; i < cl.Sections.Count; i++)
            //        cl.mod_newt(cl.Sections[i], cl.Sections[++i], eps);
            //}
            //else if (t == 4)
            //{
            //    Console.WriteLine("МЕТОД СЕКУЩИХ");
            //    for (int i = 0; i < cl.Sections.Count; i++)
            //        cl.sek(cl.Sections[i], cl.Sections[++i], eps);
            //}
            //else if (t == 5)
            //{
                Console.WriteLine("БИССЕКЦИЯ");
                for (int i = 0; i < cl.Sections.Count; i++)
                    cl.bissection(cl.Sections[i], cl.Sections[++i], eps);
                Console.WriteLine("МЕТОД НЬЮТОНА");
                for (int i = 0; i < cl.Sections.Count; i++)
                    cl.newt(cl.Sections[i], cl.Sections[++i], eps);
                Console.WriteLine("МОДИФИЦИРОВАННЫЙ МЕТОД НЬЮТОНА");
                for (int i = 0; i < cl.Sections.Count; i++)
                    cl.mod_newt(cl.Sections[i], cl.Sections[++i], eps);
                Console.WriteLine("МЕТОД СЕКУЩИХ");
                for (int i = 0; i < cl.Sections.Count; i++)
                    cl.sek(cl.Sections[i], cl.Sections[++i], eps);
            //    }
            //    else Console.WriteLine("цифры от 1 до 5!!!!!!!!!!!!!!");
            Console.WriteLine("Хотите ввести новые значения дл А,В?(y/n)");
            string yn;
            yn = Console.ReadLine();
            if (yn == "y") goto Start;
        }

        
    }
}
