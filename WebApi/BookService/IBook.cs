// <copyright file="IBook.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebApi.BookService
{
    using System.Collections.Generic;
    using WebLib.Models;

    /// <summary>
    /// CRUD methods for book
    /// </summary>
    public interface IBook
    {
        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>List of books</returns>
        IEnumerable<Book> GetAllBooks();

        /// <summary>
        /// Getting book by id
        /// </summary>
        /// <param name="id">Book id</param>
        /// <returns>Book instance</returns>
        Book GetBookById(int id);

        /// <summary>
        /// Update book
        /// </summary>
        /// <param name="id">Book id</param>
        /// <param name="book">Book data for update</param>
        /// <returns>True if successfully update</returns>
        bool UpdateBook(int id, Book book);

        /// <summary>
        /// Remove book with id from collection\db
        /// </summary>
        /// <param name="id">Book id</param>
        /// <returns>True if successfully remove</returns>
        bool RemoveBook(int id);

        /// <summary>
        /// Adding a book to collection\db
        /// </summary>
        /// <param name="book">Book to add</param>
        /// <returns>Book id</returns>
        int AddBook(Book book);

        bool AddBookAuthor(int bookId, int authorId);

        bool AddBookGenre(int bookId, int genreId);

        List<Author> GetBookAuthors(int bookId);
        List<Genre> GetBookGenres(int bookId);
    }
}
