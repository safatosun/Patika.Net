using AutoMapper;
using MovieStoreApp.Application.ActorOperations.Commands.CreateActor;
using MovieStoreApp.Application.ActorOperations.Commands.UpdateActor;
using MovieStoreApp.Application.ActorOperations.Queries.GetActors;
using MovieStoreApp.Application.CustomerOperations.Commands.CreateCustomer;
using MovieStoreApp.Application.DirectorOperations.Commands.CreateDirector;
using MovieStoreApp.Application.DirectorOperations.Commands.UpdateDirector;
using MovieStoreApp.Application.DirectorOperations.Queries.GetDirectors;
using MovieStoreApp.Application.MovieOperations.Commands.CreateMovie;
using MovieStoreApp.Application.MovieOperations.Commands.UpdateMovie;
using MovieStoreApp.Application.MovieOperations.Queries.GetMovies;
using MovieStoreApp.Application.OrderOperations.Queries.GetOrderByCustomerId;
using MovieStoreApp.Application.OrderOperations.Queries.GetOrderById;
using MovieStoreApp.Entities;

namespace MovieStoreApp.Common
{ 
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<CreateMovieModelDto,Movie>();
			CreateMap<UpdateMovieModelDto,Movie>();
			CreateMap<Movie,MoviesViewModel>().ForMember(dest=>dest.GenreName,opt=>opt.MapFrom(m=>m.Genre.Name))
											  .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(m => m.Director.Name));

			CreateMap<CreateCustomerModelDto,Customer>();	

			CreateMap<CreateActorModelDto,Actor>();
			CreateMap<UpdateActorModelDto,Actor>();
			CreateMap<Actor,ActorsViewModel>().ForMember(dest => dest.MovieNames, opt => opt.MapFrom(src => src.ActorMovies.Select(m=>m.Movie.Name)));

			CreateMap<CreateDirectorModelDto,Director>();
			CreateMap<UpdateDirectorModelDto,Director>();
			CreateMap<Director,DirectorsViewModel>().ForMember(dest => dest.MoviesName, opt => opt.MapFrom(src => src.Movies.Select(m => m.Name)));

			CreateMap<Order,OrderViewModel>().ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                                             .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Name));
            
			CreateMap<Order, CustomerOrderViewModel>().ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                                             .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Name));
        }
	}
}