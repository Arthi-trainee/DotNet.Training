using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace Assesment_2

{

    // Create an Abstract class Student with  Name, StudentId, Grade as

    // members and also an abstract method Boolean Ispassed(grade)

    // which takes grade as an input and checks whether student passed the course or not

    abstract class Student

    {

        public abstract void Ispassed(bool grade);

        public void fail()

        {

            Console.WriteLine("Student was failed");

        }

    }

    class Details : Student

    {

        public string Student_name;

        public int Student_id;

        public bool Grade = true;

        public bool grade;

        void Getdata()

        {

            Console.Write("Enter student name : ");

            Student_name = Console.ReadLine();

            Console.Write("Enter student id : ");

            Student_id = Convert.ToInt32(Console.ReadLine());


        }

        public override void Ispassed(bool grade)

        {

            if (Grade == this.grade) Console.WriteLine("Student is Pass");

            else fail();

        }

        static void Main()

        {

            Console.Write("Enter student grade : ");

            bool grade = Convert.ToBoolean(Console.ReadLine());

            Details d1 = new Details();

            d1.Getdata();

            d1.Ispassed(grade);

            Console.ReadLine();

        }

    }

}

