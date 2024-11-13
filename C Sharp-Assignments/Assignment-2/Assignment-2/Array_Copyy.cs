using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_copy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5] { 1, 2, 3, 4, 5 };
            int[] b = new int[5];
            int i = 0;
            while (i < b.Length)
            {
                b[i] = a[i];
                i++;

            }

            foreach (int value in b)
            {
                Console.WriteLine(value);
            }
            Console.ReadLine();

        }
    }
}