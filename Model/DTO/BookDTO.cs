using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Model.DTO
{
    public class BookDTO
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<AuthorDTO> Authors { get; set; }
        public IEnumerable<GenreDTO> Genres { get; set; }
        public int ReleaseYear { get; set; }
        public PublisherDTO Publisher { get; set; }
        public BranchDTO Branch { get; set; }
        public string ISBN { get; set; }
    }
}
