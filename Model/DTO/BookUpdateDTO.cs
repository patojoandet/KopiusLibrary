using KopiusLibrary.Model.Entities;
using System.ComponentModel.DataAnnotations;

namespace KopiusLibrary.Model.DTO
{
    public class BookUpdateDTO
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? ReleaseYear { get; set; }
    }
}
