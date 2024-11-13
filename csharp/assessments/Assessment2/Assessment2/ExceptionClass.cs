using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    class ExceptionClass
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter a positive integer: ");
                int num = Convert.ToInt32(Console.ReadLine());

                CheckIfPositive(num);
                Console.WriteLine("The number is positive.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.Read();
        }

        static void CheckIfPositive(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("The number cannot be negative.");
            }
        }
    }
}
