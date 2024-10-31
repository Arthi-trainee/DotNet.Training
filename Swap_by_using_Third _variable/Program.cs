using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            int c;
            c = b;
            b = a;
            a = c;
            Console.WriteLine("a=" + a + " and b=" + b);
            Console.ReadLine();


        }
    }
}
