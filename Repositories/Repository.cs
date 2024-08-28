using KopiusLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace KopiusLibrary.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly LibraryContext _libraryContext;
        protected readonly DbSet<T> _dbSet;

        public Repository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
            _dbSet = _libraryContext.Set<T>();
        }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
