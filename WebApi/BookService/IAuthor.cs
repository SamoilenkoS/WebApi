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
        IEnumerable<Author> GetAuthors();

        /// <summary>
        /// Getting Author by id
        /// </summary>
        /// <param name="id">Author id</param>
        /// <returns>Author instance</returns>
        Author GetAuthor(int id);

        /// <summary>
        /// Getting author by full name
        /// </summary>
        /// <param name="surname">Author surname</param>
        /// <param name="name">Author name</param>
        /// <param name="patronymic">Author patronymic</param>
        /// <returns></returns>
        Author GetAuthor(string surname, string name, string patronymic);

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
