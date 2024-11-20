using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace program1
{
    class Box
    {
        public int length { get; set; }
        public int breadth { get; set; }
        public void Addition_of_boxes(Box box1, Box box2)
        {
            this.length = box1.length + box2.length;
            this.breadth = box1.breadth + box2.breadth;

        }
        public void Display()
        {
            Console.WriteLine("Length " + length + "  and Breadth is  " + breadth);
        }
    }
    class Test
    {
        public static void Main(string[] args)

        {
            Box b1 = new Box();
            Box b2 = new Box();
            Box b3 = new Box();
            Console.WriteLine("Enter the Length and Breadth of Box-1");
            b1.length = Convert.ToInt32(Console.ReadLine());
            b1.breadth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Length and Breadth of Box-2");
            b2.length = Convert.ToInt32(Console.ReadLine());
            b2.breadth = Convert.ToInt32(Console.ReadLine());
            b3.Addition_of_boxes(b1, b2);
            Console.WriteLine("------The details of 3 rd box -----");
            b3.Display();
            Console.ReadLine();


        }
    }
}
