using AutoMapper;
using KopiusLibrary.Model;
using KopiusLibrary.Model.DTO;
using KopiusLibrary.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;

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

        public void Add(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            var authorBooks = new List<AuthorBook>();
            var genreBooks = new List<BookGenre>();

            //Metodo generico?
            foreach(var AuthorDTO in bookDTO.Authors)
            {
                var existingAuthor = AuthorByName(AuthorDTO.Name);
                if(existingAuthor == null)
                {
                    existingAuthor = _mapper.Map<Author>(AuthorDTO);
                }
                authorBooks.Add(new AuthorBook { Author = existingAuthor });
            }

            foreach (var GenreDTO in bookDTO.Genres)
            {
                var existingGenre = GenreByName(GenreDTO.Name);

                if(existingGenre == null)
                {
                    existingGenre = _mapper.Map<Genre>(GenreDTO);
                }
                genreBooks.Add(new BookGenre { Genre = existingGenre });

            }

            var existingPublisher = PublisherByName(bookDTO.Publisher.Name);

            if(existingPublisher == null)
            {
                
                book.Publisher = _mapper.Map<Publisher>(bookDTO.Publisher);
            }
            book.Publisher = existingPublisher;

            var existingBranch = BranchByName(bookDTO.Branch.Email);

            if(existingBranch == null)
            {
                book.Branch = _mapper.Map<Branch>(bookDTO.Branch);
            }

            book.Branch = existingBranch;
            
            book.AuthorBook = authorBooks;


            Context.Books.Add(book);
            Context.SaveChanges();
        }

        public Author AuthorByName(string name)
        {
            return Context.Authors.FirstOrDefault(a => a.Name == name);
        }
        public Genre GenreByName(string name)
        {
            return Context.Genres.FirstOrDefault(g => g.Name == name);
        }
        public Publisher PublisherByName(string name)
        {
            return Context.Publishers.FirstOrDefault(p => p.Name == name);
        }
        public Branch BranchByName(string name)
        {
            return Context.Branches.FirstOrDefault(b => b.Email == name);
        }

        public Boolean InvalidBook(BookDTO book)
        {
            return Context.Books.Any(b => b.ISBN == book.ISBN && b.Title != book.Title);
        }

        public Book GetById(Guid id)
        {
            return Context.Books.FirstOrDefault(b => b.Id == id);
        }

        public Response Update(BookUpdateDTO book)
        {
            Book existingBook = GetById(book.Id);
            
            if(existingBook != null)
            {
                _mapper.Map(book, existingBook);
                Context.Books.Update(existingBook);
                Context.SaveChanges();
                return new Response() { Code = 200, Message = "Book updated" };
            }
            return new Response() { Code = 400, Message = "Invalid book" };
        }

    }
}
