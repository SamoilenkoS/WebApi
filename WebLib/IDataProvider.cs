using System;
using System.Collections.Generic;
using System.Text;
using WebLib.Models;

namespace WebLib
{
    public interface IDataProvider
    {
        IEnumerable<Book> GetBooks();
        IEnumerable<Author> GetAuthors();
        IEnumerable<Genre> GetGenres();
        IEnumerable<KeyValuePair<Book, Genre>> GetBooksGenres();
        IEnumerable<KeyValuePair<Book, Author>> GetBooksAuthors();
    }
}
