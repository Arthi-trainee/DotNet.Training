using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
       static void Main(string[] args)
        {
            Console.WriteLine("what is your name?");
            char s;
            s = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("how are you: " + s);
            Console.Read();
        }
    }
}
