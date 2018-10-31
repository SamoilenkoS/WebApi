// <copyright file="ILibrary_TestClass.cs" company="My company">
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
    /// ILibrary test class
    /// </summary>
    [TestClass]
    public class ILibrary_TestClass
    {
        /// <summary>
        /// ILibrary object
        /// </summary>
        private ILibrary libraryObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="ILibrary_TestClass"/> class
        /// </summary>
        public ILibrary_TestClass()
        {
            this.libraryObject = new LibraryList();
        }

        /// <summary>
        /// Update book author Id Correct
        /// </summary>
        [TestMethod]
        public void UpdateBookAuthor_IdsCorrect()
        {
            // Arrange
            int bookId = 0;
            int? newId = 2;

            // Act
            bool updatdeSuccessfully = this.libraryObject.UpdateBooksAuthor(bookId, (int)newId);
            int? actual = this.libraryObject.GetBookById(bookId).AuthorId;

            // Assert
            Assert.IsTrue(updatdeSuccessfully);
            Assert.AreEqual(newId, actual);
        }

        /// <summary>
        /// Update book author Id Incorrect
        /// </summary>
        [TestMethod]
        public void UpdateBookAuthor_IdsIncorrect()
        {
            // Arrange
            int incorrectId = -1;

            // Act
            bool updatdeSuccessfully = this.libraryObject.UpdateBooksAuthor(incorrectId, incorrectId);

            // Assert
            Assert.IsFalse(updatdeSuccessfully);
        }

        /// <summary>
        /// Get authors books list
        /// </summary>
        [TestMethod]
        public void GetAuthorsBook()
        {
            // Arrange
            int authorId = 1;
            List<Book> expected = (from book in this.GetDefaultBooksList().ToList()
                                   where book.AuthorId == authorId
                                   select book).ToList();

            // Act
            List<Book> actual = this.libraryObject.GetAuthorBooks(authorId).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Getting default authors list
        /// </summary>
        /// <returns>List of authors by default</returns>
        private List<Author> GetDefaultAuthorsList()
        {
            return new List<Author>()
            {
                new Author("SurnameA", "NameA", "PatronymicA"),
                new Author("SurnameB", "NameB", "PatronymicB"),
                new Author("SurnameC", "NameC", "PatronymicC")
            };
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
