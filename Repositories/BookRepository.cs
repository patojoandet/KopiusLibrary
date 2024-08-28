using KopiusLibrary.Model;
using KopiusLibrary.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace KopiusLibrary.Repositories
{
    public class BookRepository : IBookRepository
    {
        public LibraryContext Context { get; set; }

        public BookRepository(LibraryContext context)
        {
            Context = context;
        }

        public IEnumerable<BookDTO> Get()
        {
            return Context.Books.Select(b => new BookDTO
            {
                Id = b.Id,
                Title = b.Title,
                Authors = Context.Authors.Join(
                    b.AuthorBook,
                    a => a.Id,
                    ab => ab.AuthorId,
                    (a, ab) => a
                    ).ToList(),
                Description = b.Description,
                ReleaseYear = b.ReleaseYear,
                Genres = Context.Genres.Join(
                    b.BookGenre,
                    g => g.Id,
                    bg => bg.GenreId,
                    (g, bg) => g
                    ).ToList(),
                Publisher = b.Publisher,    
                Branch = b.Branch,
                ISBN = b.ISBN,

            });
        }

        public IEnumerable<Book> GetByName(string Title)
        {
            return Context.Books
             .Where(b => b.Title.ToLower().Contains(Title.ToLower()))
             .Include(b => b.AuthorBook)
             .Include(b => b.BookGenre)
             .Include(b => b.Branch)
             .Include(b => b.Publisher)
             .ToList();
        }

        //public void Add(Book book)
        //{
        //    Context.Books.Add(book);
        //    Context.SaveChangesAsync();
        //}
    }
}
