using AutoMapper;
using MovieStoreApp.DBOperations;

namespace MovieStoreApp.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        public int DirectorId { get; set; }
        public UpdateDirectorModelDto Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateDirectorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(d=>d.Id==DirectorId);
            
            if (director is null)
                throw new InvalidOperationException("The Director could not find.");

            _mapper.Map(Model,director);
            _dbContext.SaveChanges();

        }

    }

    public class UpdateDirectorModelDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
