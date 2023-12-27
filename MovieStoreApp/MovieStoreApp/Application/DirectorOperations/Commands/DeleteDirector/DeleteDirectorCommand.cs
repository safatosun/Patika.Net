using Microsoft.EntityFrameworkCore;
using MovieStoreApp.DBOperations;

namespace MovieStoreApp.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int DirectorId { get; set; }

        private readonly IMovieStoreDbContext _dbContext;

        public DeleteDirectorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.Include(d=>d.Movies).SingleOrDefault(d=>d.Id==DirectorId);

            if (director is null)
                throw new InvalidOperationException("Director could not find.");

            if(director.Movies.Any())
                throw new InvalidOperationException("Director has relationship with other entity.");

            _dbContext.Directors.Remove(director);  
            _dbContext.SaveChanges();

        }

    }
}
