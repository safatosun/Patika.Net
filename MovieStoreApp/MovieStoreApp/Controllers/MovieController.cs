using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApp.Application.MovieOperations.Commands.CreateMovie;
using MovieStoreApp.Application.MovieOperations.Commands.DeleteMovie;
using MovieStoreApp.Application.MovieOperations.Commands.UpdateMovie;
using MovieStoreApp.Application.MovieOperations.Queries.GetMovies;

namespace MovieStoreApp.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {

        private readonly CreateMovieCommand _createMovieCommand;
        private readonly GetMoviesQuery _getMoviesQuery;
        private readonly UpdateMovieCommand _updateMovieCommand;
        private readonly DeleteMovieCommand _deleteMovieCommand;

        public MovieController(CreateMovieCommand createMovieCommand, GetMoviesQuery getMoviesQuery, UpdateMovieCommand updateMovieCommand, DeleteMovieCommand deleteMovieCommand)
        {
            _createMovieCommand = createMovieCommand;
            _getMoviesQuery = getMoviesQuery;
            _updateMovieCommand = updateMovieCommand;
            _deleteMovieCommand = deleteMovieCommand;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var movies = _getMoviesQuery.Handle();
            return Ok(movies);

        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMovieModelDto modelDto)
        {

            _createMovieCommand.Model = modelDto;
            _createMovieCommand.Handle();

            return StatusCode(201);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute]int id, [FromBody] UpdateMovieModelDto modelDto)
        {
            _updateMovieCommand.MovieId = id;
            _updateMovieCommand.Model=modelDto;

            _updateMovieCommand.Handle() ;
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute]int id)
        {
            _deleteMovieCommand.MovieId = id;
            _deleteMovieCommand.Handle();

            return Ok();
        }

    }
}
