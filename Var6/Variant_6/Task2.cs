using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Variant_6
{
    public class Task2
    {
        public abstract class Book
        {
            private static int counter = 0;
            protected int isbn;
            protected string title;
            protected string author;
            protected int year;

            public int ISBN => isbn;
            public string Title => title;
            public string Author => author;
            public int Year => year;

            public Book(string title, string author, int year)
            {
                this.isbn = counter++;
                this.title = title;
                this.author = author;
                this.year = year;
            }

            public abstract double Cost();

            public override string ToString()
            {
                return $"Type = {this.GetType().Name}, isbn = {ISBN}, spec = {GetSpec()}";
            }

            protected abstract string GetSpec();
        }

        public class PaperBook : Book
        {
            private bool isHardCover;

            public bool IsHardCover => isHardCover;

            public PaperBook(string title, string author, int year, bool isHardCover)
                : base(title, author, year)
            {
                this.isHardCover = isHardCover;
            }

            public override double Cost()
            {
                double cost = 500 + (DateTime.Now.Year - year);
                cost += isHardCover ? 150 : 0;
                return cost;
            }

            protected override string GetSpec()
            {
                return $"HardCover = {IsHardCover}";
            }
        }

        public class ElectronicBook : Book
        {
            private string format;

            public string Format => format;

            public ElectronicBook(string title, string author, int year, string format)
                : base(title, author, year)
            {
                this.format = format;
            }

            public override double Cost()
            {
                double cost = 500 + (DateTime.Now.Year - year);
                double multiplier = format switch
                {
                    "pdf" => 0.6,
                    "fb2" => 0.8,
                    "epub" => 0.95,
                    _ => 1,
                };
                return cost * multiplier;
            }

            protected override string GetSpec()
            {
                return $"Format = {Format}";
            }
        }

        public class AudioBook : Book
        {
            private bool isStudioRecord;

            public bool IsStudioRecord => isStudioRecord;

            public AudioBook(string title, string author, int year, bool isStudioRecord)
                : base(title, author, year)
            {
                this.isStudioRecord = isStudioRecord;
            }

            public override double Cost()
            {
                double cost = 500 + (DateTime.Now.Year - year);
                double multiplier = isStudioRecord ? 0.8 : 0.6;
                return cost * multiplier;
            }

            protected override string GetSpec()
            {
                return $"StudioRecord = {IsStudioRecord}";
            }
        }

        
            public Book[] Books;

            public Task2(Book[] books)
            {
                this.Books = books;
            }

            public void Sorting()
            {
                int pos = 0;
                while (pos < Books.Length)
                {
                    if (pos == 0 || Books[pos].Cost() >= Books[pos - 1].Cost())
                    {
                        pos++;
                    }
                    else
                    {
                        Book temp = Books[pos];
                        Books[pos] = Books[pos - 1];
                        Books[pos - 1] = temp;
                        pos--;
                    }
                }
            }
        }
}
