using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KopiusLibrary.Model.Entities
{
    public class Book : IEquatable<Book>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<AuthorBook> AuthorBook { get; set; }
        public IEnumerable<BookGenre> BookGenre { get; set; }
        public int ReleaseYear { get; set; }
        public Publisher Publisher { get; set; }
        public Branch Branch { get; set; }
        public string ISBN { get; set; }

        public bool Equals(Book? other)
        {
            return this.ISBN == other?.ISBN;
        }
    }
}
