using System;



using System.IO;

namespace program1

{

    class Program

    {

        static void Main(string[] args)

        {

            string file = "file.txt";

            Console.WriteLine("Enter a Text to Append to the existing file");

            string text = Console.ReadLine();

            if (File.Exists(file))

            {

                File.AppendAllText(file, text + "\n");

            }

            else

            {

                File.WriteAllText(file, text + "\n");

            }

            Console.WriteLine("---------- solution using StreamWriter---------------");

            using (StreamWriter str = new StreamWriter(file, append: true))

            {

                str.Write(text + "\n");

            }

            Console.WriteLine("Text has been appended Succesfully");

            Console.ReadLine();

        }

    }

}

