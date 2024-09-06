using AutoMapper;
using KopiusLibrary.Model;
using KopiusLibrary.Model.DTO;
using KopiusLibrary.Model.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace KopiusLibrary.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public LibraryContext Context { get; set; }
        private readonly IMapper _mapper;

        public AuthorRepository(LibraryContext context, Mapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }
        public Author ByName(string name)
        {
            return Context.Authors.FirstOrDefault(a => a.Name == name);
        }

        public IEnumerable<AuthorDTO> GetAll()
        {
            var authors = Context.Authors
                .Include(a=> a.Name)
                .Include(a => a.Bio)
                .Include(a => a.BirthDate)
                .Include(a => a.DeathDate)
            .ToList();

            return authors.Select(author => _mapper.Map<AuthorDTO>(author)).ToList();
        }
    }
}
