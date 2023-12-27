using AutoMapper;
using MovieStoreApp.DBOperations;

namespace MovieStoreApp.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public int MovieId { get; set; }
        public UpdateMovieModelDto Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public void Handle() 
        {
            
            var movie = _dbContext.Movies.SingleOrDefault(m=>m.Id == MovieId);

            if (movie is null)
                throw new InvalidOperationException("Movie could not find.");

            _mapper.Map(Model, movie);

            _dbContext.SaveChanges();
            
        }

    }


    public class UpdateMovieModelDto
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; }


    }
}
