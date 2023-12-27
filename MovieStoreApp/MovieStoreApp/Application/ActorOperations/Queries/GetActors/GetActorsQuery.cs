using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;

namespace MovieStoreApp.Application.ActorOperations.Queries.GetActors
{
    public class GetActorsQuery
    {

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ActorsViewModel> Handle()
        {
            
            var actors = _dbContext.Actors.Include(a=>a.ActorMovies).ThenInclude(m=>m.Movie).ToList();
            var vm = _mapper.Map<List<ActorsViewModel>>(actors);
            return vm;

        }
    }

    public class ActorsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> MovieNames { get; set; }
    }
}
