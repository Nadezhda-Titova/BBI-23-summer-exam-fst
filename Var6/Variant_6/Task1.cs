using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Variant_6
{
    public class Task1
    {
        public struct Book
        {
            private static int counter = 0;

            private int isbn;
            private string title;
            private string author;
            private int year;

            public int ISBN { get => isbn; }
            public string Title { get => title; }
            public string Author { get => author; }
            public int Year { get => year; }

            public Book(string title, string author, int year)
            {
                this.isbn = counter++;
                this.title = title;
                this.author = author;
                this.year = year;
            }

            public static Book[] Select(Book[] books, string author)
            {
                int count = 0;
                foreach (var book in books)
                {
                    if (book.author == author)
                    {
                        count++;
                    }
                }

                Book[] result = new Book[count];
                int index = 0;
                foreach (var book in books)
                {
                    if (book.author == author)
                    {
                        result[index++] = book;
                    }
                }
                return result;
            }

            public static Book[] Select(Book[] books, int year)
            {
                int count = 0;
                foreach (var book in books)
                {
                    if (book.year == year)
                    {
                        count++;
                    }
                }

                Book[] result = new Book[count];
                int index = 0;
                foreach (var book in books)
                {
                    if (book.year == year)
                    {
                        result[index++] = book;
                    }
                }

                return result;
            }

            public override string ToString()
            {
                return $"Title = {Title}, ISBN = {ISBN}, author = {Author}, year = {Year}";
            }
        }

        public Book[] Books;

        public Task1(Book[] books)
        {
            this.Books = books;
        }

        public void Sorting()
        {
            int pos = 0;
            while (pos < this.Books.Length)
            {
                if (pos == 0 || this.Books[pos].Year >= this.Books[pos - 1].Year)
                {
                    pos++;
                }
                else
                {
                    Book temp = this.Books[pos];
                    this.Books[pos] = this.Books[pos - 1];
                    this.Books[pos - 1] = temp;
                    pos--;
                }
            }
        }
    }
}
