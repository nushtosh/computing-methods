using System;
using System.Collections.Generic;
using System.Text;

namespace lab_one
{
    class help
    {
        public List<double> Sections = new List<double>();
        int counter;
        
        public double f(double x)
        {
            double fun= Math.Pow(2,-x)+ 0.5*Math.Pow(x, 2) - 10;
            return fun;
        }
        public void p1(double a, double b, int N) 
        {
            double H = (double) (b-a) / N;
            double x1 = a; double x2 = a + H;
            double y1;
            double y2;
            Console.WriteLine("ОТРЕЗКИ, СОДЕРЖАЩИЕ КОРНИ УРАВНЕНИЯ:");
            while (x2 <= b)
            {
                y1 = f(x1);
                y2 = f(x2);

                if (y1 * y2 <= 0)
                {
                    if (!Sections.Contains(x1))//if root is between sections
                    {
                        counter++;
                        Console.WriteLine("["+x1 + ", " + x2+"]"+"\n");
                        Sections.Add(x1);
                        Sections.Add(x2);
                    }
                }

                x1 = x2;
                x2 = x1 + H;
            }
            Console.WriteLine("КОЛИЧЕСТВО ОТРЕЗКОВ ПЕРЕМЕННЫХ ЗНАКОВ: "+counter+"\n");
        }

        public void bissection(double a,double b, double e) 
        {
            int count=0;
            double y1;
            double y2;
            double c = (double)(a + b) / 2;
            double X;
            double delta;
            double Y;
            while (b - a > 2 * e)
            {
                y1 = f(a);
                y2 = f(c);
                if (y1 * y2 <= 0)
                {
                    b = c;
                }
                else a = c;
                c = (double) (a + b) / 2;
                count++;
            }
            X = (double) (a + b) / 2;
            Y = f(X);
            delta = (double) (b-a) / 2;
            Console.WriteLine("корень: " + X + "\nабсолютная величина невязки: " + "|" + Y + " - 0|" + "\nпогрешность: " + delta + "\nколичество шагов: " + count + "\n");

        }

        public void newt(double a, double b, double e)
        {
            int count = 0;
            int p = 1;
            double x1 = a;
            double y1=f(x1);
            double x2 = b;
            Console.WriteLine("НАЧАЛЬНОЕ ПРИБЛИЖЕНИЕ: " + x1);
            while (Math.Abs(x2 - x1) >e) 
            {
                if (x1!=0) 
                {
                    x2 = x1;
                    x1 = (double)-y1 / (x1-Math.Pow(2,-x1)*Math.Log(2)) + x1;
                    y1 = f(x1);
                    count++; 
                }
                else
                {
                    p = p + 2;
                }
            }
            double X = (double)-y1 / (x1 - Math.Pow(2, -x1) * Math.Log(2)) + x1;
            double delta = (double)Math.Abs(x2 - x1) / 2;
            double Y= f(X);

            Console.WriteLine("корень: " + X + "\nабсолютная величина невязки: " + "|" + Y + " - 0|" + "\nпогрешность: " + delta + "\nколичество шагов: " + count + "\n");
        }

        public void mod_newt(double a, double b, double e)
        {
            int count = 0;
            double x0 = a;
            double x1 = (a + b) / 2;
            double y1 = f(x1);
            double x2 = b;
            double y2 = f(x2);
            double pr0 = x0 - Math.Pow(2, -x0) * Math.Log(2);
            Console.WriteLine("НАЧАЛЬНОЕ ПРИБЛИЖЕНИЕ: "+x0+", " + x1);
            while (Math.Abs(x2 - x1) > e) 
            {
                x2 = x1;
                x1 = (double)-y1 / pr0 + x1;
                y1 = f(x1);
                y2 = f(x2);
                count++;
            }

            double X = (double)-y1 / pr0 + x1;
            double delta = (double)Math.Abs(x2 - x1) / 2;
            double Y = f(X);

            Console.WriteLine("корень: " + X + "\nабсолютная величина невязки: " + "|" + Y + " - 0|" + "\nпогрешность: " + delta + "\nколичество шагов: " + count + "\n");
        }

        public void sek(double a, double b, double e)
        {
            int count = 0;
            double x1 = a;
            double y1 = f(x1);
            double x2 = b;
            double y2 = f(x2);
            Console.WriteLine("НАЧАЛЬНОЕ ПРИБЛИЖЕНИЕ: " + x1+", "+x2);

            while (Math.Abs(x2 - x1) > e) 
            {
               
                double x3 = (double)x2 - y2 / (y2 - y1) * (x2 - x1);
                x1 = x2;
                x2 = x3;
                y1 = f(x1);
                y2 = f(x2);
                count++;
            }

            double X = (double)x2 - y2 / (y2 - y1) * (x2 - x1);
            double delta = (double)Math.Abs(x2 - x1) / 2;
            double Y = f(X);

            Console.WriteLine("корень: " + X+"\nабсолютная величина невязки: " +"|"+ Y + " - 0|" + "\nпогрешность: " + delta + "\nколичество шагов: " + count + "\n");
        }
    }
}
