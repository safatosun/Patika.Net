using AutoMapper;
using week4_homeworks.Applications.AuthorOperations.Commands.CreateAuthor;
using week4_homeworks.Applications.AuthorOperations.Commands.UpdateAuthor;
using week4_homeworks.Applications.AuthorOperations.Queries.GetAuthorById;
using week4_homeworks.Applications.AuthorOperations.Queries.GetAuthors;
using week4_homeworks.Applications.BookOperations.Commands.CreateBook;
using week4_homeworks.Applications.BookOperations.Queries.GetBooks;
using week4_homeworks.Applications.BookOperations.Queries.GetById;
using week4_homeworks.Applications.GenreOperations.Queries.GetGenreById;
using week4_homeworks.Applications.GenreOperations.Queries.GetGenres;
using week4_homeworks.Applications.UserOperations.Commands.CreateUser;
using week4_homeworks.Entities;
 
namespace week4_homeworks.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap <Book,BookViewModel> ().ForMember(dest=> dest.Genre,opt=>opt.MapFrom(src=> src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreViewModel>();
            CreateMap<CreateUserModel,User>();
            CreateMap<CreateAuthorModel,Author>();
            CreateMap<UpdateAuthorModel,Author>();
            CreateMap<Author, AuthorDetailViewModel>();
            CreateMap<Author, AuthorsViewModel>();
        }
    }
}
