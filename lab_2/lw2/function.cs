using System;
using System.Collections.Generic;
using System.Text;

namespace Vichi_LR3
{
    public class helper
    {
        public List<double> x_value = new List<double>();
        public List<double> y_value = new List<double>();
        public List<double> value_x = new List<double>();
        public List<double> value_y = new List<double>();

        double h;
        public double F1 = 0;

        public double Function(double x, int o)
        {
            if (o == 1)
                return Math.Sin(x) - x * x / 2.0;
            else
                return Math.Pow(Math.E, 3 * x);

        }


        public void Value_Table(double a, double b, int m, int o)
        {
            h = (double)(b - a) / m;
            m = m - 1;
            double x, y;
            for (int j = 0; j < m + 1; j++)
            {
                x = (double)a + (double)((b - a) / m) * j;
                x_value.Add(x);
                y = Function(x, o);
                y_value.Add(y);
                value_y.Add(y);
                value_x.Add(x);

            }
        }

        public void Write_Table()
        {
            for (int i = 0; i < x_value.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(x_value[i]);
                Console.ResetColor();
                Console.Write(" | ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(y_value[i]);
                Console.ResetColor();
                Console.WriteLine("----------------------------------------");
            }
        }

        public void Sort_Table(double x, int o, int problem)
        {
            for (int i = 0; i < x_value.Count; i++)
            {
                x_value[i] -= x;
                value_y[i] -= x;
                value_y[i] += x;

            }
            x_value.Sort(Compare_List);
            for (int i = 0; i < x_value.Count; i++)
            {
                x_value[i] += x;

                if (problem == 1)
                    y_value[i] = value_x[value_y.IndexOf(x_value[i])];
                else
                    y_value[i] = Function(x_value[i], o);
            }

        }
        private static int Compare_List(double x1, double x2)
        {
            if (Math.Abs(x1) < Math.Abs(x2))
            {
                return -1;
            }
            if (Math.Abs(x1) > Math.Abs(x2))
            {
                return 1;
            }
            else return 0;
        }


        public bool Monotone()
        {
            int m;
            if (y_value[1] >= y_value[0]) m = 1;
            else
                m = -1;
            for (int i = 2; i < x_value.Count; i++)
            {
                if (((y_value[i] < y_value[i - 1]) && m == 1) || ((y_value[i] >= y_value[i - 1]) && m == -1))
                {
                    return false;
                }

            }
            return true;
        }
        public void Half_Devision(double a, double b, double eps, int n, int o)
        {
            double c;
            int counter = 0;
            do
            {

                counter++;
                c = (a + b) / 2;
                if ((Newtons(a, n, o, 2) * Newtons(c, n, o, 2)) <= 0)
                {
                    b = c;
                }
                else
                {
                    a = c;
                }
            } while ((b - a) > (2 * eps));
            double X = (double)(a + b) / 2;
            double delta = (double)(b - a) / 2;
            double Y = Math.Abs(Function(X, o));

            Console.WriteLine("корень: " + X + "\nмодуль невязки: " + delta + "\nколичество шагов: " + counter + "\n");

        }
        public double Newtons(double t, int n, int o, int problem)
        {
            Sort_Table(t, o, problem);
            double res = y_value[0], F, den;
            int i, j, k;
            for (i = 1; i <= n; i++)
            {
                F = 0;
                for (j = 0; j <= i; j++)
                {
                    den = 1;
                    for (k = 0; k <= i; k++)
                    {
                        if (k != j) den *= (x_value[j] - x_value[k]);
                    }
                    F += y_value[j] / den;
                }
                for (k = 0; k < i; k++) F *= (t - x_value[k]);
                res += F;
            }


            return res - F1;

        }

        double First_Derivative(int i)
        {
            if (i <= 2)
            {
                return ((-3 * y_value[i] + 4 * y_value[i + 1] - y_value[i + 2]) / (2.0 * h));
            }
            else
            {
                return ((3 * y_value[i] - 4 * y_value[i - 1] + y_value[i - 2]) / (2.0 * h));
            }
        }

        double Second_Derivative(int i)
        {
            return (y_value[i + 1] - 2 * y_value[i] + y_value[i - 1]) / (h * h);
        }

        double True_Fisrt_derivative(double x)
        {
            return 3 * Math.Pow(Math.E, 3 * x);
        }
        double True_Second_derivative(double x)
        {
            return 9 * Math.Pow(Math.E, 3 * x);
        }

        public void Print_Derivative_Table()
        {
            for (int i = 0; i < x_value.Count; i++)
            {
                Console.Write(x_value[i] + " | ");
                Console.Write(y_value[i] + " | ");
                Console.Write(First_Derivative(i) + " | ");
                Console.Write(True_Fisrt_derivative(x_value[i]) - First_Derivative(i) + " | ");
                if (i == (x_value.Count - 1) || i == 0)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(Second_Derivative(i) + " | ");
                    Console.WriteLine(True_Second_derivative(x_value[i]) - Second_Derivative(i) + " | ");
                }

            }

        }
        public void Swap()
        {
            List<double> value = new List<double>();
            for (int i = 0; i < x_value.Count; i++)
            {
                value.Add(x_value[i]);
                x_value[i] = y_value[i];
                y_value[i] = value[i];

            }

        }



    }
}

