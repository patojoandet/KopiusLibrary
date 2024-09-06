using KopiusLibrary.Model.DTO;
using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<AuthorDTO> GetAll();
        Author ByName(string name);

    }
}
