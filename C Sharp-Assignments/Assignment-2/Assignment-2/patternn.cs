using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number for writing pattern");
            int n = Console.Read();
            Console.ReadLine();
            for (int i = 1; i <= 4; i++)
            {
                if (i % 2 != 0)
                    Console.WriteLine(n + " " + n + " " + n + " " + n);
                else

                    Console.WriteLine(n + "" + n + "" + n + "" + n);
            }
            Console.ReadLine();

        }
    }
}