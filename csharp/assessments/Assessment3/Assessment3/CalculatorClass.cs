using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    public delegate int CalculatorDelegate(int a, int b);
    class CalculatorClass
    {
        static int Add(int a, int b)
        {
            return a + b;
        }

        static int Subtract(int a, int b)
        {
            return a - b;
        }

        static int Multiply(int a, int b)
        {
            return a * b;
        }

        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the first integer:");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the second integer:");
            int num2 = Convert.ToInt32(Console.ReadLine());

            
            CalculatorDelegate addDelegate = Add;
            CalculatorDelegate subtractDelegate = Subtract;
            CalculatorDelegate multiplyDelegate = Multiply;

           
            int additionResult = addDelegate(num1, num2);
            int subtractionResult = subtractDelegate(num1, num2);
            int multiplicationResult = multiplyDelegate(num1, num2);

            
            Console.WriteLine($"Addition of {num1} and {num2} is: {additionResult}");
            Console.WriteLine($"Subtraction of {num1} and {num2} is: {subtractionResult}");
            Console.WriteLine($"Multiplication of {num1} and {num2} is: {multiplicationResult}");
            Console.Read();
        }
    }
}
