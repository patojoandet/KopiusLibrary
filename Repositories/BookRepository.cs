using AutoMapper;
using KopiusLibrary.Model;
using KopiusLibrary.Model.DTO;
using KopiusLibrary.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace KopiusLibrary.Repositories
{
    public class BookRepository : IBookRepository
    {
        public LibraryContext Context { get; set; }
        private readonly IMapper _mapper;
        public BookRepository(LibraryContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public IEnumerable<BookDTO> Get()
        {
            //return Context.Books.Select(b => new BookDTO
            //// Costoso, el automapper me reduce el costo de mantenimiento, performance y legibilidad
            //// CAMBIAR A AUTOMAPPER
            //{
            //    Id = b.Id,
            //    Title = b.Title,
            //    Authors = Context.Authors.Join(
            //        b.AuthorBook,
            //        a => a.Id,
            //        ab => ab.AuthorId,
            //        (a, ab) => a
            //        ).ToList(),
            //    Description = b.Description,
            //    ReleaseYear = b.ReleaseYear,
            //    Genres = Context.Genres.Join(
            //        b.BookGenre,
            //        g => g.Id,
            //        bg => bg.GenreId,
            //        (g, bg) => g
            //        ).ToList(),
            //    Publisher = b.Publisher,    
            //    Branch = b.Branch,
            //    ISBN = b.ISBN,
            //});


            var books = Context.Books
                .Include(b => b.AuthorBook)
                    .ThenInclude(ab => ab.Author)
                .Include(b => b.BookGenre)
                    .ThenInclude(bg => bg.Genre)
                .Include(b => b.Publisher)
                .Include(b => b.Branch)
                .ToList();

            return books.Select(book => _mapper.Map<BookDTO>(book)).ToList();
        }

        public IEnumerable<BookDTO> GetByName(string Title)
        {
            var books = Context.Books
                .Where(b => b.Title.ToLower().Contains(Title.ToLower()))
                .Include(b => b.AuthorBook)
                    .ThenInclude(ab => ab.Author)
                .Include(b => b.BookGenre)
                    .ThenInclude(bg => bg.Genre)
                .Include(b => b.Publisher)
                .Include(b => b.Branch)
                .ToList();

            return books.Select(book => _mapper.Map<BookDTO>(book)).ToList();
        }

        //public void Add(Book book)
        //{
        //    Context.Books.Add(book);
        //    Context.SaveChangesAsync();
        //}
    }
}
