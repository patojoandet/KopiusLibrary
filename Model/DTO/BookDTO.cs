using KopiusLibrary.Model.Entities;
using System.ComponentModel.DataAnnotations;

namespace KopiusLibrary.Model.DTO
{
    public class BookDTO : IBook
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "At least one author is required.")]
        public IEnumerable<AuthorDTO> Authors { get; set; }
        [Required(ErrorMessage = "At least one genre is required.")]
        public IEnumerable<GenreDTO> Genres { get; set; }
        [Required(ErrorMessage = "Release year is required.")]
        public int ReleaseYear { get; set; }
        [Required(ErrorMessage = "Publisher is required.")]
        public PublisherDTO Publisher { get; set; }
        [Required(ErrorMessage = "Branch is required.")]
        public BranchDTO Branch { get; set; }
        [Required(ErrorMessage = "ISBN is required.")]
        public string ISBN { get; set; }
    }
}
