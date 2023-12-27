using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApp.Application.DirectorOperations.Commands.CreateDirector;
using MovieStoreApp.Application.DirectorOperations.Commands.DeleteDirector;
using MovieStoreApp.Application.DirectorOperations.Commands.UpdateDirector;
using MovieStoreApp.Application.DirectorOperations.Queries.GetDirectors;

namespace MovieStoreApp.Controllers
{
    [ApiController]
    [Route("api/directors")]
    public class DirectorController : ControllerBase
    {
       
        private readonly GetDirectorsQuery _getDirectorsQuery;
        private readonly CreateDirectorCommand _createDirectorCommand;
        private readonly UpdateDirectorCommand _updateDirectorCommand;
        private readonly DeleteDirectorCommand _deleteDirectorCommand;

        public DirectorController(GetDirectorsQuery getDirectorsQuery, CreateDirectorCommand createDirectorCommand, UpdateDirectorCommand updateDirectorCommand, DeleteDirectorCommand deleteDirectorCommand)
        {
            _getDirectorsQuery = getDirectorsQuery;
            _createDirectorCommand = createDirectorCommand;
            _updateDirectorCommand = updateDirectorCommand;
            _deleteDirectorCommand = deleteDirectorCommand;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var directors = _getDirectorsQuery.Handle();
            
            return Ok(directors);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateDirectorModelDto modelDto)
        {
            _createDirectorCommand.modelDto = modelDto;
            _createDirectorCommand.Handle();
            return StatusCode(201);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute]int id, [FromBody] UpdateDirectorModelDto modelDto) 
        {
            _updateDirectorCommand.DirectorId = id; 
            _updateDirectorCommand.Model=modelDto;
            _updateDirectorCommand.Handle();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute]int id)
        {
            _deleteDirectorCommand.DirectorId=id;
            
            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();

            validator.ValidateAndThrow(_deleteDirectorCommand);

            _deleteDirectorCommand.Handle();
            
            return Ok();

        }

    }
}
