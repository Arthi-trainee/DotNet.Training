using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter a number for writing Multiplication of a table");
            int n = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 1; i <= 10; i++)
            {
                int res = n * i;
                Console.WriteLine($"{n} * {i} = {res}");
                
            }
        }
    }
}
