// <copyright file="Book.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebLib.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Model of book for UI and Back
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Static counter for unique id creation
        /// </summary>
        private static int booksCount;

        /// <summary>
        /// Initializes static members of the <see cref="Book"/> class
        /// </summary>
        static Book()
        {
            booksCount = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class
        /// </summary>
        /// <param name="title">Title of book</param>
        public Book(string title)
        {
            this.Id = booksCount++;
            this.Title = title;
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
        /// Gets title of book
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Every book has title!")]
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
                if (this.Title == bookToCheckEquals.Title)
                {
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// HashCode override
        /// </summary>
        /// <returns>HashCode of book</returns>
        public override int GetHashCode()
        {
            return this.Title.GetHashCode();
        }
    }
}