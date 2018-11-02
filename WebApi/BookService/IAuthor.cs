// <copyright file="IAuthor.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebApi.BookService
{
    using System.Collections.Generic;
    using WebLib.Models;

    /// <summary>
    /// CRUD methods for author
    /// </summary>
    public interface IAuthor
    {
        /// <summary>
        /// Getting author bookss
        /// </summary>
        /// <param name="authorId">Author id</param>
        /// <returns>List of books of author</returns>
        IEnumerable<Book> GetAuthorBooks(int authorId);

        /// <summary>
        /// Get all Authors
        /// </summary>
        /// <returns>List of Authors</returns>
        IEnumerable<Author> GetAllAuthors();

        /// <summary>
        /// Getting Author by id
        /// </summary>
        /// <param name="id">Author id</param>
        /// <returns>Author instance</returns>
        Author GetAuthorById(int id);

        /// <summary>
        /// Update Author
        /// </summary>
        /// <param name="id">Author id</param>
        /// <param name="author">Author data for update</param>
        /// <returns>True if successfully update</returns>
        bool UpdateAuthor(int id, Author author);

        /// <summary>
        /// Remove Author with id from collection\db
        /// </summary>
        /// <param name="id">Author id</param>
        /// <returns>True if successfully remove</returns>
        bool RemoveAuthor(int id);

        /// <summary>
        /// Adding a Author to collection\db
        /// </summary>
        /// <param name="author">Author to add</param>
        /// <returns>Author id</returns>
        int AddAuthor(Author author);
    }
}
