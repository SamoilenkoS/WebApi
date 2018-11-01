using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookService;
using WebLib.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        /// <summary>
        /// IBook interface link
        /// </summary>
        private readonly ILibrary library;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class
        /// </summary>
        /// <param name="library">IBook interface link</param>
        public GenresController(ILibrary library)
        {
            this.library = library;
        }

        [HttpPost]
        public IActionResult AddGenre(Genre genre)
        {
            this.library.AddGenre(genre);
            return this.Created("genres", genre);
        }

        [HttpGet]
        public IActionResult GetAllGenres()
        {
            return this.Ok(library.GetAllGenres().ToList());
        }

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

        [HttpGet("{genreId}/books")]
        public IActionResult GetBooksOfGenre(int genreId)
        {
            List<Book> booksOfGenre = this.library.GetBooksByGenre(genreId).ToList();
            if(booksOfGenre.Count!=0)
            {
                return this.Ok(booksOfGenre);
            }

            return this.NotFound("Genre of books of genre wasn`t found!");
        }

        [HttpDelete("{genreId}")]
        public IActionResult RemoveGenre(int genreId)
        {
            if(library.RemoveGenre(genreId))
            {
                return Ok("Genre removed");
            }
            return BadRequest("Genre wasn`t found or there are some books with this genre!");
        }

    }
}