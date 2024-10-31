using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrays_all__Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10] { 92, 93, 95, 97, 100, 86, 93, 99, 89, 90 };
            int total = 0;
            for(int i = 0; i <= a.Length - 1; i++)
            {
                total += a[i];
            }
            Console.WriteLine(total);
            int size = a.Length;
           int avg = (total / size);
            Console.WriteLine(avg);
            int min = a[0];
            for (int i = 0; i <= a.Length - 1; i++)
            {
                if (a[i] < min)
                    min = a[i];
            }
            Console.WriteLine(min);
            int max = a[0];
            for (int i = 0; i <= a.Length - 1; i++)
            {
                if (a[i] > max)
                    max = a[i];
            }
            Console.WriteLine(max);
            









        }
    }
}
