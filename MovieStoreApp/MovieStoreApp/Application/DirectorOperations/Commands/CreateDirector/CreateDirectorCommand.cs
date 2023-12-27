using AutoMapper;
using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;

namespace MovieStoreApp.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        public CreateDirectorModelDto modelDto { get; set; }
       
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateDirectorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(d=>d.Name == modelDto.Name && d.Surname == modelDto.Surname);

            if (director is not null)
                throw new InvalidOperationException("The director already exists.");

            director = _mapper.Map<Director>(modelDto);

            _dbContext.Directors.Add(director); 
            _dbContext.SaveChanges();

        }
    }

    public class CreateDirectorModelDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }


}
