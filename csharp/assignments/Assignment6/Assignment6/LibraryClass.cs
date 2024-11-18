﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class LibraryClass
    {
        static void Main()
        {
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your Age: ");
            int age = int.Parse(Console.ReadLine());

            ConcessionCalculator concessionCalculator = new ConcessionCalculator();

            string result = concessionCalculator.CalculateConcession(age);

            Console.WriteLine($"Hello {name}, {result}");

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
