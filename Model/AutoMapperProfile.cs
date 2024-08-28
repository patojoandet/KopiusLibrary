using AutoMapper;
using KopiusLibrary.Model.DTO;
using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Model
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.AuthorBook.Select(ab => ab.Author)))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.BookGenre.Select(bg => bg.Genre)));
            CreateMap<Author, AuthorDTO>();
            CreateMap<Branch, BranchDTO>();
            CreateMap<Genre, GenreDTO>();
            CreateMap<Publisher, PublisherDTO>();
        }
    }
}
