using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using week4_homeworks.Applications.GenreOperations.Commands.CreateGenre;
using week4_homeworks.Applications.GenreOperations.Commands.DeleteGenre;
using week4_homeworks.Applications.GenreOperations.Commands.UpdateGenre;
using week4_homeworks.Applications.GenreOperations.Queries.GetGenreById;
using week4_homeworks.Applications.GenreOperations.Queries.GetGenres;
using week4_homeworks.DBOperations;

namespace week4_homeworks.Controllers
{
    [Authorize]
    [ApiController]
    [Route("genres")]
    public class GenreController : ControllerBase
    {
      
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GenreController(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            GetGenresQuery query = new GetGenresQuery(_dbContext,_mapper);

            var obj = query.Handle();
            
            return Ok(obj);

        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id) 
        {
            GetGenreByIdQuery query = new GetGenreByIdQuery(_dbContext, _mapper);
            query.GenreId = id;
            
            GetGenreByIdQueryValidator validator = new GetGenreByIdQueryValidator();
            validator.ValidateAndThrow(query);

            var genre = query.Handle();

            return Ok(genre);

        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateGenreModel genreModel)
        {
            CreateGenreCommand createGenreCommand = new CreateGenreCommand(_dbContext,_mapper);
            createGenreCommand.Model = genreModel;

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(createGenreCommand);

            createGenreCommand.Handle();

            return StatusCode(201);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute]int id,[FromBody]UpdateGenreModel updateGenreModel)
        {

            UpdateGenreCommand updateGenreCommand = new UpdateGenreCommand(_dbContext,_mapper);
            updateGenreCommand.GenreId = id;
            updateGenreCommand.Model = updateGenreModel;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(updateGenreCommand);

            updateGenreCommand.Handle();
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            DeleteGenreCommand deleteGenreCommand = new DeleteGenreCommand(_dbContext);
            deleteGenreCommand.GenreId=id;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(deleteGenreCommand);

            deleteGenreCommand.Handle();
            return Ok();

        }
    }
}
