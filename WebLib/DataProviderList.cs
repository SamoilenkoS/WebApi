// <copyright file="DataProviderList.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebLib
{
    using System.Collections.Generic;
    using WebLib.Models;

    /// <summary>
    /// IDataProvider interface implementation
    /// </summary>
    public class DataProviderList : IDataProvider
    {
        /// <summary>
        /// Getting list of default authors
        /// </summary>
        /// <returns>IEnumerable authors list</returns>
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

        /// <summary>
        /// Getting list of default books
        /// </summary>
        /// <returns>IEnumerable books list</returns>
        public IEnumerable<Book> GetBooks()
        {
            List<Book> books = new List<Book>()
            {
                new Book("First book"),
                new Book("Second book"),
                new Book("Third book"),
                new Book("Fourth book"),
                new Book("Fifth book"),
                new Book("Sixth book")
             };
            foreach (Book book in books)
            {
                yield return book;
            }
        }

        /// <summary>
        /// Getting list of default genres
        /// </summary>
        /// <returns>IEnumerable genres list</returns>
        public IEnumerable<Genre> GetGenres()
        {
            List<Genre> genres = new List<Genre>()
            {
                new Genre("Novel"),
                new Genre("Adventure"),
                new Genre("Biography")
            };
            foreach (Genre genre in genres)
            {
                yield return genre;
            }
        }

        /// <summary>
        /// Getting list of default book-genre pairs
        /// </summary>
        /// <returns>IEnumerable book-genre pairs list</returns>
        public IEnumerable<KeyValuePair<int, int>> GetBooksGenres()
        {
            List<KeyValuePair<int, int>> booksGenre = new List<KeyValuePair<int, int>>()
            {
            };
            foreach (var bookGenre in booksGenre)
            {
                yield return bookGenre;
            }
        }

        /// <summary>
        /// Getting list of default book-author pairs
        /// </summary>
        /// <returns>IEnumerable book-author pairs list</returns>
        public IEnumerable<KeyValuePair<int, int>> GetBooksAuthors()
        {
            List<KeyValuePair<int, int>> booksAuthor = new List<KeyValuePair<int, int>>()
            {
            };
            foreach (var bookGenre in booksAuthor)
            {
                yield return bookGenre;
            }
        }
    }
}
