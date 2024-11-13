using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    abstract class Student
    {
        public string Name { get; set; }
        public string StudentId { get; set; }
        public double Grade { get; set; }

        public Student(string name, string studentId, double grade)
        {
            Name = name;
            StudentId = studentId;
            Grade = grade;
        }

        public abstract bool IsPassed(double grade);
    }

    class Undergraduate : Student
    {
        public Undergraduate(string name, string studentId, double grade)
            : base(name, studentId, grade) { }

        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }

    class Graduate : Student
    {
        public Graduate(string name, string studentId, double grade)
            : base(name, studentId, grade) { }

        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    class AbstractClass
    {
        static void Main()
        {
            
            Console.WriteLine("Enter  the Undergraduate Student details: ");
            Console.Write("Name: ");
            string uName = Console.ReadLine();
            Console.Write("Student ID: ");
            string uId = Console.ReadLine();
            Console.Write("Grade: ");
            double uGrade = Convert.ToDouble(Console.ReadLine());

            Undergraduate UG = new Undergraduate(uName, uId, uGrade);
            Console.WriteLine($"Undergraduate Student {UG.Name} Passed: {UG.IsPassed(UG.Grade)}");

            
            Console.WriteLine("\nEnter the Graduate Student details: ");
            Console.Write("Name: ");
            string gName = Console.ReadLine();
            Console.Write("Student ID: ");
            string gId = Console.ReadLine();
            Console.Write("Grade: ");
            double gGrade = Convert.ToDouble(Console.ReadLine());

            Graduate grad = new Graduate(gName, gId, gGrade);
            Console.WriteLine($"Graduate Student {grad.Name} Passed: {grad.IsPassed(grad.Grade)}");
            Console.Read();
        }
    }
}
