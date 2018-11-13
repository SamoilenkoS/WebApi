// <copyright file="Genre.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebLib.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Genre of book
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Genre objects count
        /// </summary>
        private static int genresCount;

        /// <summary>
        /// Initializes static members of the <see cref="Genre"/> class
        /// </summary>
        static Genre()
        {
            genresCount = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Genre"/> class
        /// </summary>
        /// <param name="genreTitle">Title of genre</param>
        public Genre(string genreTitle)
        {
            this.Id = genresCount++;
            this.GenreTitle = genreTitle;
        }

        /// <summary>
        /// Gets genre Id
        /// </summary>
        public int Id
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets genre title
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Field must be atleast 2 characters")]
        public string GenreTitle
        {
            get;
            private set;
        }

        /// <summary>
        /// Equals of two genres override
        /// </summary>
        /// <param name="genre">Genre to compare</param>
        /// <returns>True if genre title is the same</returns>
        public override bool Equals(object genre)
        {
            bool result = false;
            if (genre is Genre)
            {
                Genre genreObject = genre as Genre;
                if (genreObject.GenreTitle == this.GenreTitle)
                {
                    result = true;
                }
            }
           
            return result;
        }

        /// <summary>
        /// GetHashCode override
        /// </summary>
        /// <returns>HashCode of genre</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.GenreTitle);
        }
    }
}
