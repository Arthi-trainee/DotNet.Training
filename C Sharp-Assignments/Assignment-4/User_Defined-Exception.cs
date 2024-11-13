using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace Assignment_4

{


    class InsufficientBalanceException : ApplicationException
    {
        public InsufficientBalanceException(string msg):base(msg)
        {

        }
    }
    class Exception_Handling
    {
        public int amount;
        public string Transaction_type;
        public int balance;
        public Exception_Handling(int amt, int bal, string trans_type)
        {
            amount = amt;
            balance = bal;
            Transaction_type = trans_type;
        }
    
        public void Credit(int amount,int balance)

        {

            balance = balance + amount;
            Console.WriteLine("the current balance is" + balance);

        }

        public void Debit(int amount, int balance)

        {
            try
            {
                if (amount > balance)
                {
                    throw (new InsufficientBalanceException("Insufficient Balance ,Please  Enter a Valid Amount"));

                }
                else
                {
                    balance = balance - amount;
                    Console.WriteLine("the current balance is " + balance);
                }
            }
            catch (InsufficientBalanceException insufficient_balance)
            {
                Console.WriteLine(insufficient_balance.Message);
                Console.WriteLine(insufficient_balance.StackTrace);

            }
        }


       public void Update_Balance(string transac_type)

        {

            if (transac_type == "d" || transac_type == "D")

            {

                Credit(amount,balance);

            }

            else if (transac_type == "w" || transac_type == "W")

            {

                Debit(amount,balance);

            }

        }

       

   

        public static void Main(string[]args)

        {

            Console.WriteLine("Enter the Balance:");

            int bal = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Amount:");

            int amo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Transaction type: for debit:w(or) W    And for Credit :C(or) c");

            string trans_type = Console.ReadLine();

           


            Exception_Handling EH = new Exception_Handling(amo,bal,trans_type);
            EH.Update_Balance(trans_type);
            Console.ReadLine();

        }

    }

}

