// <copyright file="IAuthor_TestClass.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WebApi.BookService;
    using WebLib;
    using WebLib.Models;

    /// <summary>
    /// IAuthor test class
    /// </summary>
    [TestClass]
    public class IAuthor_TestClass
    {
        /// <summary>
        /// Data provider object
        /// </summary>
        private static readonly IDataProvider DataProvider; // stylecop thinks, that it must be with upper case

        /// <summary>
        /// IAuthor object
        /// </summary>
        private IAuthor authorsObject;

        /// <summary>
        /// Initializes static members of the <see cref="IAuthor_TestClass"/> class
        /// </summary>
        static IAuthor_TestClass()
        {
            DataProvider = new DataProviderList();
        }

        /// <summary>
        /// Test initialize method
        /// </summary>
        [TestInitialize]
        public void TestClassInitialize()
        {
            this.authorsObject = new LibraryList(DataProvider);
        }

        /// <summary>
        /// Add author test
        /// </summary>
        [TestMethod]
        public void AddAuthor()
        {
            // Arrange
            Author expected = new Author("Hello", "Hello", "Hello");

            // Act
            int authorId = this.authorsObject.AddAuthor(expected);
            Author actual = this.authorsObject.GetAuthor(authorId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Get all authors test
        /// </summary>
        [TestMethod]
        public void GetAll()
        {
            // Arrange
            List<Author> expected = this.GetDefaultAuthorsList();

            // Act
            List<Author> actual = this.authorsObject.GetAuthors().ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Get author by correct id test
        /// </summary>
        [TestMethod]
        public void GetById_Correct()
        {
            // Arrange
            Author expected = new Author("Test", "Test", "Test");
            int authorId = this.authorsObject.AddAuthor(expected);

            // Act
            Author actual = this.authorsObject.GetAuthor(authorId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Get author by incorrect id test
        /// </summary>
        /// <param name="authorId">Author id</param>
        [DataTestMethod]
        [DataRow(-1)]
        public void GetById_Incorrect(int authorId)
        {
            // Act
            Author actual = this.authorsObject.GetAuthor(authorId);

            // Assert
            Assert.AreEqual(null, actual);
        }

        /// <summary>
        /// Update author by correct id test
        /// </summary>
        [TestMethod]
        public void UpdateAuthor_IdCorrect()
        {
            // Arrange
            Author authorForAdd = new Author("Test", "Test", "Test");
            Author authorForUpdate = new Author("Hello", "Hello", "Hello");
            int idForUpdate = this.authorsObject.AddAuthor(authorForAdd);

            // Act
            this.authorsObject.UpdateAuthor(idForUpdate, authorForUpdate);

            // Assert
            Assert.AreEqual(authorForUpdate, this.authorsObject.GetAuthor(idForUpdate));
        }

        /// <summary>
        /// Update author by incorrect id test
        /// </summary>
        /// <param name="authorId">Author id</param>
        [DataTestMethod]
        [DataRow(-1)]
        public void UpdateAuthor_IdIncorrect(int authorId)
        {
            // Act
            bool actual = this.authorsObject.UpdateAuthor(authorId, null);

            // Assert
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// Delete author by correct id test
        /// </summary>
        [TestMethod]
        public void Delete_IdCorrect()
        {
            // Arrange
            Author authorForAdd = new Author("Test", "Test", "Test");
            int idForDelete = this.authorsObject.AddAuthor(authorForAdd);

            // Act
            this.authorsObject.RemoveAuthor(idForDelete);

            // Assert
            Assert.AreEqual(null, this.authorsObject.GetAuthor(idForDelete));
        }

        /// <summary>
        /// Delete author by incorrect id test
        /// </summary>
        /// <param name="authorId">Author id</param>
        [DataTestMethod]
        [DataRow(-1)]
        public void Delete_IdIncorrect(int authorId)
        {
            // Act
            bool actual = this.authorsObject.RemoveAuthor(authorId);

            // Assert
            Assert.IsFalse(actual);
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
    }
}
