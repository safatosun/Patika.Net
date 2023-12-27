using AutoMapper;
using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;

namespace MovieStoreApp.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        public CreateMovieModelDto Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        
        public CreateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Name == Model.Name);

            if (movie is not null)
                throw new InvalidOperationException("Movie Already Exists.");

            var genre = _dbContext.Genres.SingleOrDefault(x => x.Id==Model.GenreId);

            if (genre is null)
                throw new InvalidOperationException("Genre could not find.");

            var director = _dbContext.Directors.SingleOrDefault(x => x.Id == Model.DirectorId);

            if (director is null)
                throw new InvalidOperationException("Director could not find.");

            var actor = _dbContext.Actors.SingleOrDefault(x => x.Id == Model.ActorId);

            if (actor is null)
                throw new InvalidOperationException("Actor could not find.");


            movie = _mapper.Map<Movie>(Model);
            movie.ActorMovies = new List<ActorMovie>();

            _dbContext.Movies.Add(movie);

            var actorMovie = new ActorMovie
            {
                MovieId = movie.Id,
                ActorId = actor.Id,
            };
            
            movie.ActorMovies.Add(actorMovie);

            _dbContext.SaveChanges();
        }
    }
        public class CreateMovieModelDto
        {
            public string Name { get; set; }
            public DateTime PublishDate { get; set; }
            public int GenreId { get; set; }
            public int Price { get; set; }
            public int DirectorId { get; set; }
            public int ActorId { get; set; }
        }
    }
