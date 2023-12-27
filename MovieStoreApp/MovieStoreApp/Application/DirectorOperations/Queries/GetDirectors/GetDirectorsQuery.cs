using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreApp.DBOperations;

namespace MovieStoreApp.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public List<DirectorsViewModel> Handle()
        {
            
            var directors = _dbContext.Directors.Include(d=>d.Movies).ToList(); 

            var vm = _mapper.Map<List<DirectorsViewModel>>(directors);

            return vm;

        }

    }

    public class DirectorsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> MoviesName { get; set; } 
    }
}
