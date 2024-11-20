using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @delegate
{
    class Calculator
    {
        public delegate int opearations(int a, int b);
        public static int Addition(int a, int b)

        {

            return a + b;

        }

        public static int Subtraction(int a, int b)

        {

            return a - b;

        }

        public static int Multiplication(int a, int b)

        {

            return a * b;

        }
        public static void Perform(opearations o, int a, int b)
        {
            int Result = o(a, b);
            Console.WriteLine("Result is " + Result);
        }
        public static void Main()

        {

            Console.WriteLine("Enter value of first number");

            int n1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter value of second number");

            int n2 = Convert.ToInt32(Console.ReadLine());
            Calculator.opearations Add = new Calculator.opearations(Calculator.Addition);
            Calculator.opearations sub = new Calculator.opearations(Calculator.Subtraction);
            Calculator.opearations Mul = new Calculator.opearations(Calculator.Multiplication);

            Console.WriteLine("Addition Result is ");
            Calculator.Perform(Add, n1, n2);
            Console.WriteLine("Substraction  Result is ");
            Calculator.Perform(sub, n1, n2);
            Console.WriteLine("Multiplication Result is ");
            Calculator.Perform(Mul, n1, n2);


            Console.ReadLine();


        }

    }

}

