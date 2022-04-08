using System;
using System.Collections.Generic;
using System.Text;

namespace lab_two
{
    class help
    {
        public List<double> knots = new List<double>();
        public List<double> vals = new List<double>();
        double Y;
        double X;
        double H;

        public double f(double x)
        {
            //double res = (double)(x - 0.17) * (x + 2) * (3 * x - 1.3);
            double res = Math.Pow(Math.E, -x) - Math.Pow(x, 2) / 2;
            return res;
        }
        public void prep(double a, double b, int m)
        {
            double x;
            double y;
            H = (double)(b - a) / m;
            for (int i = 0; i<m+1; i++)
            {
                x = (double)a + i * H;
                y = (double)f(x);
                
                Console.WriteLine("i=" + i + "    x=" + x + "    y=" + y);
                knots.Add(x);
            }
        }

        public void bubblesort(double x0)
        {
            Console.WriteLine("ОТСОРТИРОВАННАЯ ТАБЛИЦА ДЛЯ"+" "+x0);
            X = x0;
            Y = (double)f(X);
            //Y = (double)(X - 0.17) * (X + 2) * (3 * X - 1.3);
            double t;
            for (int i = 0; i < knots.Count; i++)
            {
                for (int j = i + 1; j < knots.Count; j++)
                {
                    if (Math.Abs(knots[i]-x0) > Math.Abs(knots[j]-x0))
                    {
                        t = knots[i];
                        knots[i] = knots[j];
                        knots[j] = t;
                    }
                }
            }
            for (int i = 0; i < knots.Count; i++)
            {
                Console.WriteLine("i="+i+"   x="+knots[i]);
            }
        }
        public void newtons(double x0,int n)
        {
            Console.WriteLine("значение интерполяционного многочлена, найденное при помощи представления в форме Ньютона:");
            double res = f(knots[0]), F, den;
            int i, j, k;
            for (i = 1; i <= n; i++)
            {
                F = 0;
                for (j = 0; j <= i; j++)
                {
                    den = 1;
                    for (k = 0; k <= i; k++)
                    {
                        if (k != j) den *= (knots[j] - knots[k]);
                    }
                    F += f(knots[j]) / den;
                }
                for (k = 0; k < i; k++) F *= (x0 - knots[k]);
                res += F;
            }
            Y = (double)f(X);
            double efnx = Math.Abs(res - Y);
            Console.WriteLine(res);
            Console.WriteLine("значение абсолютной фактической погрешности для формы Ньютона:" + efnx);
        }
        

        public void lagr(int n)
        {
            vals.Clear();
            for (int i = 0; i < n + 1; i++)
            {
                double y = (double)f(knots[i]);
                vals.Add(y);
            }
            double efnx;
            double pnx = 0;
            double top;
            for (int k = 0; k < n; k++)
            {
                top = 1;
                for (int i = 0; i < n; i++)
                {
                    if (i != k)
                    {
                        top = (double)top * (X - knots[i]) / (knots[k] - knots[i]);
                    }
                }
                pnx += (double)top * (f(knots[k]));
            }
            Y =(double) f(X);
            efnx = Math.Abs(pnx - Y);
            Console.WriteLine("значение интерполяционного многочлена, найденное при помощи представления в форме Лагранжа:");
            Console.WriteLine(pnx);
            Console.WriteLine("значение абсолютной фактической погрешности для формы Лагранжа:" + efnx + "\n");

        }
        
    }
}
