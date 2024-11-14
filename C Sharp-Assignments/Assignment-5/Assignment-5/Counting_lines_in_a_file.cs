using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_5
{
    // Write a program in C# Sharp to count the number of lines in a file.
    class Count
    {
        static void Main()
        {
            string path = "C:\\arthi_1\\C Sharp-Assignments\\Assignment-5\\csharp_file.txt";
            if (File.Exists(path))
            {
                int lineCount = File.ReadAllLines(path).Length;
                Console.WriteLine("The number of lines in program are :" + lineCount);
            }
            else
            {
                Console.WriteLine("The specified path does not exist");
            }
            Console.ReadLine();
        }
    }
}
