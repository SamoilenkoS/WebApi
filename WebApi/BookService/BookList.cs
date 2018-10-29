// <copyright file="BookList.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebApi.BookService
{
    using System.Collections.Generic;
    using System.Linq;
    using WebApi.Models;

    /// <summary>
    /// Implementation of IBook
    /// </summary>
    public class BookList : IBook
    {
        /// <summary>
        /// List of books
        /// </summary>
        private List<Book> books;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookList"/> class
        /// </summary>
        public BookList()
        {
            this.books = new List<Book>()
            {
                new Book("First book"),
                new Book("Second book"),
                new Book("Third book")
            };
        }

        /// <summary>
        /// Adding the book to collection
        /// </summary>
        /// <param name="book">Book to add</param>
        /// <returns>Book id</returns>
        public int AddBook(Book book)
        {
            this.books.Add(book);
            return book.Id;
        }

        /// <summary>
        /// Getting list of books
        /// </summary>
        /// <returns>List of books</returns>
        public List<Book> GetAllBooks()
        {
            return this.books;
        }

        /// <summary>
        /// Getting book by id
        /// </summary>
        /// <param name="id">Id of book to get</param>
        /// <returns>Book with selected id or null if not found</returns>
        public Book GetBookById(int id)
        {
            Book resultBook = this.books.FirstOrDefault(book => book.Id == id);
            return resultBook;
        }

        /// <summary>
        /// Removing book by id
        /// </summary>
        /// <param name="id">Id of book to remove</param>
        /// <returns>True if book was successfully removed</returns>
        public bool RemoveBook(int id)
        {
            Book bookToDelete = this.books.FirstOrDefault(book => book.Id == id);
            bool result = false;
            if (bookToDelete != null)
            {
                this.books.Remove(bookToDelete);
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Updating of book with selected id
        /// </summary>
        /// <param name="id">Id of book to remove</param>
        /// <param name="book">Book with data for update</param>
        /// <returns>True if book was successfully updated</returns>
        public bool UpdateBook(int id, Book book)
        {
            Book bookToUpdate = this.books.FirstOrDefault(currentBook => currentBook.Id == id);
            bool result = false;
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                result = true;
            }

            return result;
        }
    }
}