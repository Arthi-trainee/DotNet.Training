﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    
    class Books
    {
        string Book_Name;
        string Author_Name;
        
        public Books(string Book_Name, string Author_Name)
        {
            this.Book_Name = Book_Name;
            this.Author_Name = Author_Name;
        }

        
        public void Display()
        {
            Console.WriteLine($"Title of the book is "+ Book_Name +"  and the Author of the book is"+ Author_Name);
        }
    }
    
    class BookShelf
    {
        public Books[] Book_list = new Books[5];  
        public Books this[int i]
        {
            get { return Book_list[i]; }
            set { Book_list[i] = value; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("----- Enter the Books details------");
            Console.WriteLine();
            string Book_Name;
            string Author_Name;

           
            BookShelf bs = new BookShelf();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Enter book {i + 1} details");
                Console.Write("Enter the book name : ");
                Book_Name = Console.ReadLine();
                Console.Write("Enter book Author name : ");
                Author_Name = Console.ReadLine();
                bs[i] = new Books(Book_Name, Author_Name);
            }

            Console.WriteLine();
            Console.WriteLine("-------Books Details------ ");
            Console.WriteLine();
            for (int j = 0; j < 5; j++)
            {
                bs[j].Display();
            }
            Console.ReadLine();

        }
    }
}