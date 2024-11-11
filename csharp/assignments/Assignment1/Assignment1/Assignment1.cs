using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Assignment1
    {
        static void CheckEqualNum()
        {
            Console.Write("Enter 1st num: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter 2nd num: ");
            int num2 = int.Parse(Console.ReadLine());

            if (num1 == num2)
            {
                Console.WriteLine("num1={0} and num2={1} are equal", num1, num2);
            }
            else
            {
                Console.WriteLine("num1={0} and num2={1} are not equal", num1, num2);
            }
        }
        static void PositiveorNegative()
        {
            Console.Write("Enter a number:");
            int num = int.Parse(Console.ReadLine());
            if (num < 0)
            {
                Console.WriteLine($"{num} is a negative number");
            }
            else if (num > 0)
            {
                Console.WriteLine($"{num} is a positive number");
            }
            else
            {
                Console.WriteLine($"{num} is zero");
            }
        }
        static void MathOperations()
        {
            Console.Write("enter a:");
            int a = int.Parse(Console.ReadLine());
            Console.Write("enter b:");
            int b = int.Parse(Console.ReadLine());
            Console.Write("enter operator(+,-,*,/):");
            char operation = char.Parse(Console.ReadLine());
            int result = 0;
            if (operation == '+')
            {
                result = a + b;
            }
            else if (operation == '-')
            {
                result = a - b;
            }
            else if (operation == '*')
            {
                result = a * b;
            }
            else if (operation == '/')
            {

                result = a / b;
            }
            else
            {
                Console.WriteLine("Invalid operator");
            }
            Console.WriteLine("The result is: " + result);


        }
        static void MultiplicationTable()
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{num}*{i}={num * i}");
            }

        }
        static void SumofIntegers()
        {
            Console.Write("Enter num1: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter num2: ");
            int num2 = int.Parse(Console.ReadLine());
            int sum = num1 + num2;
            if (num1 == num2)
            {
                Console.WriteLine($"{sum * 3}");
            }


        }

        static void Main(string[] args)
        {
            Console.WriteLine("========EqualorNot======");
            CheckEqualNum();
            Console.WriteLine("=======Positive or Negative======");
            PositiveorNegative();
            Console.WriteLine("=======Math operations======");
            MathOperations();
            Console.WriteLine("=======Multiplication table=======");
            MultiplicationTable();
            Console.WriteLine("=======Sum of Integers=====");

            SumofIntegers();
            Console.Read();
        }
    }
}
