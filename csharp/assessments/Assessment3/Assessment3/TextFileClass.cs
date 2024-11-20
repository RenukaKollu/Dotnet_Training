using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assessment3
{
    class TextFileClass
    {
        static void Main(string[] args)
        {
            string filePath = "Sample_textfile.txt"; 
            Console.WriteLine("Enter the text you want to append to the file:");
            string userInput = Console.ReadLine();

            try
            {
                
                using (StreamWriter writer = new StreamWriter(filePath, true)) 
                {
                    writer.WriteLine(userInput);
                }

                Console.WriteLine($"\nText has been successfully appended to the file '{filePath}'.");
                Console.WriteLine("Contents of the file:");

               
                string fileContents = File.ReadAllText(filePath);
                Console.WriteLine(fileContents);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
