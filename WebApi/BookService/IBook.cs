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
        /// Adding a book to collection\db
        /// </summary>
        /// <param name="book">Book to add</param>
        /// <returns>Book id</returns>
        int AddBook(Book book);

        /// <summary>
        /// Adding author to the book
        /// </summary>
        /// <param name="bookId">Book id for author add</param>
        /// <param name="authorId">Author id for add</param>
        /// <returns>Status of adding author</returns>
        bool AddBookAuthor(int bookId, int authorId);

        /// <summary>
        /// Adding genre to the book
        /// </summary>
        /// <param name="bookId">Book id for genre add</param>
        /// <param name="genreId">Genre id for add</param>
        /// <returns>Status of adding genre</returns>
        bool AddBookGenre(int bookId, int genreId);

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
        /// Getting books in genre
        /// </summary>
        /// <param name="genreId">Genre id to get its books</param>
        /// <returns>List of books</returns>
        IEnumerable<Book> GetBooksInGenre(int genreId);

        /// <summary>
        /// Getting book authors
        /// </summary>
        /// <param name="bookId">Book id to get authors</param>
        /// <returns>List of authors</returns>
        List<Author> GetBookAuthors(int bookId);

        /// <summary>
        /// Getting book genres
        /// </summary>
        /// <param name="bookId">Book id to get genres</param>
        /// <returns>List of genres</returns>
        List<Genre> GetBookGenres(int bookId);

        /// <summary>
        /// Update book
        /// </summary>
        /// <param name="id">Book id</param>
        /// <param name="book">Book data for update</param>
        /// <returns>True if successfully update</returns>
        bool UpdateBook(int id, Book book);

        /// <summary>
        /// Updating book genre (replacing one to other)
        /// </summary>
        /// <param name="bookId">Book id to update it`s genre</param>
        /// <param name="oldGenreId">Old genre id</param>
        /// <param name="newGenreId">New genre id</param>
        /// <returns>Status of update</returns>
        bool UpdateBookGenre(int bookId, int oldGenreId, int newGenreId);

        /// <summary>
        /// Updating book author (replacing one to other)
        /// </summary>
        /// <param name="bookId">Book id to update it`s author</param>
        /// <param name="oldAuthorId">Old author id</param>
        /// <param name="newAuthorId">New author id</param>
        /// <returns>Status of update</returns>
        bool UpdateBookAuthor(int bookId, int oldAuthorId, int newAuthorId);

        /// <summary>
        /// Remove book with id from collection\db
        /// </summary>
        /// <param name="id">Book id</param>
        /// <returns>True if successfully remove</returns>
        bool DeleteBook(int id);

        /// <summary>
        /// Deleting book author
        /// </summary>
        /// <param name="bookId">Book id to remove author</param>
        /// <param name="authorIdForRemove">Author id to remove</param>
        /// <returns>Status of author removing</returns>
        bool DeleteBookAuthor(int bookId, int authorIdForRemove);

        /// <summary>
        /// Delete book genre
        /// </summary>
        /// <param name="bookId">Book id to remove genre</param>
        /// <param name="bookGenreForRemove">Genre id to remove</param>
        /// <returns>Status of genre removing</returns>
        bool DeleteBookGenre(int bookId, int bookGenreForRemove);
    }
}
