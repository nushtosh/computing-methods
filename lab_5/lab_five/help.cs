using System;
using System.Collections.Generic;
using System.Text;

namespace lab_five
{

    class help
    {
        double a; double b;
        int m;
        public List<double> Sections = new List<double>();
        int counter;
        public List<double>[] uz = new List<double>[9];
        public List<double>[] ko = new List<double>[9];

        public List<double> knots = new List<double>();
        public List<double> koef = new List<double>();
        public double f(double x)
        {
            return (double)Math.Sqrt(x) / (1 + x * x);
        }
        public void st()
        {
            for (int i = 0; i < 9; i++)
            {
                uz[i] = new List<double>();
                ko[i] = new List<double>();
            }
        }
        public double KFG(int k)
        {
            double res1 = 0;
            for (int i = 0; i < uz[k].Count; i++)
            {
                res1 += ko[k][i] * f(uz[k][i]);
            }
            return res1;
        }
        public double PL(double x, int k)
        {
            double p2 = 0;
            double p0 = 1;
            double p1 = x;
            if (k > 1)
            {
                for (int i = 2; i <= k; i++)
                {
                    p2 = ((double)(2 * i - 1) / i) * p1 * x - ((double)(i - 1) / i) * p0;
                    p0 = p1;
                    p1 = p2;
                }
                return p2;
            }
            else if (k == 1) return p1;
            else return p0;
        }
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public double f3(double x)
        {
            double f = 6 * Math.Pow(x, 5) + 3 * Math.Pow(x, 2) + 10 * x;
            return f;
        }
        public double if3(double x)
        {
            double if1 = Math.Pow(x, 6) + Math.Pow(x, 3) + 5 * Math.Pow(x, 2);
            return if1;
        }
        public double f4(double x)
        {
            double f = 8 * Math.Pow(x, 7) + 3 * Math.Pow(x, 2) + 10 * x;
            return f;
        }
        public double if4(double x)
        {
            double if1 = Math.Pow(x, 8) + Math.Pow(x, 3) + 5 * Math.Pow(x, 2);
            return if1;
        }
        public double f5(double x)
        {
            double f = 10 * Math.Pow(x, 9) + 3 * Math.Pow(x, 2) + 10 * x;
            return f;
        }
        public double if5(double x)
        {
            double if1 = Math.Pow(x, 10) + Math.Pow(x, 3) + 5 * Math.Pow(x, 2);
            return if1;
        }
        public void proof(int k)
        {
            Console.WriteLine("Количество узлов: " + k);
            Console.WriteLine("РЕАЛЬНОЕ ЗНАЧЕНИЕ ИНТЕГРАЛА и ЗНАЧЕНИЕ ИНТЕГРАЛА ПО КФГ");
            if (k == 3)
            {
                
                double res = if3(1) - if3(-1);
                double res1 = 0;
                for (int i = 0; i < uz[k].Count; i++)
                {
                    res1 += ko[k][i] * f3(uz[k][i]);
                }
                Console.WriteLine(res + "  " + res1);
            }
            if (k == 4)
            {
                double res = if4(1) - if4(-1);
                double res1 = 0;
                for (int i = 0; i < uz[k].Count; i++)
                {
                    res1 += ko[k][i] * f4(uz[k][i]);
                }
                Console.WriteLine(res + "  " + res1);
            }
            if (k == 5)
            {
                double res = if5(1) - if5(-1);
                double res1 = 0;
                for (int i = 0; i < uz[k].Count; i++)
                {
                    res1 += ko[k][i] * f5(uz[k][i]);
                }
                Console.WriteLine(res + "  " + res1);
            }
        }



        public void p1(double a, double b, int k)
        {
            Sections.Clear();
            uz[k].Clear();
            knots.Clear();
            double H = (double)(b - a) / 100;
            double x1 = a; double x2 = a + H;
            double y1;
            double y2;
            //Console.WriteLine("ОТРЕЗКИ, СОДЕРЖАЩИЕ КОРНИ УРАВНЕНИЯ:");
            while (x2 <= b)
            {
                y1 = PL(x1, k);
                y2 = PL(x2, k);

                if (y1 * y2 <= 0)
                {
                    if (!Sections.Contains(x1))//if root is between sections
                    {
                        counter++;
                        //Console.WriteLine("[" + x1 + ", " + x2 + "]" + "\n");
                        Sections.Add(x1);
                        Sections.Add(x2);
                    }
                }

                x1 = x2;
                x2 = x1 + H;
            }
            //Console.WriteLine("КОЛИЧЕСТВО ОТРЕЗКОВ ПЕРЕМЕННЫХ ЗНАКОВ: " + counter + "\n");
        }

        public void sek(double a, double b, double e, int k)
        {
            int count = 0;
            double x1 = a;
            double y1 = PL(x1, k);
            double x2 = b;
            double y2 = PL(x2, k);
            //Console.WriteLine(y1 + " " + y2);
            //Console.WriteLine("НАЧАЛЬНОЕ ПРИБЛИЖЕНИЕ: " + x1 + ", " + x2);

            while (Math.Abs(y2 - y1) > e)
            {
                double x3 = (double)x2 - ((y2 / (y2 - y1)) * (x2 - x1));
                x1 = x2;
                x2 = x3;
                y1 = PL(x1, k);
                y2 = PL(x2, k);
                count++;
            }

            double X = (double)x2;
            double delta = (double)Math.Abs(x2 - x1) / 2;
            double Y = PL(X, k);
            knots.Add(x2);

            uz[k].Add(x2);

            //Console.WriteLine("корень: " + X + "\nабсолютная величина невязки: " + "|" + Y + " - 0|" + "\nпогрешность: " + delta + "\nколичество шагов: " + count + "\n");
        }

        public void tableknots()
        {
            for (int i = 1; i < 9; i++)
            {
                p1(-1, 1, i);
                for (int ka = 0; ka < Sections.Count; ka++)
                    sek(Sections[ka], Sections[++ka], Math.Pow(10,-12), i);

                koefG(i);
                Console.WriteLine();
                Console.WriteLine("Количество узлов: " + i);
                Console.WriteLine("УЗЛЫ            КОЭФИЦИЕНТЫ");
                for (int ka = 0; ka < i; ka++)
                {
                    Console.WriteLine(uz[i][ka]+"   "+ko[i][ka]);
                }
            }

        }
        public void koefG(int k)
        {
            koef.Clear();
            for (int i = 0; i < knots.Count; i++)
            {
                double ak = 2 * (1 - Math.Pow(uz[k][i], 2)) / (Math.Pow(uz[k].Count, 2) * Math.Pow(PL(uz[k][i], uz[k].Count - 1), 2));
                koef.Add(ak);
                ko[k].Add(ak);
            }
            
        }

        public void alike(double c, double d,int k)
        {
            double q = (double)((d - c) / 2);
            for (int i = 0; i < uz[k].Count; i++)
            {
                ko[k][i] = ko[k][i] * q;
                uz[k][i] = c + q * (uz[k][i]+1);
            }
            Console.WriteLine("УЗЛЫ            КОЭФИЦИЕНТЫ");
            for (int ka = 0; ka < uz[k].Count; ka++)
            {
                Console.WriteLine(uz[k][ka] + "     " + ko[k][ka]);
            }
        }

        public double r(double x)
        {
            return (double)Math.Sqrt(x);
        }
    }
}

