using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreApp.DBOperations;

namespace MovieStoreApp.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {

        private IMovieStoreDbContext _dbContext;
        private IMapper _mapper;

        public GetMoviesQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public List<MoviesViewModel> Handle()
        {
            var movies = _dbContext.Movies.Include(m => m.Genre).Include(m => m.Director).Where(m=>m.IsActive == true).ToList();

            List<MoviesViewModel> viewModel = _mapper.Map<List<MoviesViewModel>>(movies);

            return viewModel;
        
        }

    }

    public class MoviesViewModel
    {
        public string Name { get; set; }
        public string GenreName { get; set; }
        public string DirectorName { get; set; }
        public int Price { get; set; }
    }

}
