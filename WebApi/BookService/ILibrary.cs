// <copyright file="ILibrary.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebApi.BookService
{
    using System.Collections.Generic;
    using WebApi.Models;

    /// <summary>
    /// ILibrary interface
    /// </summary>
    public interface ILibrary : IBook, IAuthor
    {
        /// <summary>
        /// Updated book author
        /// </summary>
        /// <param name="bookId">Id of book</param>
        /// <param name="authorId">New author id</param>
        /// <returns>True if successfully updated (false if author doesn`t exist)</returns>
        bool UpdateBooksAuthor(int bookId, int authorId);

        /// <summary>
        /// Getting author bookss
        /// </summary>
        /// <param name="authorId">Author id</param>
        /// <returns>List of books of author</returns>
        IEnumerable<Book> GetAuthorBooks(int authorId);
    }
}
