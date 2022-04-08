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
        public double f1(double x)
        {
            double res = Math.Pow(Math.E, 1.5*3*x);
            return res;
        } 
        public void prep(double a, double b, int m)
        {
            double x;
            double y;
            H = (double)(b - a) / m;
            for (int i = 0; i < m + 1; i++)
            {
                x = (double)a + i * H;
                y = (double)f(x);

                Console.WriteLine("i=" + i + "    x=" + x + "    y=" + y);
                knots.Add(x);
                vals.Add(y);
            }
        }
        public void prep1(double a, double h, int m)
        {
            double x;
            double y;
            //H = (double)(b - a) / m;
            for (int i = 0; i < m + 1; i++)
            {
                x = (double)a + i * h;
                y = (double)f1(x);

                Console.WriteLine("i=" + i + "    x=" + x + "    y=" + y);
                knots.Add(x);
                vals.Add(y);
            }
        }

        public void bubblesort(double y0)
        {
            Console.WriteLine("ОТСОРТИРОВАННАЯ ТАБЛИЦА ДЛЯ " + " y=" + y0);
            Y = y0;
            //Y = (double)(X - 0.17) * (X + 2) * (3 * X - 1.3);
            double t;
            for (int i = 0; i < vals.Count; i++)
            {
                for (int j = i + 1; j < vals.Count; j++)
                {
                    if (Math.Abs(vals[i] - y0) > Math.Abs(vals[j] - y0))
                    {
                        t = vals[i];
                        vals[i] = vals[j];
                        vals[j] = t;
                        t = knots[i];
                        knots[i] = knots[j];
                        knots[j] = t;
                    }
                }
            }
            for (int i = 0; i < vals.Count; i++)
            {
                Console.WriteLine("i=" + i + "   y=" + vals[i] + "   x=" + knots[i]);
            }
        }
        public void newtonsv(double y0, int n)
        {
            Console.WriteLine("СПОСОБ 1");
            double res = knots[0], F, den;
            int i, j, k;
            for (i = 1; i <= n; i++)
            {
                F = 0;
                for (j = 0; j <= i; j++)
                {
                    den = 1;
                    for (k = 0; k <= i; k++)
                    {
                        if (k != j) den *= (vals[j] - vals[k]);
                    }
                    F += knots[j] / den;
                }
                for (k = 0; k < i; k++) F *= (y0 - vals[k]);
                res += F;
            }
            
            Y = (double)f(X);
            double efnx = Math.Abs(f(res) - y0);
            Console.WriteLine(res);
            Console.WriteLine("абсолютная величина невязки:" + efnx);
        }

        public double newtons(double x0,double y0, int n)
        {
            
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
            return (res-y0);
        }

        public void bissection(double a, double b, double e,double y0,int n)
        {
            Console.WriteLine("СПОСОБ 2");
            int count = 0;
            double y1;
            double y2;
            double c = (double)(a + b) / 2;
            double X;
            double delta;
            double Y;
            while (b - a > 2 * e)
            {
                y1 = newtons(a,y0,n);
                y2 = newtons(c,y0,n);
                if (y1 * y2 <= 0)
                {
                    b = c;
                }
                else a = c;
                c = (double)(a + b) / 2;
                count++;
            }
            X = (double)(a + b) / 2;
            Y = f(X);
            delta = (double)(b - a) / 2;
            Console.WriteLine("корень: " + X + "\nабсолютная величина невязки: " + "|" + (Y -y0)+"|" + "\nпогрешность: " + delta + "\nколичество шагов: " + count + "\n");

        }
        public double firstder(int i,double h)
        {
            if ((i>= 2)&&(i<vals.Count-1))
            {
                return ((vals[i+1]-vals[i-1]) / (2.0 * h));
            }
            else if(i==vals.Count-1)
            {
                return ((3 * vals[i] - 4 * vals[i - 1] + vals[i - 2]) / (2.0 * h));
            }
            else
            {
                return ((-3 * vals[i] + 4 * vals[i + 1] - vals[i + 2]) / (2.0 * h));
            }
        }
        public double secder(int i,double h)
        {
            return (vals[i + 1] - 2 * vals[i] + vals[i - 1]) / (h * h);
        }
        public void printder(double h)
        {
            {
                for (int i = 0; i < vals.Count; i++)
                {
                    Console.Write(knots[i] + " | ");
                    Console.Write(vals[i] + " | ");
                    Console.Write(firstder(i,h) + " | ");
                    Console.Write(Math.Abs(4.5*f1(knots[i]) - firstder(i,h)) + " | ");
                    if (i == (knots.Count - 1) || i == 0)
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write(secder(i,h) + " | ");
                        Console.WriteLine(Math.Abs(4.5*4.5*f1(knots[i]) - secder(i,h)) + " | ");
                    }

                }

            }
        }
    }
}
        