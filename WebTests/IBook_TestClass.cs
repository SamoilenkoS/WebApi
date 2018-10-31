// <copyright file="IBook_TestClass.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WebApi.BookService;
    using WebApi.Models;

    /// <summary>
    /// IBook test class
    /// </summary>
    [TestClass]
    public class IBook_TestClass
    {
        /// <summary>
        /// IBook object
        /// </summary>
        private IBook booksObject;

        /// <summary>
        /// Test initialize method
        /// </summary>
        [TestInitialize]
        public void TestClassInitialize()
        {
            this.booksObject = new LibraryList();
        }

        /// <summary>
        /// Add book without author method
        /// </summary>
        [TestMethod]
        public void AddBook_WithoutAuthor()
        {
            // Arrange
            Book expected = new Book("Test book title");

            // Act
            int bookId = this.booksObject.AddBook(expected);
            Book actual = this.booksObject.GetBookById(bookId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Add book with author method
        /// </summary>
        [TestMethod]
        public void AddBook_WithAuthor()
        {
            // Arrange
            Book expected = new Book("Test book title", 0);

            // Act
            int bookId = this.booksObject.AddBook(expected);
            Book actual = this.booksObject.GetBookById(bookId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Getting all books method
        /// </summary>
        [TestMethod]
        public void GetAll()
        {
            // Arrange
            List<Book> expected = this.GetDefaultBooksList();

            // Act
            List<Book> actual = this.booksObject.GetAllBooks().ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Getting book by correct id method
        /// </summary>
        [TestMethod]
        public void GetById_Correct()
        {
            // Arrange
            int bookId = 1;
            int authorId = 1;
            Book expected = new Book("Second book", authorId);

            // Act
            Book actual = this.booksObject.GetBookById(bookId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Getting book by incorrect id method
        /// </summary>
        /// <param name="bookId">Book id</param>
        [DataTestMethod]
        [DataRow(-1)]
        public void GetById_Incorrect(int bookId)
        {
            // Act
            Book actual = this.booksObject.GetBookById(bookId);

            // Assert
            Assert.AreEqual(null, actual);
        }

        /// <summary>
        /// Updating book by correct id method
        /// </summary>
        [TestMethod]
        public void UpdateBook_IdCorrect()
        {
            // Arrange
            Book bookForUpdate = new Book("New title", 1);
            int idForUpdate = 0;

            // Act
            this.booksObject.UpdateBook(idForUpdate, bookForUpdate);

            // Assert
            Assert.AreEqual(bookForUpdate, this.booksObject.GetBookById(idForUpdate));
        }

        /// <summary>
        /// Updating book by incorrect id method
        /// </summary>
        /// <param name="bookId">Book id</param>
        [DataTestMethod]
        [DataRow(-1)]
        public void UpdateBook_IdIncorrect(int bookId)
        {
            // Arrange
            Book bookForUpdate = new Book("New title", 1);

            // Act
            bool actual = this.booksObject.UpdateBook(bookId, bookForUpdate);

            // Assert
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// Deleting book by correct id method
        /// </summary>
        [TestMethod]
        public void Delete_IdCorrect()
        {
            // Arrange
            int idForDelete = 0;

            // Act
            this.booksObject.RemoveBook(idForDelete);

            // Assert
            Assert.AreEqual(null, this.booksObject.GetBookById(idForDelete));
        }

        /// <summary>
        /// Deleting book by incorrect id method
        /// </summary>
        /// <param name="bookId">Book id</param>
        [DataTestMethod]
        [DataRow(-1)]
        public void Delete_IdIncorrect(int bookId)
        {
            // Act
            bool actual = this.booksObject.RemoveBook(bookId);

            // Assert
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// Getting list of default books
        /// </summary>
        /// <returns>List of books</returns>
        private List<Book> GetDefaultBooksList()
        {
            return new List<Book>()
            {
                new Book("First book", 0),
                new Book("Second book", 1),
                new Book("Third book", 2),
                new Book("Fourth book", 0),
                new Book("Fifth book", 1),
                new Book("Sixth book", 2)
            };
        }
    }
}
