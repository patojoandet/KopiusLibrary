using KopiusLibrary.Model.DTO;
using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<BookDTO> Get();
        Book GetById(Guid id);
        Response Update(BookUpdateDTO book);
        IEnumerable<BookDTO> GetByName(string Title);
        void Add(BookDTO book);
        Author AuthorByName(string name);
        Genre GenreByName(string name);
        Publisher PublisherByName(string name);
        Branch BranchByName(string name);
        Boolean InvalidBook(BookDTO book);

    }
}
