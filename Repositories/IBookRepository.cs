using KopiusLibrary.Model.DTO;
using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<BookDTO> Get();
        IEnumerable<BookDTO> GetByName(string Title);
        //void Add(Book book);
    }
}
