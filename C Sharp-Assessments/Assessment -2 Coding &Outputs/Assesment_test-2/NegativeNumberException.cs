using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assesment_2
{
    class NegativeNumberException : ApplicationException
    {
        public NegativeNumberException(string msg) : base(msg) { }

          static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a Integer  ");
                int n = Convert.ToInt32(Console.ReadLine());
                
                Check_positive_or_negative(n);
                Console.WriteLine("The given number is positive");
                Console.ReadLine();
            }
            catch (NegativeNumberException NNE)
            {
                Console.WriteLine(NNE.Message);
                Console.WriteLine(NNE.StackTrace);
                Console.ReadLine();

            }
        }
        static void Check_positive_or_negative(int number)
        {
            {
                if (number < 0)
                {
                    throw new NegativeNumberException("Dear user please enter a valid number");
                }



            }
        }
    }
}
