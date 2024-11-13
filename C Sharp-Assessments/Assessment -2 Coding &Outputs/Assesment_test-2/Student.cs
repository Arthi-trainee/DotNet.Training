using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }
        public Student(string name, int studentId, double grade)
        {
            Name = name;
            StudentId = studentId;
            Grade = grade;
        }
        public abstract bool IsPassed(double grade);

    }
    class UnderGraduate : Student
    {
        public UnderGraduate(string name, int studentId, double grade) : base(name, studentId, grade) { }
        public override bool IsPassed(double grade)
        {
            return grade >= 70.0;
        }

    }
    class Graduate : Student
    {
        public Graduate(string name, int studentId, double grade) : base(name, studentId, grade) { }
        public override bool IsPassed(double grade)
        {
            return grade >= 80.0;
        }

    }
    class Check_Passed_Or_Not
    {
        static void Main()
        {
            Console.WriteLine("enter student type (under graduate or Graduate)");
            string type = Console.ReadLine();
            Console.WriteLine("enter the name");
            string name = Console.ReadLine();
            Console.WriteLine("enter student Id : ");
            int studentId = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the grade: ");
            double grade = double.Parse(Console.ReadLine());
            Student student;
            if (type.ToLower() == "undergraduate")
            {
                student = new UnderGraduate(name, studentId, grade);

            }
            else if (type.ToLower() == "graduate")
            {
                student = new Graduate(name, studentId, grade);

            }
            else
            {
                Console.WriteLine("Invalid student type");
                return;
            }
            Console.WriteLine($"{student.Name}(ID: {student.StudentId})has grade{ student.Grade}");
            if (student.IsPassed(student.Grade))
            {
                Console.WriteLine("the student has passed");
            }
            else
            {
                Console.WriteLine("the student is not passed");
            }
            Console.Read();

        }
    }
}
