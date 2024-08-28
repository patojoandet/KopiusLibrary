namespace KopiusLibrary.Model.Entities
{
    public class BookDTO
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public int ReleaseYear { get; set; }
        public Publisher Publisher { get; set; }
        public Branch Branch { get; set; }
        public string ISBN { get; set; }
    }
}
