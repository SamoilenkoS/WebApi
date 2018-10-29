// <copyright file="BookController.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebApi.Controllers
{
    using System.Collections.Generic;
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
        private IBook books;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookController"/> class
        /// </summary>
        /// <param name="books">IBook interface link</param>
        public BookController(IBook books)
        {
            this.books = books;
        }

        /// <summary>
        /// Getting all books method
        /// </summary>
        /// <returns>List of books</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            List<Book> booksList = this.books.GetAllBooks();
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
            Book resultBook = this.books.GetBookById(id);
            if (resultBook == null)
            {
                return this.NotFound();
            }

            return this.Ok(resultBook);
        }
        
        /// <summary>
        /// Adding book
        /// </summary>
        /// <param name="book">Book to add</param>
        /// <returns>Added book</returns>
        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            this.books.AddBook(book);
            return this.Created("books", book);
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
            if (this.books.UpdateBook(id, book))
            {
                return this.Ok(book);
            }
            else
            {
                return this.NotFound();
            }
        }

        /// <summary>
        /// Deleting book by id
        /// </summary>
        /// <param name="id">Id of book</param>
        /// <returns>Ok or BadRequest</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (this.books.RemoveBook(id))
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
