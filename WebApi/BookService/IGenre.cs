// <copyright file="IGenre.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebApi.BookService
{
    using System.Collections.Generic;
    using WebLib.Models;

    /// <summary>
    /// Genre CRUD methods
    /// </summary>
    public interface IGenre
    {
        /// <summary>
        /// Create genre
        /// </summary>
        /// <param name="genre">Genre object</param>
        /// <returns>Created genre id</returns>
        int AddGenre(Genre genre);

        /// <summary>
        /// Getting all genres
        /// </summary>
        /// <returns>List of genres</returns>
        IEnumerable<Genre> GetAllGenres();

        /// <summary>
        /// Getting genre by id
        /// </summary>
        /// <param name="genreId">Genre id to get</param>
        /// <returns>Genre object</returns>
        Genre GetGenreById(int genreId);

        /// <summary>
        /// Deleting genre by id
        /// </summary>
        /// <param name="genreId">Genre id to delete</param>
        /// <returns>Status of deleting</returns>
        bool DelteGenre(int genreId);
    }
}
