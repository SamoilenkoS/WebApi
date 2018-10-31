using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLib.Models;

namespace WebApi.BookService
{
    public interface IGenre
    {
        int AddGenre(Genre genre);
        IEnumerable<Genre> GetAllGenres();
        Genre GetGenreById(int genreId);
        bool RemoveGenre(int genreId);
    }
}
