using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Min_Max_Avg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] a = new int[5] { 1, 2, 3, 4, 5 };
            int sum = 0;
            int size = a.Length();
            for(int i = 0; i <= a.Length-1; i++)
            {
                sum += a[i];
            }
            int avg = (sum / size);
            Console.WriteLine(avg);
            
            int min = a[0];
            for(int i = 1; i <= a.Length-1; i++)
            {
                if (a[i] < min)
                    min = a[i];

            }
            Console.WriteLine(min);
            
            int max = a[0];
            for(int i=1;i<=a.Length-1;i++)
            {
                if (a[i] > max)
                    max = a[i];

            }
            Console.WriteLine(max);

            Console.ReadLine();




        }
    }
}
