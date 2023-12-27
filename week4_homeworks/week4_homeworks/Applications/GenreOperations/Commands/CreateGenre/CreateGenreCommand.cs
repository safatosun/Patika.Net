using AutoMapper;
using week4_homeworks.DBOperations;
using week4_homeworks.Entities;

namespace week4_homeworks.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGenreCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(g=>g.Name==Model.Name);
           
            if(genre is not null)
            {
                throw new InvalidOperationException("Genre already exists.");
            }

            genre = new Genre();
            genre.Name = Model.Name;    
           
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();

        }

    }

    public class CreateGenreModel
    {
        public  string Name { get; set; }
    }

}
