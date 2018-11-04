using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Models;

namespace WebLib
{
    public class DataProviderList : IDataProvider
    {
        public IEnumerable<Author> GetAuthors()
        {
            List<Author> authors = new List<Author>()
            {
                new Author("SurnameA", "NameA", "PatronymicA"),
                new Author("SurnameB", "NameB", "PatronymicB"),
                new Author("SurnameC", "NameC", "PatronymicC")
            };

            foreach (Author author in authors)
            {
                yield return author;
            }
        }

        public IEnumerable<Book> GetBooks()
        {
            List<Book> books = new List<Book>()
            {
                new Book("First book", 1),
                new Book("Second book", 2),
                new Book("Third book", 3),
                new Book("Fourth book", 1),
                new Book("Fifth book", 2),
                new Book("Sixth book", 3)
             };
            foreach (Book book in books)
            {
                yield return book;
            }
        }
    }
}
