using AutoMapper;
using week4_homeworks.DBOperations;

namespace week4_homeworks.Applications.GenreOperations.Queries.GetGenreById
{
    public class GetGenreByIdQuery
    {
        public int GenreId { get; set; } 
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenreByIdQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public GenreViewModel Handle()
        {
            var genre = _dbContext.Genres.Where(g => g.IsActive && g.Id == GenreId).SingleOrDefault();

            if(genre is null)
            {
                throw new InvalidOperationException("Genre type could not found.");
            }

            GenreViewModel viewModel = _mapper.Map<GenreViewModel>(genre);

            return viewModel;
        }

    }

    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

}
