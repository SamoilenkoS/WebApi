// <copyright file="IDataProvider.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebLib
{
    using System.Collections.Generic;
    using WebLib.Models;

    /// <summary>
    /// Interface with methods wich will allow to get data
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Getting books IEnumerable
        /// </summary>
        /// <returns>IEnumerable of Book</returns>
        List<Book> Books
        {
            get;
        }

        /// <summary>
        /// Getting authors IEnumerable
        /// </summary>
        /// <returns>IEnumerable of authors</returns>
        List<Author> Authors
        {
            get;
        }

        /// <summary>
        /// Getting genres IEnumerable
        /// </summary>
        /// <returns>IEnumerable of genres</returns>
        List<Genre> Genres
        {
            get;
        }

        /// <summary>
        /// Getting books-genres pairs IEnumerable
        /// </summary>
        /// <returns>IEnumerable of books-genres pairs</returns>
        List<KeyValuePair<int, int>> BooksGenres
        {
            get;
        }

        /// <summary>
        /// Getting books-authors pairs IEnumerable
        /// </summary>
        /// <returns>IEnumerable of books-authors pairs</returns>
        List<KeyValuePair<int, int>> BooksAuthors
        {
            get;
        }
    }
}
