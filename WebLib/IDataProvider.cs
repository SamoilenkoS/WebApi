using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Models;

namespace WebLib
{
    public interface IDataProvider
    {
        IEnumerable<Book> GetBooks();
        IEnumerable<Author> GetAuthors();
    }
}
