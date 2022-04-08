using System;
using System.Collections.Generic;
using System.Text;

namespace lab_six
{
    class help
    {
        public double[] array = new double[13];
        public double h = 0.1;
        public double runge = 0;
        public double y(double x)
        {
            return (double)((Math.Pow(Math.E, 2 * x) - 1) / (Math.Pow(Math.E, 2 * x) + 1))+runge;
        }
        public double f(double x)
        {
            return -Math.Pow(y(x), 2) + 1;

        }
        public void exact()
        {
            int x0 = 0;
            for (int i = -2; i < 11; i=i+1)
            {
                double x1 = (double)i*h;
                Console.WriteLine(i*h+"     "+y(x1));
            }
        }
        public double eul0(double x1)
        {
            return x1 - (1 / 3f) * Math.Pow(x1, 3) + (2 / 15f) * Math.Pow(x1, 5) - (17 / 315f) * Math.Pow(x1, 7) + (4 / 315f) * Math.Pow(x1, 9);
        }
        public void eul()
        {
            for (int i = -2; i < 11; i++)
            {
                double x1 =(double)i * h;
                double euler = eul0(x1);
                array[i+2]=euler;
                Console.WriteLine(x1 + "     " + euler);
                Console.WriteLine("абсолютная погрешность: " + Math.Abs(y(x1) - euler));
            }
        }

        public void adams()
        {
            for (int i = 3; i < 11; i++)
            {
                double x1 = (double)i * h;
                double y1 = (double)array[i+1] + ((1 / 720f) * (1901 * h * f((i-1)*h)- 2774 * h * f((i - 2) * h) + 2616 * h * f((i - 3) * h) - 1274 * h * f((i - 4) * h) + 251 * h * f((i - 5) * h)));
                array[i + 2] = y1;
                Console.WriteLine(x1 + "     " + y1);
                Console.WriteLine("абсолютная погрешность: " + Math.Abs(y(x1) - y1));
            }
        }

        public void rungekutt()
        {
            for (int i = 1; i < 11; i++)
            {
                double x1 = (double)i * h;
                double k1= (double)h *f(x1-h);
                runge = (double)k1 / 2f;
                double k2= (double)h *f(x1-h/2f);
                runge = (double)k2 / 2f;
                double k3= (double)h *f(x1-h/2f);
                runge = k3;
                double k4= (double)h *f(x1);
                runge = 0;
                double rk = (double)y(x1 - h) + (1 / 6f) * (k1 + 2 * k2 + 2 * k3 + k4);
                Console.WriteLine(x1 + "     " +rk);
                Console.WriteLine("абсолютная погрешность: " + Math.Abs(y(x1) - rk));
            }
        }
    }
}
