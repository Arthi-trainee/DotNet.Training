using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public interface IStudent
    {
        int Student_Id { get; set; }
        string Name { get; set; }
        void show_details();
    }


    class Day_Scholar : IStudent
    {
        public int Student_Id { get; set; }
        public string Name { get; set; }
        public void show_details()
        {
            Console.WriteLine("Student id " + Student_Id + "Student name" + Name);
        }

    }
    class Resident : IStudent
    {
        public int Student_Id { get; set; }
        public string Name { get; set; }
        public void show_details()
        {
            Console.WriteLine("Student id " + Student_Id + "Student name" + Name);
        }
    }


    class Interface
    {
        static void Main()
        {
            Console.WriteLine("DAY Scholar Student details");
            Console.WriteLine("Enter Student Id");
            int stud_id1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student name");
            string stud_name1 = Console.ReadLine();
            Console.WriteLine("Resident student details");
            Console.WriteLine("Enter Student Id");
            int stud_id2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student name");
            string stud_name2 = Console.ReadLine();
            IStudent d = new Day_Scholar();
            d.Student_Id = stud_id1;
            d.Name = stud_name1;
            Console.WriteLine("Day scholar Details");
            d.show_details();

            IStudent r = new Resident();
            r.Student_Id = stud_id1;
            r.Name = stud_name2;
            Console.WriteLine("Resident students details");
            r.show_details();
            Console.Read();

        }

    }
}

    
    

