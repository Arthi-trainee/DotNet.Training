using System;


using System.Collections.Generic;


using System.Linq;


using System.Text;


using System.Threading.Tasks;

namespace app_2


{


    internal class Program


    {


        static void Main(string[] args)


        {


            int Calculator(int a, int b, out int sum, out int product, out int division)


            {


                sum = a + b;  //addition


                product = a * b;//multiplication


                division = a / b;//division


                return a - b; // difference


            }


            Console.WriteLine("-------Output Parameters--------");

            int Total, Product, div;

            div = Calculator(12, 6, out Total, out Product, out div);


            Console.WriteLine("Sum = {0} Product = {1} and division={2}", Total, Product, div);


            Console.Read();


        }


    }


}

