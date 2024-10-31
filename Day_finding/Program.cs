using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_finding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number  from 1 to 7 to find  day");
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
                Console.WriteLine("Monday");
            else if (n == 2)
                Console.WriteLine("Tuesday");
            else if (n == 3)
                Console.WriteLine("Wednessday");
            else if (n == 4)
                Console.WriteLine("Thursday");
            else if (n == 5)
                Console.WriteLine("friday");
            else if (n == 6)
                Console.WriteLine("Saturday");
            else if (n == 7)
                Console.WriteLine("Sunday");
            else
                Console.WriteLine("Invalid Day");
            Console.ReadLine();
        }

    }

}
