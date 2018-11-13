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
        private readonly List<Author> authors;
        private readonly List<Book> books;
        private readonly List<Genre> genres;
        private readonly List<KeyValuePair<int, int>> booksGenre;
        private readonly List<KeyValuePair<int, int>> booksAuthor;
        public List<Author> Authors
        {
            get
            {
                return authors;
            }
        }
        public List<Book> Books
        {
            get
            {
                return books;
            }
        }
        public List<Genre> Genres
        {
            get
            {
                return genres;
            }
        }
        public List<KeyValuePair<int, int>> BooksGenres
        {
            get
            {
                return booksGenre;
            }
        }
        public List<KeyValuePair<int, int>> BooksAuthors
        {
            get
            {
                return booksAuthor;
            }
        }

        public DataProviderList()
        {
            authors = new List<Author>()
            {
                new Author("SurnameA", "NameA", "PatronymicA"),
                new Author("SurnameB", "NameB", "PatronymicB"),
                new Author("SurnameC", "NameC", "PatronymicC")
            };
            books = new List<Book>()
            {
                new Book("First book"),
                new Book("Second book"),
                new Book("Third book"),
                new Book("Fourth book"),
                new Book("Fifth book"),
                new Book("Sixth book")
             };
            genres = new List<Genre>()
            {
                new Genre("Novel"),
                new Genre("Adventure"),
                new Genre("Biography")
            };
            booksGenre = new List<KeyValuePair<int, int>>()
            {
            };
            booksAuthor = new List<KeyValuePair<int, int>>()
            {
            };
        }

        /// <summary>
        /// Getting list of default authors
        /// </summary>
        /// <returns>IEnumerable authors list</returns>

        /// <summary>
        /// Getting list of default books
        /// </summary>
        /// <returns>IEnumerable books list</returns>

        /// <summary>
        /// Getting list of default genres
        /// </summary>
        /// <returns>IEnumerable genres list</returns>

        /// <summary>
        /// Getting list of default book-genre pairs
        /// </summary>
        /// <returns>IEnumerable book-genre pairs list</returns>

        /// <summary>
        /// Getting list of default book-author pairs
        /// </summary>
        /// <returns>IEnumerable book-author pairs list</returns>
    }
}
