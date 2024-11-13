using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class Doctor
    {
        int regNo;
        string name;
        double fees_charged;
        public int RegNo
        {
            get
            {
                return regNo;
            }
            set
            {
                regNo = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }

        }
        public double Fees_charged
        {
            get
            {
                return fees_charged;
            }
            set
            {
                fees_charged = value;
            }


        }

    }
    class Books
    {
        string Book_Name;
        string Author_Name;
        public Books(string book_name, string author_name)
        {
            Book_Name = book_name;
            Author_Name = author_name;

        }
        public void Display()
        {
            Console.WriteLine("Book name is" + Book_Name);
            Console.WriteLine("Author  name is" + Author_Name);
        }
    }
    class Bookshelf
    {
        Books[] b = new Books[5];
        public Books this[int pos]
        {
            get
            {
                return b[pos];
            }
            set
            {
                b[pos] = value;
            }


        }
    }
    class Driver
    {
        public static void Main()
        {
            Console.WriteLine("Enter Doctor details");
            Console.WriteLine("Enter the Registred number");
            int regnum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Name");
            string Namee = Console.ReadLine();
            Console.WriteLine("the amoubnt of fee charged is");

            double fees = Convert.ToDouble(Console.ReadLine());
            Doctor d = new Doctor();
            Console.WriteLine("Doctor Details");
            d.RegNo = regnum;
            Console.WriteLine("Registration number" + d.RegNo);
            d.Name = Namee;
            Console.WriteLine("Name:" + d.Name);
            d.Fees_charged = fees;
            Console.WriteLine("fees chaged is: " + d.Fees_charged);

            Console.WriteLine("Enter Book Details");
            Console.WriteLine("Enter Book name");
            string bname = Console.ReadLine();
            Console.WriteLine("Enter author name");
            string aname = Console.ReadLine();
            Books b = new Books(bname, aname);
            Console.WriteLine("Book details");
            b.Display();
            Console.WriteLine(" ----- Using indexers ----");
            Bookshelf book_shelf = new Bookshelf();
            Console.WriteLine("Book details");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("enter Book name", i + 1);
                string bookname = Console.ReadLine();
                Console.WriteLine("enter author name", i + 1);
                string authorname = Console.ReadLine();
                book_shelf[i] = new Books(bookname, authorname);
            }
            Console.WriteLine("Book details as follows");
            for (int j = 0; j <= 5; j++)
            {
                book_shelf[j].Display();
            }
            Console.Read();
        }

    }
}
