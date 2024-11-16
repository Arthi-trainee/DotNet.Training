using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class Square_greater_than_20
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers with spaces");
            string input = Console.ReadLine();
            input.Split().Select(int.Parse).Where(n=>n*n>20).ToList().ForEach(n=>Console.WriteLine($"{n}-{n*n}"));

           
            Console.ReadLine();

        }
    }
}
