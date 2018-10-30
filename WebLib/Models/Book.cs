// <copyright file="Book.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebLib.Models
{
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
        public Book(string title)
        {
            this.Id = idCount++;
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
        /// Gets or sets title of book
        /// </summary>
        public string Title
        {
            get;
            set;
        }
    }
}