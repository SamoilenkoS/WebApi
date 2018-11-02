// <copyright file="IGenre_TestClass.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebTests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WebApi.BookService;
    using WebLib;
    using WebLib.Models;

    /// <summary>
    /// ILibrary test class
    /// </summary>
    [TestClass]
    public class IGenre_TestClass
    {
        /// <summary>
        /// Instance of IDataProvider
        /// </summary>
        private static IDataProvider dataProvider;

        /// <summary>
        /// ILibrary object
        /// </summary>
        private readonly IGenre genresObject;

        /// <summary>
        /// Initializes static members of the <see cref="IGenre_TestClass"/> class
        /// </summary>
        static IGenre_TestClass()
        {
            dataProvider = new DataProviderList();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IGenre_TestClass"/> class
        /// </summary>
        public IGenre_TestClass()
        {
            this.genresObject = new LibraryList(dataProvider);
        }

        /// <summary>
        /// Adding genre and getting all genres test
        /// </summary>
        [TestMethod]
        public void AddGenre_GetAllGenres()
        {
            // Arrange
            int oldGenreCount = this.genresObject.GetAllGenres().ToList().Count;

            // Act
            this.genresObject.AddGenre(new Genre("Test"));
            int newGenreCount = this.genresObject.GetAllGenres().ToList().Count;

            // Assert
            Assert.AreEqual(oldGenreCount + 1, newGenreCount);
        }

        /// <summary>
        /// Get genre by id test
        /// </summary>
        [TestMethod]
        public void GetGenreById()
        {
            // Arrange
            Genre genre = new Genre("Test");

            // Act
            int genreId = this.genresObject.AddGenre(genre);

            // Assert
            Assert.AreEqual(genre, this.genresObject.GetGenreById(genreId));
        }

        /// <summary>
        /// Delete genre test
        /// </summary>
        [TestMethod]
        public void DelteGenre()
        {
            // Arrange
            Genre genre = new Genre("Test");
            int genresCountBeforeAddDeleteCall = this.genresObject.GetAllGenres().ToList().Count;
            int genresCountAftrerAddDeleteCall;
            int genreId = this.genresObject.AddGenre(genre);

            // Act
            Assert.IsTrue(this.genresObject.DelteGenre(genreId));
            genresCountAftrerAddDeleteCall = this.genresObject.GetAllGenres().ToList().Count;

            // Assert
            Assert.AreEqual(genresCountBeforeAddDeleteCall, genresCountAftrerAddDeleteCall);
        }
    }
}
