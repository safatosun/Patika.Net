using Microsoft.EntityFrameworkCore;
using MovieStoreApp.DBOperations;

namespace MovieStoreApp.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        public int ActorId { get; set; }

        private readonly IMovieStoreDbContext _dbContext;

        public DeleteActorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.Include(a=>a.ActorMovies).SingleOrDefault(a=>a.Id==ActorId);

            if(actor is null)
                throw new InvalidOperationException("The actor could not find.");
            if(actor.ActorMovies.Any())
                throw new InvalidOperationException("The actor has relationship with other Entity.");

            _dbContext.Actors.Remove(actor);
            _dbContext.SaveChanges();

        }

    }
}
