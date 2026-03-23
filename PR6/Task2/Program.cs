using System;

namespace Task2
{

    class Author
    {
        public string Name;

        public Author(string name)
        {
            Name = name;
        }
    }

    class TableOfContents
    {
        public string Title;

        public TableOfContents(string title)
        {
            Title = title;
        }
    }

    class Library
    {
        public string Name;

        public Library(string name)
        {
            Name = name;
        }
    }

    class Book
    {
        public Author[] authors;         
        public TableOfContents contents;  
        public Library library;           

        public Book(Author[] auth, string contentTitle, Library lib)
        {
            authors = auth;
            contents = new TableOfContents(contentTitle);  
            library = lib;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Книга из {library.Name}");
            Console.Write("Авторы: ");
            for (int i = 0; i < authors.Length; i++)
            {
                Console.Write(authors[i].Name + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Содержание: " + contents.Title);
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            Library lib = new Library("Гродненской библиотеки");

            Author[] authors1 = { new Author("Пушкин,"), new Author("Лермонтов") };
            Book book1 = new Book(authors1, "Глава 1. Вступление", lib);

            Author[] authors2 = { new Author("Достоевский") };
            Book book2 = new Book(authors2, "Часть 1. Преступление", lib);

            Book[] books = { book1, book2 };

            Console.WriteLine("ИНФОРМАЦИЯ О КНИГАХ");
            for (int i = 0; i < books.Length; i++)
            {
                books[i].DisplayInfo();
            }
        }
    }
}