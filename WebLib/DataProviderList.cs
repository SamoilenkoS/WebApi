using System;
using System.Collections.Generic;
using System.Text;
using WebLib.Models;

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

        public IEnumerable<KeyValuePair<Book, Genre>> GetBooksGenres()
        {
            Dictionary<Book, Genre> booksGenre = new Dictionary<Book, Genre>()
            {

            };
            foreach (var bookGenre in booksGenre)
            {
                yield return bookGenre;
            }
        }

        public IEnumerable<KeyValuePair<Book, Author>> GetBooksAuthors()
        {
            Dictionary<Book, Author> booksAuthor = new Dictionary<Book, Author>()
            {

            };
            foreach (var bookGenre in booksAuthor)
            {
                yield return bookGenre;
            }
        }

        public IEnumerable<Genre> GetGenres()
        {
            List<Genre> genres = new List<Genre>()
            {

            };
            foreach (Genre genre in genres)
            {
                yield return genre;
            }
        }
    }
}
