using AutoMapper;
using MovieStoreApp.DBOperations;

namespace MovieStoreApp.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        public  int ActorId  { get; set; }
        public UpdateActorModelDto Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateActorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(a=>a.Id==ActorId);
            if (actor is null)
            {
                throw new InvalidOperationException("Actor could not find.");
            }

            _mapper.Map(Model,actor);

            _dbContext.SaveChanges();
        }

    }

    public class UpdateActorModelDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

}
