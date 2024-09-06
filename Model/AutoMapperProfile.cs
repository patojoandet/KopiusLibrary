using AutoMapper;
using KopiusLibrary.Model.DTO;
using KopiusLibrary.Model.Entities;
using KopiusLibrary.Repositories;


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

            CreateMap<BookDTO, Book>()
                .ForMember(dest => dest.AuthorBook, opt => opt.Ignore())
                .ForMember(dest => dest.BookGenre, opt => opt.Ignore())
                .ForMember(dest => dest.Publisher, opt => opt.Ignore())
                .ForMember(dest => dest.Branch, opt => opt.Ignore());

            CreateMap<BookUpdateDTO, Book>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<AuthorDTO, Author>();
            CreateMap<GenreDTO, Genre>();
            CreateMap<BranchDTO, Branch>();
            CreateMap<PublisherDTO, Publisher>();
        }
    }
}
