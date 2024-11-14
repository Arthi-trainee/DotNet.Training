using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_5
{
    class File_string
    {
        
        static void Main()
        {
            string[] strings = new string[3];
            for (int i = 0; i < strings.Length; i++)
            {
                Console.Write($"Enter string {i + 1} : ");
                strings[i] = Console.ReadLine();
            }
            string path = "C:\\arthi_1\\C Sharp-Assignments\\Assignment-5\\arthi_txt";
            FileStream filestrem = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter streamwriter = new StreamWriter(filestrem);
            foreach (string str in strings)
            {
                streamwriter.WriteLine(str);
            }
            Console.WriteLine("Given Writing permission successfully");
            streamwriter.Flush();
            streamwriter.Close();
            filestrem.Close();
            Console.ReadLine();
        }
    }
}
