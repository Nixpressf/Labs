using System;
using System.Collections.Generic;

namespace sanyaOOP1.build
{
    public class Library
    {
       public List<Book> books;
        
        public Library()
        {
            books = new List<Book>();
            
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        public List<Book> SearchByAuthor(string author)
        {
            return books.FindAll(book => book.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
        }

        public List<Book> SearchByTitle(string title)
        {
            return books.FindAll(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public void DisplayAllBooks(List<Book> booksToDisplay)
        {
            foreach (var book in booksToDisplay)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Year: {book.Year}, ISBN: {book.ISBN}");
            }
        }
    }
}