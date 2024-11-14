using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment5
{
    class WriteFile
    {
        public static void Main()
        {
            // Prompt user for the number of lines to write
            Console.Write("Enter the number of lines you want to write to the file: ");
            int numberOfLines = int.Parse(Console.ReadLine());

            // Initialize the array to store user input strings
            string[] lines = new string[numberOfLines];

            // Collect strings from the user
            for (int i = 0; i < numberOfLines; i++)
            {
                Console.Write($"Enter line {i + 1}: ");
                lines[i] = Console.ReadLine();
            }

            // Specify the file path
            string filePath = "user_output.txt";

            try
            {
                // Write all lines to the specified file
                File.WriteAllLines(filePath, lines);
                Console.WriteLine("Lines written to the file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            Console.Read();
        }
    }
}
