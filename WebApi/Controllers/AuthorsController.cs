// <copyright file="AuthorController.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebApi.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.BookService;
    using WebLib.Models;

    /// <summary>
    /// Author CRUD controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        /// <summary>
        /// ILibrary interface link
        /// </summary>
        private readonly ILibrary library;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorsController"/> class
        /// </summary>
        /// <param name="library">IBook interface link</param>
        public AuthorsController(ILibrary library)
        {
            this.library = library;
        }

        /// <summary>
        /// Adding author
        /// </summary>
        /// <param name="author">Author to add</param>
        /// <returns>Result of adding</returns>
        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                this.library.AddAuthor(author);
                return this.Created("authors", author);
            }

            return this.BadRequest("Invalid author format");
        }

        /// <summary>
        /// Getting all authors
        /// </summary>
        /// <returns>Authors list</returns>
        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            return this.Ok(this.library.GetAllAuthors().ToList());
        }

        /// <summary>
        /// Getting author by id
        /// </summary>
        /// <param name="id">Id of author for get</param>
        /// <returns>Author with such id or null if not exist</returns>
        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            Author authorToGet = this.library.GetAuthorById(id);
            if (authorToGet == null)
            {
                return this.NotFound("No author with this id!");
            }

            return this.Ok(authorToGet);
        }

        /// <summary>
        /// Getting book list of author
        /// </summary>
        /// <param name="id">Id of author</param>
        /// <returns>List of books or NotFound</returns>
        [HttpGet("{id}/books")]
        public IActionResult GetBooksOfAuthor(int id)
        {
            Author authorToGet = this.library.GetAuthorById(id);
            if (authorToGet == null)
            {
                return this.NotFound("No author with this id!");
            }

            return this.Ok(this.library.GetAuthorBooks(id).ToList());
        }

        /// <summary>
        /// Updating of author
        /// </summary>
        /// <param name="id">Id of author for upadte</param>
        /// <param name="author">New info</param>
        /// <returns>Status of update</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody]Author author)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Not a valid model!");
            }

            if (!this.library.UpdateAuthor(id, author))
            {
                return this.NotFound("No author with this id!");
            }

            return this.Ok(this.library.GetAuthorById(id));
        }

        /// <summary>
        /// Deleting of author by id
        /// </summary>
        /// <param name="id">Id of author</param>
        /// <returns>Status of delete query</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            Author authorToDelete = this.library.GetAuthorById(id);
            if (authorToDelete == null)
            {
                return this.NotFound("No author with this id!");
            }

            this.library.RemoveAuthor(id);
            return this.Ok();
        }
    }
}