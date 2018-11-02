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
        IEnumerable<Book> GetBooks();

        /// <summary>
        /// Getting authors IEnumerable
        /// </summary>
        /// <returns>IEnumerable of authors</returns>
        IEnumerable<Author> GetAuthors();

        /// <summary>
        /// Getting genres IEnumerable
        /// </summary>
        /// <returns>IEnumerable of genres</returns>
        IEnumerable<Genre> GetGenres();

        /// <summary>
        /// Getting books-genres pairs IEnumerable
        /// </summary>
        /// <returns>IEnumerable of books-genres pairs</returns>
        IEnumerable<KeyValuePair<int, int>> GetBooksGenres();

        /// <summary>
        /// Getting books-authors pairs IEnumerable
        /// </summary>
        /// <returns>IEnumerable of books-authors pairs</returns>
        IEnumerable<KeyValuePair<int, int>> GetBooksAuthors();
    }
}
