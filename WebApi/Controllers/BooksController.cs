// <copyright file="BooksController.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.BookService;
    using WebLib.Models;

    /// <summary>
    /// Book controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        /// <summary>
        /// IBook interface link
        /// </summary>
        private readonly IBook bookService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class
        /// </summary>
        /// <param name="bookService">IBook interface link</param>
        public BooksController(ILibrary bookService)
        {
            this.bookService = bookService;
        }

        /// <summary>
        /// Adding book
        /// </summary>
        /// <param name="book">Book to add</param>
        /// <returns>Added book</returns>
        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            this.bookService.AddBook(book);
            return this.Created("books", book);
        }

        /// <summary>
        /// Adding author to the book
        /// </summary>
        /// <param name="bookId">Book id for author add</param>
        /// <param name="authorId">Author id for add</param>
        /// <returns>Status of adding author</returns>
        [HttpPost("{bookId}/authors/{authorId}")]
        public IActionResult AddBookAuthor(int bookId, int authorId)
        {
            if (this.bookService.AddBookAuthor(bookId, authorId))
            {
                return this.Ok();
            }

            return this.BadRequest("Book or author doesn`t exist or book already has this author!");
        }

        /// <summary>
        /// Adding genre to the book
        /// </summary>
        /// <param name="bookId">Book id for genre add</param>
        /// <param name="genreId">Genre id for add</param>
        /// <returns>Status of adding genre</returns>
        [HttpPost("{bookId}/genres/{genreId}")]
        public IActionResult AddBookGenre(int bookId, int genreId)
        {
            if (this.bookService.AddBookGenre(bookId, genreId))
            {
                return this.Ok();
            }

            return this.BadRequest("Book or genre doesn`t exist or book already has this genre");
        }

        /// <summary>
        /// Getting all books method
        /// </summary>
        /// <returns>List of books</returns>
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return this.Ok(this.bookService.GetAllBooks().ToList());
        }

        /// <summary>
        /// Getting single book by id
        /// </summary>
        /// <param name="id">Book id to get</param>
        /// <returns>Book or NotFound</returns>
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            Book resultBook = this.bookService.GetBookById(id);
            if (resultBook == null)
            {
                return this.NotFound();
            }

            return this.Ok(resultBook);
        }

        /// <summary>
        /// Getting book authors
        /// </summary>
        /// <param name="bookId">Book id to get authors</param>
        /// <returns>List of authors</returns>
        [HttpGet("{bookId}/authors")]
        public IActionResult GetBookAuthors(int bookId)
        {
            IList<Author> authors = this.bookService.GetBookAuthors(bookId);
            if (authors != null && authors.Count != 0)
            {
                return this.Ok(authors);
            }

            return this.NotFound("Book doesn`t exist or book doesn`t containts authors!");
        }

        /// <summary>
        /// Getting book genres
        /// </summary>
        /// <param name="bookId">Book id to get genres</param>
        /// <returns>List of genres</returns>
        [HttpGet("{bookId}/genres")]
        public IActionResult GetBookGenres(int bookId)
        {
            IList<Genre> genres = this.bookService.GetBookGenres(bookId);
            if (genres != null && genres.Count != 0)
            {
                return this.Ok(genres);
            }

            return this.NotFound("Book doesn`t exist or book doesn`t containts authors!");
        }

        /// <summary>
        /// Getting books of genre
        /// </summary>
        /// <param name="genreId">Genre id to get its books</param>
        /// <returns>List of books</returns>
        [HttpGet("{genreId}/books")]
        public IActionResult GetBooksInGenre(int genreId)
        {
            List<Book> booksOfGenre = this.bookService.GetBooksInGenre(genreId).ToList();
            if (booksOfGenre.Count != 0)
            {
                return this.Ok(booksOfGenre);
            }

            return this.NotFound("Genre of books of genre wasn`t found!");
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
            if (this.bookService.UpdateBook(id, book))
            {
                return this.Ok(book);
            }

            return this.NotFound();
        }

        /// <summary>
        /// Updating book genre (replacing one to other)
        /// </summary>
        /// <param name="bookId">Book id to update it`s genre</param>
        /// <param name="oldGenreId">Old genre id</param>
        /// <param name="newGenreId">New genre id</param>
        /// <returns>Status of update</returns>
        [HttpPut("{bookId}/genres/{oldGenreId}/{newGenreId}")]
        public IActionResult UpdateBookGenre(int bookId, int oldGenreId, int newGenreId)
        {
            if (this.bookService.UpdateBookGenre(bookId, oldGenreId, newGenreId))
            {
                return this.Ok("Selected genre of selected book successfully updated!");
            }

            return this.BadRequest("Genre of book not updated!");
        }

        /// <summary>
        /// Updating book author (replacing one to other)
        /// </summary>
        /// <param name="bookId">Book id to update it`s author</param>
        /// <param name="oldAuthorId">Old author id</param>
        /// <param name="newAuthorId">New author id</param>
        /// <returns>Status of update</returns>
        [HttpPut("{bookId}/authors/{oldAuthorId}/{newAuthorId}")]
        public IActionResult UpdateBookAuthor(int bookId, int oldAuthorId, int newAuthorId)
        {
            if (this.bookService.UpdateBookAuthor(bookId, oldAuthorId, newAuthorId))
            {
                return this.Ok("Selected author of selected book successfully updated!");
            }

            return this.BadRequest("Author of book not updated!");
        }

        /// <summary>
        /// Deleting book by id
        /// </summary>
        /// <param name="id">Id of book</param>
        /// <returns>Ok or BadRequest</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (this.bookService.DeleteBook(id))
            {
                return this.Ok();
            }

            return this.BadRequest("There is no book with such id!");
        }

        /// <summary>
        /// Deleting book author
        /// </summary>
        /// <param name="bookId">Book id to remove author</param>
        /// <param name="authorId">Author id to remove</param>
        /// <returns>Status of author removing</returns>
        [HttpDelete("{bookId}/authors/{authorId}")]
        public IActionResult DeleteBookAuthor(int bookId, int authorId)
        {
            if (this.bookService.DeleteBookAuthor(bookId, authorId))
            {
                return this.Ok("Selected author of selected book successfully removed");
            }

            return this.BadRequest("Author of book not removed");
        }

        /// <summary>
        /// Delete book genre
        /// </summary>
        /// <param name="bookId">Book id to remove genre</param>
        /// <param name="genreId">Genre id to remove</param>
        /// <returns>Status of genre removing</returns>
        [HttpDelete("{bookId}/genres/{genreId}")]
        public IActionResult DeleteBookGenre(int bookId, int genreId)
        {
            if (this.bookService.DeleteBookGenre(bookId, genreId))
            {
                return this.Ok("Selected genre of selected book successfully removed");
            }

            return this.BadRequest("Genre of book not removed");
        }
    }
}
