using AutoMapper;
using week4_homeworks.DBOperations;

namespace week4_homeworks.Applications.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly IBookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetGenresQuery(IBookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _dbcontext.Genres.Where(g => g.IsActive).OrderBy(g => g.Id);

            List<GenresViewModel> returnObj = _mapper.Map<List<GenresViewModel>>(genres);
            return returnObj;
        }

    }

    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }



}
