using AutoMapper;
using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;

namespace MovieStoreApp.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommand
    {
        public  CreateActorModelDto Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateActorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(a=>a.Name == Model.Name && a.SurName == Model.SurName);
           
            if (actor is not null)
                throw new InvalidOperationException("Actor already exists.");

            actor = _mapper.Map<Actor>(Model);

            _dbContext.Actors.Add(actor);
            _dbContext.SaveChanges();   

        }
    }

    public class CreateActorModelDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
