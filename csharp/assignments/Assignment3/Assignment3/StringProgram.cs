using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class StringProgram
    {
        static void StringLength()
        {
            Console.Write("Enter a string: ");
            string str = Console.ReadLine();
            Console.WriteLine($"The length of the given string is: {str.Length}");
        }
        static void StringReverse()
        {
            Console.Write("Enter a string: ");
            string str = Console.ReadLine();
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            string Reversedstr = new string(charArray);
            Console.WriteLine($"The reversed string is: {Reversedstr}");

        }
        static void StringEqual()
        {
            Console.Write("Enter string1: ");
            string string1 = Console.ReadLine();
            Console.Write("Enter string2: ");
            string string2 = Console.ReadLine();
            if (string1.Equals(string2))
            {
                Console.WriteLine($"string1 and string2 are same");
            }
            else
            {
                Console.WriteLine($"string1 and string2 are not same");
            }

        }
        static void Main(String[] args)
        {
            Console.WriteLine("=======String Length=====");
            StringLength();
            Console.WriteLine("=======String reverse======");
            StringReverse();
            Console.WriteLine("=========Strings equals or not====");
            StringEqual();
            Console.Read();
        }
       
    }
}
