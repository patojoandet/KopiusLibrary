using KopiusLibrary.Model.DTO;

namespace KopiusLibrary.Model.Entities
{
    public interface IBook
    {
         Guid Id { get; set; }
         string Title { get; set; }
         string Description { get; set; }
         IEnumerable<AuthorDTO> Authors { get; set; }
         IEnumerable<GenreDTO> Genres { get; set; }
         int ReleaseYear { get; set; }
         PublisherDTO Publisher { get; set; }
         BranchDTO Branch { get; set; }
         string ISBN { get; set; }
    }
}
