// <copyright file="GenresController.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebApi.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.BookService;
    using WebLib.Models;

    /// <summary>
    /// Genres controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        /// <summary>
        /// IBook interface link
        /// </summary>
        private readonly IGenre library;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenresController"/> class
        /// </summary>
        /// <param name="library">IBook interface link</param>
        public GenresController(ILibrary library)
        {
            this.library = library;
        }

        /// <summary>
        /// Adding new genre
        /// </summary>
        /// <param name="genre">Genre object</param>
        /// <returns>Created object</returns>
        [HttpPost]
        public IActionResult AddGenre(Genre genre)
        {
            this.library.AddGenre(genre);
            return this.Created("genres", genre);
        }

        /// <summary>
        /// Getting all genres
        /// </summary>
        /// <returns>List of genres</returns>
        [HttpGet]
        public IActionResult GetAllGenres()
        {
            return this.Ok(this.library.GetAllGenres().ToList());
        }

        /// <summary>
        /// Getting genre by id
        /// </summary>
        /// <param name="genreId">Genre id to get</param>
        /// <returns>Genre object</returns>
        [HttpGet("{genreId}")]
        public IActionResult GetGenreById(int genreId)
        {
            Genre genreWithId = this.library.GetGenreById(genreId);
            if (genreWithId != null)
            {
                return this.Ok(genreWithId);
            }

            return this.NotFound("Genre with this id wasn`t found!");
        }

        /// <summary>
        /// Deleting genre
        /// </summary>
        /// <param name="genreId">Genre id for delete</param>
        /// <returns>Status of deleting</returns>
        [HttpDelete("{genreId}")]
        public IActionResult RemoveGenre(int genreId)
        {
            if (this.library.DelteGenre(genreId))
            {
                return this.Ok("Genre removed");
            }

            return this.BadRequest("Genre wasn`t found or there are some books with this genre!");
        }
    }
}