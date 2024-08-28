using KopiusLibrary.Model;
using KopiusLibrary.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace KopiusLibrary.Repositories
{
    public class BookRepository : IBookRepository
    {
        public LibraryContext Context { get; set; }

        public BookRepository(LibraryContext context)
        {
            Context = context;
        }

        public IEnumerable<Book> Get()
        {
            return Context.Books
                .Include(b => b.AuthorBook)
                
                    .ThenInclude(ab => ab.Author)
                .Include(b => b.BookGenre)
                .Include(b => b.Branch)
                .Include(b => b.Publisher)
                .ToList();
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
