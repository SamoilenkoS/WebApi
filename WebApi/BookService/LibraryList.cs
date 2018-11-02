// <copyright file="LibraryList.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebApi.BookService
{
    using System.Collections.Generic;
    using System.Linq;
    using WebLib;
    using WebLib.Models;

    /// <summary>
    /// Implementation of IBook
    /// </summary>
    public class LibraryList : ILibrary
    {
        /// <summary>
        /// List of books
        /// </summary>
        private readonly List<Book> books;

        /// <summary>
        /// List of authors
        /// </summary>
        private readonly List<Author> authors;

        /// <summary>
        /// Genres list
        /// </summary>
        private readonly List<Genre> genres;

        /// <summary>
        /// Book-genres pairs list
        /// </summary>
        private readonly List<KeyValuePair<int, int>> booksGenres;

        /// <summary>
        /// List of book->author pairs
        /// </summary>
        private readonly List<KeyValuePair<int, int>> booksAuthors;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryList"/> class
        /// </summary>
        /// <param name="dataProvider">Data for lib initialize</param>
        public LibraryList(IDataProvider dataProvider)
        {
            this.authors = dataProvider.GetAuthors().ToList();
            this.books = dataProvider.GetBooks().ToList();
            this.genres = dataProvider.GetGenres().ToList();
            this.booksGenres = dataProvider.GetBooksGenres().ToList();
            this.booksAuthors = dataProvider.GetBooksAuthors().ToList();
        }

        /// <summary>
        /// Adding author
        /// </summary>
        /// <param name="author">Author to add</param>
        /// <returns>Id of author inside collection or db</returns>
        public int AddAuthor(Author author)
        {
            this.authors.Add(author);
            return author.Id;
        }

        /// <summary>
        /// Adding the book to collection
        /// </summary>
        /// <param name="book">Book to add</param>
        /// <returns>Book id</returns>
        public int AddBook(Book book)
        {
            this.books.Add(book);
            return book.Id;
        }

        /// <summary>
        /// Adding author to the book
        /// </summary>
        /// <param name="bookId">Book id for author add</param>
        /// <param name="authorId">Author id for add</param>
        /// <returns>Status of adding author</returns>
        public bool AddBookAuthor(int bookId, int authorId)
        {
            Author authorOfBook = this.authors.FirstOrDefault(author => author.Id == authorId);
            Book bookToAddAuthor = this.books.FirstOrDefault(book => book.Id == bookId);
            bool result = false;
            if (bookToAddAuthor != null && authorOfBook != null)
            {
                KeyValuePair<int, int> bookAuthorPair = new KeyValuePair<int, int>(bookToAddAuthor.Id, authorOfBook.Id);
                bool noteExist = this.booksAuthors.Contains(bookAuthorPair);
                if (!noteExist)
                {
                    result = true;
                    this.booksAuthors.Add(bookAuthorPair);
                }
            }

            return result;
        }

        /// <summary>
        /// Adding genre to the book
        /// </summary>
        /// <param name="bookId">Book id for genre add</param>
        /// <param name="genreId">Genre id for add</param>
        /// <returns>Status of adding genre</returns>
        public bool AddBookGenre(int bookId, int genreId)
        {
            Genre genreOfBook = this.genres.FirstOrDefault(genre => genre.Id == genreId);
            Book bookToAddGenre = this.books.FirstOrDefault(book => book.Id == bookId);
            bool result = false;
            if (bookToAddGenre != null && genreOfBook != null)
            {
                KeyValuePair<int, int> bookGenrePair = new KeyValuePair<int, int>(bookToAddGenre.Id, genreOfBook.Id);
                bool noteExist = this.booksGenres.Contains(bookGenrePair);
                if (!noteExist)
                {
                    result = true;
                    this.booksGenres.Add(bookGenrePair);
                }
            }

            return result;
        }

        /// <summary>
        /// Create genre
        /// </summary>
        /// <param name="genre">Genre object</param>
        /// <returns>Created genre id</returns>
        public int AddGenre(Genre genre)
        {
            this.genres.Add(genre);
            return genre.Id;
        }

        /// <summary>
        /// Getting all authors
        /// </summary>
        /// <returns>IEnumerable of authors</returns>
        public IEnumerable<Author> GetAllAuthors()
        {
            return this.authors;
        }

        /// <summary>
        /// Getting list of books
        /// </summary>
        /// <returns>List of books</returns>
        public IEnumerable<Book> GetAllBooks()
        {
            return this.books;
        }

        /// <summary>
        /// Getting all genres
        /// </summary>
        /// <returns>List of genres</returns>
        public IEnumerable<Genre> GetAllGenres()
        {
            return this.genres;
        }

        /// <summary>
        /// Getting author books
        /// </summary>
        /// <param name="authorId">Author id</param>
        /// <returns>List of books of author</returns>
        public IEnumerable<Book> GetAuthorBooks(int authorId)
        {
            IEnumerable<int> booksIds = from bookAuthorPair in this.booksAuthors
                                  where bookAuthorPair.Value == authorId
                                  select bookAuthorPair.Key;
            IEnumerable<Book> authorBooks = from book in this.books
                                            where !booksIds.Contains(book.Id)
                                            select book;
            return authorBooks;
        }

        /// <summary>
        /// Getting author by id
        /// </summary>
        /// <param name="id">Id of author</param>
        /// <returns>Author object</returns>
        public Author GetAuthorById(int id)
        {
            return this.authors.FirstOrDefault(author => author.Id == id);
        }

        /// <summary>
        /// Getting book authors
        /// </summary>
        /// <param name="bookId">Book id to get authors</param>
        /// <returns>List of authors</returns>
        public List<Author> GetBookAuthors(int bookId)
        {
            Book book = this.books.FirstOrDefault(bookToGetAuthors => bookToGetAuthors.Id == bookId);
            List<Author> authorsOfBook = null;
            if (book != null)
            {
                IEnumerable<int> authorsOfBookIds = from bookAuthorPair in this.booksAuthors
                                              where bookAuthorPair.Key == bookId
                                              select bookAuthorPair.Value;
                authorsOfBook = (from author in this.authors
                                 where authorsOfBookIds.Contains(author.Id)
                                 select author).ToList();
            }

            return authorsOfBook;
        }

        /// <summary>
        /// Getting book by id
        /// </summary>
        /// <param name="id">Id of book to get</param>
        /// <returns>Book with selected id or null if not found</returns>
        public Book GetBookById(int id)
        {
            return this.books.FirstOrDefault(book => book.Id == id);
        }

        /// <summary>
        /// Getting book genres
        /// </summary>
        /// <param name="bookId">Book id to get genres</param>
        /// <returns>List of genres</returns>
        public List<Genre> GetBookGenres(int bookId)
        {
            Book book = this.books.FirstOrDefault(bookToGetAuthors => bookToGetAuthors.Id == bookId);
            List<Genre> genresOfBook = null;
            if (book != null)
            {
                IEnumerable<int> genresOfBookIds = from bookGenrePair in this.booksGenres
                                 where bookGenrePair.Key == bookId
                                 select bookGenrePair.Value;
                genresOfBook = (from genre in this.genres
                                where genresOfBookIds.Contains(genre.Id)
                                select genre).ToList();
            }

            return genresOfBook;
        }

        /// <summary>
        /// Getting books of genre
        /// </summary>
        /// <param name="genreId">Genre id to get its books</param>
        /// <returns>List of books</returns>
        public IEnumerable<Book> GetBooksInGenre(int genreId)
        {
            Genre genre = this.genres.FirstOrDefault(currentGenre => currentGenre.Id == genreId);
            List<Book> booksWithGenre = null;
            if (genre != null)
            {
                IEnumerable<int> booksWithGenreIds = 
                    from bookGenrePair in this.booksGenres
                     where bookGenrePair.Value == genreId
                     select bookGenrePair.Key;
                booksWithGenre = (from book in this.books
                                  where booksWithGenreIds.Contains(book.Id)
                                  select book).ToList();
            }

            return booksWithGenre;
        }

        /// <summary>
        /// Getting genre by id
        /// </summary>
        /// <param name="genreId">Genre id to get</param>
        /// <returns>Genre object</returns>
        public Genre GetGenreById(int genreId)
        {
            Genre genre = this.genres.FirstOrDefault(currentGenre => currentGenre.Id == genreId);
            return genre;
        }

        /// <summary>
        /// Removing author
        /// </summary>
        /// <param name="id">Id of author for removing</param>
        /// <returns>True if successfully removed</returns>
        public bool RemoveAuthor(int id)
        {
            Author authorToRemove = this.authors.FirstOrDefault(author => author.Id == id);
            bool result = false;
            if (authorToRemove != null)
            {
                result = true;
                this.authors.Remove(authorToRemove);
                this.booksAuthors.RemoveAll(bookAuthorPair => bookAuthorPair.Value == id);
            }

            return result;
        }

        /// <summary>
        /// Removing book by id
        /// </summary>
        /// <param name="id">Id of book to remove</param>
        /// <returns>True if book was successfully removed</returns>
        public bool DeleteBook(int id)
        {
            Book bookToDelete = this.books.FirstOrDefault(book => book.Id == id);
            bool result = false;
            if (bookToDelete != null)
            {
                this.books.Remove(bookToDelete);
                this.booksAuthors.RemoveAll(bookAuthorPair => bookAuthorPair.Key == id);
                this.booksGenres.RemoveAll(bookGenrePair => bookGenrePair.Key == id);
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Deleting book author
        /// </summary>
        /// <param name="bookId">Book id to remove author</param>
        /// <param name="authorIdForRemove">Author id to remove</param>
        /// <returns>Status of author removing</returns>
        public bool DeleteBookAuthor(int bookId, int authorIdForRemove)
        {
            KeyValuePair<int, int> bookAuthorPair = new KeyValuePair<int, int>(bookId, authorIdForRemove);
            return this.booksAuthors.Remove(bookAuthorPair);
        }

        /// <summary>
        /// Delete book genre
        /// </summary>
        /// <param name="bookId">Book id to remove genre</param>
        /// <param name="bookGenreForRemove">Genre id to remove</param>
        /// <returns>Status of genre removing</returns>
        public bool DeleteBookGenre(int bookId, int bookGenreForRemove)
        {
            KeyValuePair<int, int> bookAuthorPair = new KeyValuePair<int, int>(bookId, bookGenreForRemove);
            return this.booksGenres.Remove(bookAuthorPair);
        }

        /// <summary>
        /// Deleting genre by id
        /// </summary>
        /// <param name="genreId">Genre id to delete</param>
        /// <returns>Status of deleting</returns>
        public bool DelteGenre(int genreId)
        {
            Genre genre = this.genres.FirstOrDefault(currentGenre => currentGenre.Id == genreId);
            bool result = false;
            if (genre != null)
            {
                if (this.GetBooksInGenre(genreId).ToList().Count == 0)
                {
                    this.genres.Remove(genre);
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Updating author with id using data from author object from params
        /// </summary>
        /// <param name="id">Id of author for update</param>
        /// <param name="newAuthorInfo">New info</param>
        /// <returns>True if successfull updated</returns>
        public bool UpdateAuthor(int id, Author newAuthorInfo)
        {
            Author authorToUpdate = this.authors.FirstOrDefault(author => author.Id == id);
            bool result = false;
            if (authorToUpdate != null)
            {
                result = true;
                authorToUpdate.Clone(newAuthorInfo);
            }

            return result;
        }

        /// <summary>
        /// Updating of book with selected id
        /// </summary>
        /// <param name="id">Id of book to remove</param>
        /// <param name="book">Book with data for update</param>
        /// <returns>True if book was successfully updated</returns>
        public bool UpdateBook(int id, Book book)
        {
            Book bookToUpdate = this.books.FirstOrDefault(currentBook => currentBook.Id == id);
            bool result = false;
            if (bookToUpdate != null)
            {
                bookToUpdate.Clone(book);
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Updating book author (replacing one to other)
        /// </summary>
        /// <param name="bookId">Book id to update it`s author</param>
        /// <param name="oldAuthorId">Old author id</param>
        /// <param name="newAuthorId">New author id</param>
        /// <returns>Status of update</returns>
        public bool UpdateBookAuthor(int bookId, int oldAuthorId, int newAuthorId)
        {
            KeyValuePair<int, int> bookAuthorPair = new KeyValuePair<int, int>(bookId, oldAuthorId);
            int pairIndex = this.booksAuthors.IndexOf(bookAuthorPair);
            bool result = false;
            if (pairIndex != -1)
            {
                result = true;
                this.booksAuthors[pairIndex] = new KeyValuePair<int, int>(bookId, newAuthorId);
            }

            return result;
        }

        /// <summary>
        /// Updating book genre (replacing one to other)
        /// </summary>
        /// <param name="bookId">Book id to update it`s genre</param>
        /// <param name="oldGenreId">Old genre id</param>
        /// <param name="newGenreId">New genre id</param>
        /// <returns>Status of update</returns>
        public bool UpdateBookGenre(int bookId, int oldGenreId, int newGenreId)
        {
            KeyValuePair<int, int> bookGenrePair = new KeyValuePair<int, int>(bookId, oldGenreId);
            int pairIndex = this.booksGenres.IndexOf(bookGenrePair);
            bool result = false;
            if (pairIndex != -1)
            {
                result = true;
                this.booksGenres[pairIndex] = new KeyValuePair<int, int>(bookId, newGenreId);
            }

            return result;
        }
    }
}