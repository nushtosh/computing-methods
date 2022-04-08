using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{

    public class help
    {
        double a; double b;
        int m;
        public List<double> Sections = new List<double>();
        int counter;
        double moments0;
        double moments1;
        double moments2;
        double moments3;
        double a2;
        double a1;
        public List<double>[] uz = new List<double>[9];
        public List<double>[] ko = new List<double>[9];

        public List<double> knots = new List<double>();
        public List<double> koef = new List<double>();
        public double f(double x)
        {
            return (double)Math.Sin(x)*Math.Sin(2*x);
        }
        public void st()
        {
            for (int i = 0; i < 9; i++)
            {
                uz[i] = new List<double>();
                ko[i] = new List<double>();
            }
        }
        public double SKFG(int k,int m)
        {
            double integ = 0;
            double a = 0;
            double b = 1;
            double h = (double)(b - a) / m;
            double q = (double)h/2;
            while (a < b)
            {
                double res1 = 0;
                for (int i = 0; i < uz[k].Count; i++)
                {
                    res1 += q * ko[k][i] * f(a + q * (uz[k][i] + 1));
                }
                a =a+h;
                integ = integ + res1;
            }
            return integ;
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

        public void tableknots(int k)
        {
            for (int i = 1; i < 9; i++)
            {
                p1(-1, 1, i);
                for (int ka = 0; ka < Sections.Count; ka++)
                    sek(Sections[ka], Sections[++ka], Math.Pow(10, -12), i);

                koefG(i);
                //Console.WriteLine();
                //Console.WriteLine("Количество узлов: " + i);
                //Console.WriteLine("УЗЛЫ            КОЭФИЦИЕНТЫ");
                //for (int ka = 0; ka < i; ka++)
                //{
                //    Console.WriteLine(uz[i][ka] + "   " + ko[i][ka]);
                //}

            }
            //Console.WriteLine("УЗЛЫ            КОЭФИЦИЕНТЫ");
            //for (int ka = 0; ka < k; ka++)
            //{
            //    Console.WriteLine(uz[k][ka] + "   " + ko[k][ka]);
            //}

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

        public void alike(double c, double d, int k)
        {
            c = 0;
            d = 1;
            double q = (double)((d - c) / 2);
            for (int i = 0; i < uz[k].Count; i++)
            {
                ko[k][i] = ko[k][i] * q;
                uz[k][i] = c + q * (uz[k][i] + 1);
            }
            Console.WriteLine("УЗЛЫ            КОЭФИЦИЕНТЫ");
            for (int ka = 0; ka < uz[k].Count; ka++)
            {
                Console.WriteLine(uz[k][ka] + "     " + ko[k][ka]);
            }
        }




        double Function_P(double x, int k)
        {
            if (k == 0)
            {
                return (Math.Sin(2*x));

            }
            if (k == 1)
            {
                return Math.Sin(2 * x) * x;
            }
            if (k == 2)
            {
                return Math.Sin(2 * x) * Math.Pow(x, 2);
            }
            else
            {
                return Math.Sin(2 * x) * Math.Pow(x, 3);
            }

        }
        double Fx(double x, int k)
        {
            if (k == 0)
            {
                return (1);

            }
            if (k == 1)
            {
                return 1 * x;
            }
            if (k == 2)
            {
                return 1 * Math.Pow(x, 2);
            }
            else
            {
                return 1 * Math.Pow(x, 3);
            }

        }
        double Middle_Squarex(double a, int n, int k)
        {
            double h = (double)1 / n;
            double result = 0.0;
            for (int i = 1; i <= n; i++)
            {
                result = result + h * Fx(a + (i + (double)1 / 2) * h, k);
            }
            return result;
        }
        double Middle_Square(double a, int n, int k)
        {
            double h = (double)1/n;
            double result = 0.0;
            for (int i = 1; i <= n; i++)
            {
                result =result+ h * Function_P(a + (i + (double)1/2) * h, k);
            }
            return result;
        }
        public void Moments(double a, double b, int n)
        {
            double h = (double)(b - a) / n;
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
            double x1 = (-a1 + discriminant) / 2.0;
            double x2 = (-a1 - discriminant) / 2.0;
            double A_kv1 = 1 / (x1 - x2) * (moments1 - x2 * moments0);
            double A_kv2 = 1 / (x2 - x1) * (moments1 - x1 * moments0);
            Console.WriteLine("Ортогональный многочлен = x^2 - (" + (x1 + x2) + ")*x + " + x1 * x2);
            Console.WriteLine("Узел x1 КФ = " + x1);
            Console.WriteLine("Узел x2 КФ = " + x2);
            Console.WriteLine("Коэфициент A1 КФ = " + A_kv1);
            Console.WriteLine("Коэфициент A2 КФ = " + A_kv2);



            //if (x1 != x2)
            //{
            //    Console.WriteLine("Узлы x1 и x2 различны");
            //}
            //else
            //{
            //    Console.WriteLine("Узлы x1 и x2 совпадают");
            //}
            //if (A_kv1 >= 0 && A_kv2 >= 0)
            //{
            //    Console.WriteLine("Коэфициенты КФ A1 и A2 больше ноля");
            //}
            //else
            //{
            //    Console.WriteLine("Коэфициенты КФ A1 и A2 меньше ноля");
            //}
            //if (ISEqual((A_kv1 + A_kv2), moments0))
            //{
            //    Console.WriteLine("Сумма коэфициентов КФ A1 и A2 равна нулевому моменту");
            //}
            //else
            //{
            //    Console.WriteLine("Сумма коэфициентов КФ A1 и A2 НЕ равна нулевому моменту");
            //}

            Console.Write("Интеграл по формуле типа Гаусса =  ");
            Console.WriteLine(A_kv1 * Function_F(x1) + A_kv2 * Function_F(x2));

        }
        double Function_F(double x)
        {
            return Math.Sin(x);
        }
        double Function_Fx(double x)
        {
            return Math.Pow(x,3);
        }
        bool ISEqual(double x1, double x2)
        {
            if ((x1 - x2) < 0.000000001)
                return true;
            else return false;
        }

        public void Momentsx(double a, double b, int n)
        {
            double h = (double)(b - a) / n;
            double discriminant;
            moments0 = Middle_Squarex(a, n, 0);
            moments1 = Middle_Squarex(a, n, 1);
            moments2 = Middle_Squarex(a, n, 2);
            moments3 = Middle_Squarex(a, n, 3);
            Console.WriteLine("Нулевой момент = " + moments0);
            Console.WriteLine("Первый момент = " + moments1);
            Console.WriteLine("Второй момент = " + moments2);
            Console.WriteLine("Третий момент = " + moments3);
            a1 = (moments0 * moments3 - moments2 * moments1) / (moments1 * moments1 - moments0 * moments2);
            a2 = (moments2 * moments2 - moments3 * moments1) / (moments1 * moments1 - moments0 * moments2);
            discriminant = Math.Sqrt(a1 * a1 - 4 * a2);
            double x1 = (-a1 + discriminant) / 2.0;
            double x2 = (-a1 - discriminant) / 2.0;
            double A_kv1 = 1 / (x1 - x2) * (moments1 - x2 * moments0);
            double A_kv2 = 1 / (x2 - x1) * (moments1 - x1 * moments0);
            Console.WriteLine("Ортогональный многочлен = x^2 - (" + (x1 + x2) + ")*x + " + x1 * x2);
            Console.WriteLine("Узел x1 КФ = " + x1);
            Console.WriteLine("Узел x2 КФ = " + x2);
            Console.WriteLine("Коэфициент A1 КФ = " + A_kv1);
            Console.WriteLine("Коэфициент A2 КФ = " + A_kv2);



            //if (x1 != x2)
            //{
            //    Console.WriteLine("Узлы x1 и x2 различны");
            //}
            //else
            //{
            //    Console.WriteLine("Узлы x1 и x2 совпадают");
            //}
            //if (A_kv1 >= 0 && A_kv2 >= 0)
            //{
            //    Console.WriteLine("Коэфициенты КФ A1 и A2 больше ноля");
            //}
            //else
            //{
            //    Console.WriteLine("Коэфициенты КФ A1 и A2 меньше ноля");
            //}
            //if (ISEqual((A_kv1 + A_kv2), moments0))
            //{
            //    Console.WriteLine("Сумма коэфициентов КФ A1 и A2 равна нулевому моменту");
            //}
            //else
            //{
            //    Console.WriteLine("Сумма коэфициентов КФ A1 и A2 НЕ равна нулевому моменту");
            //}

            Console.Write("Интеграл по формуле типа Гаусса =  ");
            Console.WriteLine(A_kv1 * Function_Fx(x1) + A_kv2 * Function_Fx(x2));

        }
    }
}


