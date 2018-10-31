// <copyright file="Book.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebApi.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Model of book for UI and Back
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Static counter for unique id creation
        /// </summary>
        private static int idCount;

        /// <summary>
        /// Initializes static members of the <see cref="Book"/> class
        /// </summary>
        static Book()
        {
            idCount = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class
        /// </summary>
        /// <param name="title">Title of book</param>
        /// <param name="authorId">Author id(may be empty)</param>
        public Book(string title, int? authorId = null)
        {
            this.Id = idCount++;
            this.Title = title;
            this.AuthorId = authorId;
        }

        /// <summary>
        /// Gets Id 
        /// </summary>
        public int Id
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets author id
        /// </summary>
        public int? AuthorId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets title of book
        /// </summary>
        [Required(ErrorMessage = "Every book has title!")]
        public string Title
        {
            get;
            private set;
        }

        /// <summary>
        /// Cloning of book for leaving id correct
        /// </summary>
        /// <param name="book">New info of book</param>
        public void Clone(Book book)
        {
            this.Title = book.Title;
            this.AuthorId = book.AuthorId;
        }

        /// <summary>
        /// Equals override for compare ignoring bookId
        /// </summary>
        /// <param name="book">Book to compare</param>
        /// <returns>True if title and authorId are the same</returns>
        public override bool Equals(object book)
        {
            bool result = false;
            if (book is Book)
            {
                Book bookToCheckEquals = book as Book;
                if (this.AuthorId == bookToCheckEquals.AuthorId && this.Title == bookToCheckEquals.Title)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}