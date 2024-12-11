using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace Assignment_1

{

    class Employee

    {

        public int EmployeeID;

        public string FirstName;

        public string LastName;

        public string Title;

        public DateTime DOB;

        public DateTime DOJ;

        public string City;

    }

    class Program

    {

        static void Main(string[] args)

        {

            var employees = new List<Employee>

              {

                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla",Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },

                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla",Title = "AsstManager", DOB = new DateTime(1984, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai"},

                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza",Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },

                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh",Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },

                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh",Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },

                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak",Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },

                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan",Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" },

                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey",Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Chennai" },

                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry",Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 12, 3), City = "Chennai" },

                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah",Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }

            };

            //1.Display a list of all the employee who have joined before 1 / 1 / 2015

            Console.WriteLine("==============================Display a list of all the employee who have joined before 1 / 1 / 2015 ===========================");

            var employee1 = employees.Where(e => e.DOJ < new DateTime(2015, 1, 1)).Select(n => n);

            foreach (var emp in employee1)

            {

                Console.WriteLine($" Employee Name : {emp.FirstName}{emp.LastName} , DOJ : {emp.DOJ.ToShortDateString()}");

            }

            //2. Display a list of all the employee whose date of birth is after 1/1/1990

            Console.WriteLine("===============================Display a list of all the employee whose date of birth is after 1/1/1990===================");

            var employee2 = employees.Where(e => e.DOB > new DateTime(1990, 1, 1)).Select(n => n);

            foreach (var emp in employee2)

            {

                Console.WriteLine($"Employee Name : {emp.FirstName}{emp.LastName}, DOB : {emp.DOB.ToShortDateString()}");

            }


            //3. Display a list of all the employee whose designation is Consultant and Associate

            Console.WriteLine("=========================Display a list of all the employee whose designation is Consultant and Associate========================");

            var employee3 = employees.Where(e => e.Title == "Consultant" || e.Title == "Associate").Select(n => n);

            foreach (var emp in employee3)

            {

                Console.WriteLine($"Employee Name : {emp.FirstName}{emp.LastName} , Title : {emp.Title}");

            }

            //4. Display total number of employees

            Console.WriteLine("==========================Display total number of employees========================");

            var employee4 = employees.Count();

            Console.WriteLine("=========================Number of Employees : {0} ", employee4);

            //5. Display total number of employees belonging to “Chennai”

            Console.WriteLine("=============================Display total number of employees belonging to “Chennai====================== ");

            var employee5 = employees.Where(e => e.City == "Chennai").Count();

            Console.WriteLine("Number of Employees : {0} ", employee5);

            //6. Display highest employee id from the list

            Console.WriteLine("===============================Display highest employee id from the list=======================");

            var employee6 = employees.Select(e => e.EmployeeID).Max();

            Console.WriteLine("                         highest employee id : {0} ", employee6           );

            //7. Display total number of employee who have joined after 1/1/2015

            Console.WriteLine("===========================Display a list of all the employee who have joined after 1 / 1 / 2015==========================");

            var employee7 = employees.Where(e => e.DOJ > new DateTime(2015, 1, 1)).Select(n => n);

            foreach (var emp in employee7)

            {

                Console.WriteLine($"Employee Name : {emp.FirstName}{emp.LastName},DOJ : {emp.DOJ.ToShortDateString()} ");

            }

            //8. Display total number of employee whose designation is not “Associate”

            Console.WriteLine("========================== Display total number of employee whose designation is not “Associate==========================");

            var employee8 = employees.Where(e => e.Title != "Associate").Count();

            Console.WriteLine("=============================total number of employees whose designation is not Associate : {0}", employee8);

            //9. Display total number of employee based on City

            Console.WriteLine("===========================Display total number of employee based on City=======================");

            var employee9 = employees.GroupBy(e => e.City);

            foreach (var emp in employee9)

            {

                Console.WriteLine($"{emp.Key} : {emp.Count()}");

            }

            //10. Display total number of employee based on city and title

            Console.WriteLine("===================Display total number of employee based on city and title =================");

            var employee10 = employees.GroupBy(e => (e.City, e.Title));

            foreach (var emp in employee10)

            {

                Console.WriteLine($"{emp.Key.City} , {emp.Key.Title}: {emp.Count()}");

            }

            //11. Display total number of employee who is youngest in the list

            Console.WriteLine("=========================Display total number of employee who is youngest in the list ====================");

            var employee11 = employees.OrderBy(e => e.DOB).Last();

            Console.WriteLine("employee who is youngest in the list : ");

            Console.WriteLine($"Employee Id : {employee11.EmployeeID} , Employee Name : {employee11.FirstName}{employee11.LastName} , Title : {employee11.Title} , DOJ : {employee11.DOB.ToShortDateString()} , City : {employee11.City}");

            Console.Read();

        }

    }

}
