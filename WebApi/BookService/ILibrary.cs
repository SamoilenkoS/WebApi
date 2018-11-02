// <copyright file="ILibrary.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebApi.BookService
{
    /// <summary>
    /// ILibrary interface
    /// </summary>
    public interface ILibrary : IBook, IAuthor, IGenre
    {
    }
}
