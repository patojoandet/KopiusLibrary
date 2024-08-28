using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<BookDTO> Get();
        IEnumerable<Book> GetByName(string Title);
        //void Add(Book book);
    }
}
