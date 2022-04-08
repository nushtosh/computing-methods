using System;
using System.Collections.Generic;
using System.Text;

namespace lab_five
{
    class meller
    {
        public List<double> knots = new List<double>();

        public void mel(int k)
        {
            Console.WriteLine("КОЛИЧЕСТВО УЗЛОВ: "+k);
            Console.WriteLine("УЗЛЫ            КОЭФИЦИЕНТЫ");
            knots.Clear();
            double xk;
            double res = 0;
            for(int i = 1; i <= k; i++)
            {
                xk = Math.Cos(((double)(2*i-1)/(2*k))*Math.PI);
                knots.Add(xk);
                Console.WriteLine(xk + "         " + Math.PI / k);
                res += func(xk);
            }
            Console.WriteLine("Значение интеграла по КФ Мелера: "+res* (Math.PI / k));
        }
        public double func(double x)
        {
            double res = Math.Log(2 + x);
            return res;
        }
    }
}
