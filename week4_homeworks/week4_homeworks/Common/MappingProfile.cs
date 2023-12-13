using AutoMapper;
using week4_homeworks.BookOperations.CreateBook;
using week4_homeworks.BookOperations.GetBooks;
using week4_homeworks.BookOperations.GetById;

namespace week4_homeworks.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap <Book,BookViewModel> ().ForMember(dest=> dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}
