using System.Text.Json.Serialization;

namespace KopiusLibrary.Model.Entities
{
    public class Branch
    {
        public Guid Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string City { get; set; }
        public IEnumerable<Vendor> Vendors { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
