using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    class Program1
    {
        public static string RemoveCharAt(string str, int index)
        {
            if(index<0 || index>=str.Length)
            {
                Console.WriteLine("Index out of range");
                return str;
            }
            return str.Remove(index, 1);
        }
        static string ExchangeFirstAndLast(string str)
        {
           
            if (string.IsNullOrEmpty(str)||str.Length==1)
            {
                return str;
            }
            char firstChar = str[0];
            char lastChar = str[str.Length - 1];
            string newStr = lastChar + str.Substring(1, str.Length - 2) + firstChar;
            return newStr;
        }
        public static int FindLargest(int num1, int num2, int num3)
        {
           
            int max = num1;
            if(num2>max)
            {
                max = num2;
            }
            if (num3 > max)
            {
                max = num3;
            }
            return max;
        }
        public static int occurrencesCount(string str, char letter)
        {
            int count = 0;
            foreach(char c in str)
            {
                if(char.ToLower(c)==char.ToLower(letter))
                {
                    count++;
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine(RemoveCharAt("python", 1));
            Console.WriteLine(RemoveCharAt("python", 0));
            Console.WriteLine(RemoveCharAt("python", 3));
            Console.WriteLine(RemoveCharAt("python", 4));
            Console.WriteLine("========Exchange First and last character=======");
            string input1 = "abcd";
            string input2 = "xy";
            Console.WriteLine(ExchangeFirstAndLast(input1));
            Console.WriteLine(ExchangeFirstAndLast(input2));
            Console.WriteLine("==========Find largest number=======");
            Console.WriteLine(FindLargest(1, 2, 3));
            Console.WriteLine(FindLargest(2,4,5));

            Console.WriteLine(FindLargest(6,7,8));
            Console.WriteLine("==========Count of Occurrences=======");
            Console.Write("Enter a string: ");
            string inputStr = Console.ReadLine();
            Console.Write("Enter a letter to count: ");
            char letter = Console.ReadKey().KeyChar;
            Console.WriteLine();
            int occurrences = occurrencesCount(inputStr, letter);
            Console.WriteLine($"\nThe letter '{letter}' occurs {occurrences} time(s) in the given string");
            Console.ReadLine();
        }
    }
}
