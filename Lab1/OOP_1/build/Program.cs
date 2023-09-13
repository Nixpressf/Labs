using System;
using System.Collections.Generic;

namespace sanyaOOP1.build
{
    internal class Program
    {
        public static void Main()
    {
        Library library = new Library();
        library.AddBook(new Book("Book1", "Author1", 2020, "ISBN1"));
        library.AddBook(new Book("Book2", "Author2", 2019, "ISBN2"));
        while (true)
        {
            Console.WriteLine("Бібліотека керування книгами");
            Console.WriteLine("1. Додати книгу");
            Console.WriteLine("2. Видалити книгу");
            Console.WriteLine("3. Пошук за автором");
            Console.WriteLine("4. Пошук за назвою");
            Console.WriteLine("5. Вивести всі книги");
            Console.WriteLine("6. Вийти з програми");

            Console.Write("Виберіть опцію: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введіть назву книги: ");
                    string title = Console.ReadLine();
                    Console.Write("Введіть автора книги: ");
                    string author = Console.ReadLine();
                    Console.Write("Введіть рік видання книги: ");
                    int year;
                    while (!int.TryParse(Console.ReadLine(), out year))
                    {
                        Console.Write("Введіть правильний рік: ");
                    }
                    Console.Write("Введіть ISBN книги: ");
                    string isbn = Console.ReadLine();

                    Book newBook = new Book(title, author, year, isbn);
                    library.AddBook(newBook);
                    Console.WriteLine("Книга додана до бібліотеки.");
                    break;

                case "2":
                    Console.Write("Введіть назву книги, яку ви хочете видалити: ");
                    string bookTitle = Console.ReadLine();
                    List<Book> booksToDelete = library.SearchByTitle(bookTitle);

                    if (booksToDelete.Count == 0)
                    {
                        Console.WriteLine("Книгу не знайдено.");
                    }
                    else if (booksToDelete.Count == 1)
                    {
                        library.RemoveBook(booksToDelete[0]);
                        Console.WriteLine("Книга видалена з бібліотеки.");
                    }
                    else
                    {
                        Console.WriteLine("Знайдено більше однієї книги з такою назвою. Виберіть номер книги для видалення:");

                        for (int i = 0; i < booksToDelete.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {booksToDelete[i].Title} ({booksToDelete[i].Author})");
                        }

                        int bookNumber;
                        while (!int.TryParse(Console.ReadLine(), out bookNumber) || bookNumber < 1 || bookNumber > booksToDelete.Count)
                        {
                            Console.Write("Введіть правильний номер книги для видалення: ");
                        }

                        library.RemoveBook(booksToDelete[bookNumber - 1]);
                        Console.WriteLine("Книга видалена з бібліотеки.");
                    }
                    break;

                case "3":
                    Console.Write("Введіть ім'я автора для пошуку: ");
                    string authorToSearch = Console.ReadLine();
                    List<Book> booksByAuthor = library.SearchByAuthor(authorToSearch);
                    library.DisplayAllBooks(booksByAuthor);
                    break;

                case "4":
                    Console.Write("Введіть назву книги для пошуку: ");
                    string titleToSearch = Console.ReadLine();
                    List<Book> booksByTitle = library.SearchByTitle(titleToSearch);
                    library.DisplayAllBooks(booksByTitle);
                    break;

                case "5":
                    library.DisplayAllBooks(library.books);
                    break;

                case "6":
                    Console.WriteLine("Дякую за використання програми. До побачення!");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                    break;
            }
        }
        // ReSharper disable once FunctionNeverReturns
    }
    }
}