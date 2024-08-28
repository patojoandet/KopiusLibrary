using System.Text.Json.Serialization;

namespace KopiusLibrary.Model.Entities
{
    public class Publisher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
