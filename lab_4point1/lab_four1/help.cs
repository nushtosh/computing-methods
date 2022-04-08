using System;
using System.Collections.Generic;
using System.Text;

namespace lab_four
{
    public class help
    {
        public double val0;
        public double val;
        public double a;
        public double b;
        public int m;

        public double f(double x)
        {
            return (double)-Math.Cos(x) + Math.Pow(Math.E, x);
            //return 5 ;//const
            //return 5 * x;//1 power
            //return 5.0 * x * x + 3.0 * x;//2 power
            //return(double) (5 * Math.Pow(x, 3)-2*x);//3 power
        }
        public double intf(double x)
        {
            return (double)(-Math.Sin(x) + Math.Pow(Math.E, x));
            //return 5 * x;//const
            //return (5 * x*x / 2.0);//1 power
            //return (5.0 * (1.0/3.0)*x*x*x + 3.0 * (1.0/2.0)*x * x);
            //return (double)(5 * (1.0/4.0)*Math.Pow(x, 4) - x*x);//3 power
        }
        public void value()
        {
            val0 = (double)intf(b) - intf(a);
            Console.WriteLine("значение интеграла(J):" + val0);
        }

        public void left()
        {
            val = (b - a) * f(a);
            val0 = (double)intf(b) - intf(a);
            Console.WriteLine("значение интеграла по формуле левого прямоугольника(J(h)):" + val);
            Console.WriteLine("абсолютная фактическая погрешность |J-J(h)|:" + Math.Abs(val0 - val));
        }

        public void right()
        {
            val = (b - a) * f(b);
            val0 = (double)intf(b) - intf(a);
            Console.WriteLine("значение интеграла по формуле правого прямоугольника(J(h)):" + val);
            Console.WriteLine("абсолютная фактическая погрешность |J-J(h)|:" + Math.Abs(val0 - val));
        }

        public void middle()
        {
            val = (b - a) * f((a+b)/2.0);
            val0 = (double)intf(b) - intf(a);
            Console.WriteLine("значение интеграла по формуле среднего прямоугольника(J(h)):" + val);
            Console.WriteLine("абсолютная фактическая погрешность |J-J(h)|:" + Math.Abs(val0 - val));
        }

        public void trap()
        {
            val = ((b - a)/2.0) * (f(a)+f(b));
            val0 = (double)intf(b) - intf(a);
            Console.WriteLine("значение интеграла по формуле трапеций(J(h)):" + val);
            Console.WriteLine("абсолютная фактическая погрешность |J-J(h)|:" + Math.Abs(val0 - val));
        }
        public void simp()
        {
            val = (double)((b - a)*(1.0/6.0)) * (f(a) + (4.0 * f((a + b)/2.0)) + f(b));
            val0 = (double)intf(b) - intf(a);
            Console.WriteLine("значение интеграла по формуле Симпсона(J(h)):" + val);
            Console.WriteLine("абсолютная фактическая погрешность |J-J(h)|:" + Math.Abs(val0 - val));
        }

        public void three_eight()
        {
            double h = (b - a) / 3.0;
            val = (b - a) * (f(a)/8.0f + (3.0f / 8.0f) * f(a+h) + (3.0f / 8.0f) * f(a+2.0f*h) + f(b)/8.0f);
            val0 = (double)intf(b) - intf(a);
            Console.WriteLine("значение интеграла по формуле 3/8(J(h)):" + val);
            Console.WriteLine("абсолютная фактическая погрешность |J-J(h)|:" + Math.Abs(val0 - val));
        }
    }
}