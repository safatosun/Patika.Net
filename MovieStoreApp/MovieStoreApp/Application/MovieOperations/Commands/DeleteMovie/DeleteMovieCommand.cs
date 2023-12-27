using MovieStoreApp.DBOperations;

namespace MovieStoreApp.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public int MovieId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(m=>m.Id==MovieId);
            if (movie is null)
                throw new InvalidOperationException("The Movie could not find.");

            movie.IsActive = false;

            _dbContext.SaveChanges();

        }

    }
}
