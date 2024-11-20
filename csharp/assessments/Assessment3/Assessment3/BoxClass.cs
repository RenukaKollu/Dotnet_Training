using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }

      
        public Box(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }

        
        public static Box operator +(Box b1, Box b2)
        {
            return new Box(b1.Length + b2.Length, b1.Breadth + b2.Breadth);
        }

       
        public void Display()
        {
            Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");
        }
    }

    class Test
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter Length and Breadth for Box 1:");
            Console.Write("Length1: ");
            double length1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Breadth1: ");
            double breadth1 = Convert.ToDouble(Console.ReadLine());
            Box box1 = new Box(length1, breadth1);

           
            Console.WriteLine("Enter Length and Breadth for Box 2:");
            Console.Write("Length2: ");
            double length2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Breadth2: ");
            double breadth2 = Convert.ToDouble(Console.ReadLine());
            Box box2 = new Box(length2, breadth2);

           
            Box box3 = box1 + box2;

            Console.WriteLine("Details of the third box after addition:");
            box3.Display();
            Console.Read();
        }
    }
    
   
}
