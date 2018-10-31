// <copyright file="BookController.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.BookService;
    using WebApi.Models;

    /// <summary>
    /// Book controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// IBook interface link
        /// </summary>
        private readonly ILibrary library;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookController"/> class
        /// </summary>
        /// <param name="library">IBook interface link</param>
        public BookController(ILibrary library)
        {
            this.library = library;
        }

        /// <summary>
        /// Adding book
        /// </summary>
        /// <param name="book">Book to add</param>
        /// <returns>Added book</returns>
        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            this.library.AddBook(book);
            return this.Created("books", book);
        }

        /// <summary>
        /// Getting all books method
        /// </summary>
        /// <returns>List of books</returns>
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            List<Book> booksList = this.library.GetAllBooks().ToList();
            if (booksList.Count != 0)
            {
                return this.Ok(booksList);
            }
            else
            {
                return this.NotFound();
            }
        }

        /// <summary>
        /// Getting single book by id
        /// </summary>
        /// <param name="id">Book id to get</param>
        /// <returns>Book or NotFound</returns>
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            Book resultBook = this.library.GetBookById(id);
            if (resultBook == null)
            {
                return this.NotFound();
            }

            return this.Ok(resultBook);
        }

        /// <summary>
        /// Updating book by id
        /// </summary>
        /// <param name="id">Id of book to update</param>
        /// <param name="book">Data for update</param>
        /// <returns>Book or NotFound</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (this.library.UpdateBook(id, book))
            {
                return this.Ok(book);
            }
            else
            {
                return this.NotFound();
            }
        }

        /// <summary>
        /// Upating book author
        /// </summary>
        /// <param name="book_id">Book id</param>
        /// <param name="author_id">Author id</param>
        /// <returns>Status of update</returns>
        [HttpPut("{book_id}/{author_id}")]
        public IActionResult UpdateBookAuthor(int book_id, int author_id)
        {
            if (this.library.UpdateBooksAuthor(book_id, author_id))
            {
                return this.Ok(this.library.GetBookById(book_id));
            }

            return this.NotFound("Book or author wasn`t found!");
        }

        /// <summary>
        /// Deleting book by id
        /// </summary>
        /// <param name="id">Id of book</param>
        /// <returns>Ok or BadRequest</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (this.library.RemoveBook(id))
            {
                return this.Ok();
            }
            else
            {
                return this.BadRequest("There is no book with such id!");
            }
        }
    }
}
