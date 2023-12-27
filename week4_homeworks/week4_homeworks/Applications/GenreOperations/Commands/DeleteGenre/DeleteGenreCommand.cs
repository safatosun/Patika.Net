﻿using week4_homeworks.DBOperations;

namespace week4_homeworks.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }

        private readonly IBookStoreDbContext _dbContext;

        public DeleteGenreCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(g => g.Id == GenreId);
            
            if (genre is null) 
            {
                throw new InvalidOperationException("Genre could not found.");
            }

            _dbContext.Genres.Remove(genre);    
            _dbContext.SaveChanges();

        }

    }
}
