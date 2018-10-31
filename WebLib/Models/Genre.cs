

namespace WebLib.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Genre
    {
        private static int genreIdCount;

        static Genre()
        {
            genreIdCount = 1;
        }

        public Genre(string genreTitle)
        {
            this.Id = genreIdCount++;
            this.GenreTitle = genreTitle;
        }

        public int Id
        {
            get;
            private set;
        }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Field must be atleast 2 characters")]
        public string GenreTitle
        {
            get;
            set;
        }
    }
}
