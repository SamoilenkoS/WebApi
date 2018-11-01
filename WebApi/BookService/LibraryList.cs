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

        private readonly List<Genre> genres;

        /// <summary>
        /// 
        /// </summary>
        private readonly List<KeyValuePair<Book, Genre>> booksGenres;

        /// <summary>
        /// List of book->author pairs
        /// </summary>
        private readonly List<KeyValuePair<Book, Author>> booksAuthors;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryList"/> class
        /// </summary>
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
            Author bookAuthor = this.authors.FirstOrDefault(author => author.Id == book.AuthorId);
            if (bookAuthor == null)
            {
                book.AuthorId = null;
            } // null if author doesn`t exist

            this.books.Add(book);
            return book.Id;
        }

        public bool AddBookAuthor(int bookId, int authorId)
        {
            Author authorOfBook = this.authors.FirstOrDefault(author => author.Id == authorId);
            Book bookToAddAuthor = this.books.FirstOrDefault(book => book.Id == bookId);
            bool result = false;
            if (bookToAddAuthor != null && authorOfBook != null)
            {
                KeyValuePair<Book, Author> bookAuthorPair = new KeyValuePair<Book, Author>(bookToAddAuthor, authorOfBook);
                bool noteExist = booksAuthors.Contains(bookAuthorPair);
                if(!noteExist)
                {
                    result = true;
                    booksAuthors.Add(bookAuthorPair);
                }
            }
            return result;
        }

        public bool AddBookGenre(int bookId, int genreId)
        {
            Genre genreOfBook = this.genres.FirstOrDefault(genre => genre.Id == genreId);
            Book bookToAddGenre = this.books.FirstOrDefault(book => book.Id == bookId);
            bool result = false;
            if (bookToAddGenre != null && genreOfBook != null)
            {
                KeyValuePair<Book, Genre> bookGenrePair = new KeyValuePair<Book, Genre>(bookToAddGenre, genreOfBook);
                bool noteExist = booksGenres.Contains(bookGenrePair);
                if (!noteExist)
                {
                    result = true;
                    booksGenres.Add(bookGenrePair);
                }
            }
            return result;
        }

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
            List<Book> authorBooks = (from book in this.books where book.AuthorId == authorId select book).ToList();
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

        public List<Author> GetBookAuthors(int bookId)
        {
            Book book = this.books.FirstOrDefault(bookToGetAuthors => bookToGetAuthors.Id == bookId);
            List<Author> authorsOfBook = null;
            if (book != null)
            {
                authorsOfBook = (from bookAuthorPair in booksAuthors
                                              where bookAuthorPair.Key.Id == bookId
                                              select bookAuthorPair.Value).ToList();
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
            Book resultBook = this.books.FirstOrDefault(book => book.Id == id);
            return resultBook;
        }

        public List<Genre> GetBookGenres(int bookId)
        {
            Book book = this.books.FirstOrDefault(bookToGetAuthors => bookToGetAuthors.Id == bookId);
            List<Genre> genresOfBook = null;
            if (book != null)
            {
                genresOfBook = (from bookGenrePair in booksGenres
                                 where bookGenrePair.Key.Id == bookId
                                 select bookGenrePair.Value).ToList();
            }
            return genresOfBook;
        }

        public IEnumerable<Book> GetBooksByGenre(int genreId)
        {
            Genre genre = this.genres.FirstOrDefault(currentGenre => currentGenre.Id == genreId);
            if (genre != null)
            {
                List<Book> booksWithGenre = 
                    (from bookGenrePair in this.booksGenres
                     where bookGenrePair.Value.Id == genreId
                     select bookGenrePair.Key).ToList();
                return booksWithGenre;
            }
            return null;
        }

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
                this.books.RemoveAll(book => book.AuthorId == id);
                this.booksAuthors.RemoveAll(bookAuthorPair => bookAuthorPair.Key.AuthorId == id);
            }

            return result;
        }

        /// <summary>
        /// Removing book by id
        /// </summary>
        /// <param name="id">Id of book to remove</param>
        /// <returns>True if book was successfully removed</returns>
        public bool RemoveBook(int id)
        {
            Book bookToDelete = this.books.FirstOrDefault(book => book.Id == id);
            bool result = false;
            if (bookToDelete != null)
            {
                this.books.Remove(bookToDelete);
                this.booksAuthors.RemoveAll(bookAuthorPair => bookAuthorPair.Key.Id == id);
                this.booksGenres.RemoveAll(bookGenrePair => bookGenrePair.Key.Id == id);
                result = true;
            }

            return result;
        }

        public bool RemoveGenre(int genreId)
        {
            Genre genre = this.genres.FirstOrDefault(currentGenre => currentGenre.Id == genreId);
            bool result = false;
            if (genre != null)
            {
                if (GetBooksByGenre(genreId).ToList().Count == 0)
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
        /// <param name="author">New info</param>
        /// <returns>True if successfull updated</returns>
        public bool UpdateAuthor(int id, Author author)
        {
            Author authorToUpdate = this.authors.FirstOrDefault(AUTHOR => AUTHOR.Id == id);
            bool result = false;
            if (authorToUpdate != null)
            {
                result = true;
                authorToUpdate.Clone(author);
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
        /// Updated book author
        /// </summary>
        /// <param name="bookId">Id of book</param>
        /// <param name="authorId">New author id</param>
        /// <returns>True if successfully updated (false if author doesn`t exist)</returns>
        public bool UpdateBooksAuthor(int bookId, int authorId)
        {
            Book bookToUpdate = this.books.FirstOrDefault(book => book.Id == bookId);
            Author author = this.authors.FirstOrDefault(currentAuthor => currentAuthor.Id == authorId);
            bool result = false;
            if (bookToUpdate != null)
            {
                if (author != null)
                {
                    result = true;
                    bookToUpdate.AuthorId = authorId;
                }
                else
                {
                    bookToUpdate.AuthorId = null;
                }
            }

            return result;
        }
    }
}