using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Assignment_6
{
    class Class1
    {
        static void Main(String[] args) {
            Console.WriteLine("Enter a sentence to find the words starts with A and ends with m");
            string str = Console.ReadLine();
            string[] words = str.Split(' ');
            Console.WriteLine("---Output by using normal logic -----");
            foreach (var v in words)
            {
                if (v.StartsWith("A", StringComparison.OrdinalIgnoreCase) && (v.EndsWith("M", StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine(v);
                }
            }
            Console.WriteLine("----------Using Query Expression----------- ");
            Console.WriteLine("---Output by using query(LOGIC 2)------");
            var filterwords = from word in words
                    where word.StartsWith("A", StringComparison.OrdinalIgnoreCase) && word.EndsWith("M", StringComparison.OrdinalIgnoreCase)
                    select word;
            foreach(var word in filterwords)
            {
                Console.WriteLine(word);
            }

            Console.ReadLine();
        }
    }
}

