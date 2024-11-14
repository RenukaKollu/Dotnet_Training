using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Book
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Book(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine($"Book: {BookName}, Author: {AuthorName}");
            
        }
    }

    public class BookShelf
    {
        private Book[] books = new Book[5];

        public Book this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }
        public void DisplayBooks()
        {
            foreach (var book in books)
            {
                book?.Display();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BookShelf shelf = new BookShelf();

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter the name of Book {i + 1}: ");
                string bookName = Console.ReadLine();

                Console.Write($"Enter the author of Book {i + 1}: ");
                string authorName = Console.ReadLine();

                shelf[i] = new Book(bookName, authorName);
            }

            Console.WriteLine("\nDisplaying all books:");
            shelf.DisplayBooks();
            Console.Read();
        }
    }
}
