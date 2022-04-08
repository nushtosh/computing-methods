using System;

namespace lab_six
{
    class Program
    {
        static void Main(string[] args)
        {
            help cl = new help();
            cl.exact();
            cl.eul();
            cl.adams();
            cl.rungekutt();
        }
    }
}
