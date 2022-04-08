using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    public class helper
    {
        double h;
        double moments0, moments1, moments2, moments3;
        double a1, a2;
        double x1, x2;
        double A_kv1, A_kv2;

        public double Simpson(double a, double b, int n, int p)
        {
            double result_1 = 0.0;
            double result_2 = 0.0;
            double result_3 = 0.0;
            double h_2 = h / 2.0;
            double x_k;
            if (p == 0)
            {
                for (int i = 0; i <= 2 * n; i++)
                {
                    x_k = a + i * h_2;
                    if (i == 0 || i == (2 * n))
                    {
                        result_1 += Function_F(x_k) * Function_P(x_k, 0);
                    }
                    if ((i != 0) && (i != 2 * n) && (i % 2 == 1))
                    {
                        result_2 += 4 * Function_F(x_k) * Function_P(x_k, 0);
                    }
                    if ((i != 0) && (i != 2 * n) && (i % 2 == 0))
                    {
                        result_3 += 2 * Function_F(x_k) * Function_P(x_k, 0);
                    }
                }
                return (result_1 + result_2 + result_3) * h_2 / 3.0;
            }
            else
            {
                for (int i = 0; i <= 2 * n; i++)
                {
                    x_k = a + i * h_2;
                    if (i == 0 || i == (2 * n))
                    {
                        result_1 += Function_F(x_k) * Function_P_2(x_k);
                    }
                    if ((i != 0) && (i != 2 * n) && (i % 2 == 1))
                    {
                        result_2 += 4 * Function_F(x_k) * Function_P_2(x_k);
                    }
                    if ((i != 0) && (i != 2 * n) && (i % 2 == 0))
                    {
                        result_3 += 2 * Function_F(x_k) * Function_P_2(x_k);
                    }
                }
                return (result_1 + result_2 + result_3) * h_2 / 3.0;
            }

        }
        double Function_F(double x)
        {
            return Math.Sin(x);
        }
        double Function_P(double x, int k)
        {
            if (k == 0)
            {
                return Math.Pow(x, 1 / 2.0);

            }
            if (k == 1)
            {
                return Math.Pow(x, 1 / 2.0) * x;
            }
            if (k == 2)
            {
                return Math.Pow(x, 1 / 2.0) * Math.Pow(x, 2);
            }
            else
            {
                return Math.Pow(x, 1 / 2.0) * Math.Pow(x, 3);
            }

        }
        double Function_P_2(double x)
        {
            return 1.0 / Math.Sqrt(1 - Math.Pow(x, 2));
        }
        double Middle_Square(double a, int n, int k)
        {
            double result = 0.0;
            for (int i = 1; i <= n; i++)
            {
                result += h * Function_P(a + h / 2.0 + (i - 1) * h, k);
            }
            return result;
        }
        public void Moments(double a, double b, int n)
        {
            h = (b - a) / n;
            double discriminant;
            moments0 = Middle_Square(a, n, 0);
            moments1 = Middle_Square(a, n, 1);
            moments2 = Middle_Square(a, n, 2);
            moments3 = Middle_Square(a, n, 3);
            Console.WriteLine("Нулевой момент = " + moments0);
            Console.WriteLine("Первый момент = " + moments1);
            Console.WriteLine("Второй момент = " + moments2);
            Console.WriteLine("Третий момент = " + moments3);
            a1 = (moments0 * moments3 - moments2 * moments1) / (moments1 * moments1 - moments0 * moments2);
            a2 = (moments2 * moments2 - moments3 * moments1) / (moments1 * moments1 - moments0 * moments2);
            discriminant = Math.Sqrt(a1 * a1 - 4 * a2);
            x1 = (-a1 + discriminant) / 2.0;
            x2 = (-a1 - discriminant) / 2.0;
            A_kv1 = 1 / (x1 - x2) * (moments1 - x2 * moments0);
            A_kv2 = 1 / (x2 - x1) * (moments1 - x1 * moments0);
            Console.WriteLine("Ортогональный многочлен = x^2 - (" + (x1 + x2) + ")*x + " + x1 * x2);
            Console.WriteLine("Узел x1 КФ = " + x1);
            Console.WriteLine("Узел x2 КФ = " + x2);
            Console.WriteLine("Коэфициент A1 КФ = " + A_kv1);
            Console.WriteLine("Коэфициент A2 КФ = " + A_kv2);



            if (x1 != x2)
            {
                Console.WriteLine("Узлы x1 и x2 различны");
            }
            else
            {
                Console.WriteLine("Узлы x1 и x2 совпадают");
            }
            if (A_kv1 >= 0 && A_kv2 >= 0)
            {
                Console.WriteLine("Коэфициенты КФ A1 и A2 больше ноля");
            }
            else
            {
                Console.WriteLine("Коэфициенты КФ A1 и A2 меньше ноля");
            }
            if (ISEqual((A_kv1 + A_kv2), moments0))
            {
                Console.WriteLine("Сумма коэфициентов КФ A1 и A2 равна нулевому моменту");
            }
            else
            {
                Console.WriteLine("Сумма коэфициентов КФ A1 и A2 НЕ равна нулевому моменту");
            }

            Console.Write("Интеграл по формуле типа Гаусса =  ");
            Console.WriteLine(A_kv1 * Function_F(x1) + A_kv2 * Function_F(x2));
            Console.Write("Погрешность = ");
            Console.WriteLine(Math.Abs((A_kv1 * Function_F(x1) + A_kv2 * Function_F(x2)) - Simpson(a, b, n, 0)));

        }

        public void Gauss(double a, double b, int n)
        {
            h = (b - a) / n;
            double integral = 0;
            double Zk = a;
            double t1 = -1.0 / Math.Sqrt(3);
            double t2 = 1.0 / Math.Sqrt(3);
            for (int i = 0; i < n; i++)
            {
                x1 = (h / 2) * t1 + Zk + h / 2;
                x2 = (h / 2) * t2 + Zk + h / 2;

                integral += (h / 2) * (Function_F(x1) * Function_P(x1, 0) + Function_F(x2) * Function_P(x2, 0));

                Zk += h;
            }
            Console.WriteLine("Точное значение интеграла = " + Simpson(a, b, n, 0));
            Console.Write("Значение интеграла по формуле Гауса = ");
            Console.WriteLine(integral);
            Console.Write("Погрешность = ");
            Console.WriteLine(Math.Abs(integral - Simpson(a, b, n, 0)));
        }
        public void Meller(double a, double b, int n)
        {
            Console.WriteLine("Точное значение интеграла = 0");
            double result = 0.0;
            double constant = Math.PI / n;
            for (int i = 1; i <= n; i++)
            {
                double x = Math.Cos(((double)(2.0 * i - 1.0) / (2.0 * n)) * Math.PI);
                Console.WriteLine("Узел " + i + " = " + x);
                result += Function_F(x);
                Console.WriteLine("Коэфициент" + i + " = " + constant * Function_F(x));
            }
            result = result * constant;
            Console.WriteLine("Значение интеграла вычисленное с помощью КФ Меллера = " + result);
            Console.Write("Погрешность = ");
            Console.WriteLine(Math.Abs(result - 0));
        }

        bool ISEqual(double x1, double x2)
        {
            if ((x1 - x2) < 0.000000001)
                return true;
            else return false;
        }
    }

}
