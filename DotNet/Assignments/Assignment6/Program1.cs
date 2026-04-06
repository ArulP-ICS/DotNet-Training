using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            BookShelf shelf = new BookShelf();

            for (int i = 0; i < 5; i++)
            {

                Console.Write("Enter Book Name for Book " + (i + 1) + ": ");
                string bookName = Console.ReadLine();

                Console.Write("Enter Author Name for Book " + (i + 1) + ": ");
                string authorName = Console.ReadLine();

                shelf[i] = new Books(bookName, authorName);
                Console.WriteLine();
            }
            Console.WriteLine("Book Shelf Details:\n");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Book " + (i + 1));
                shelf[i].Display();
            }

            Console.ReadKey();


        }

        class Books
        {

            public string BookName { get; set; }
            public string AuthorName { get; set; }
            public Books(string bookName, string authorName)
            {
                BookName = bookName;
                AuthorName = authorName;
            }
            public void Display()
            {
                Console.WriteLine("Book Name   : " + BookName);
                Console.WriteLine("Author Name : " + AuthorName);
                Console.WriteLine();
            }
        }

        class BookShelf
        {
            private Books[] books = new Books[5];
            public Books this[int index]
            {
                get { return books[index]; }
                set { books[index] = value; }
            }

        }
    }
}
