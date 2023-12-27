using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApp.Application.ActorOperations.Commands.CreateActor;
using MovieStoreApp.Application.ActorOperations.Commands.DeleteActor;
using MovieStoreApp.Application.ActorOperations.Commands.UpdateActor;
using MovieStoreApp.Application.ActorOperations.Queries.GetActors;
using MovieStoreApp.Application.CustomerOperations.Commands.DeleteCustomer;

namespace MovieStoreApp.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorController : ControllerBase
    {

        private readonly GetActorsQuery _getActorsQuery;
        private readonly CreateActorCommand _createActorCommand;
        private readonly UpdateActorCommand _updateActorCommand;
        private readonly DeleteActorCommand _deleteActorCommand;

        public ActorController(GetActorsQuery getActorsQuery, CreateActorCommand createActorCommand, UpdateActorCommand updateActorCommand, DeleteActorCommand deleteActorCommand)
        {
            _getActorsQuery = getActorsQuery;
            _createActorCommand = createActorCommand;
            _updateActorCommand = updateActorCommand;
            _deleteActorCommand = deleteActorCommand;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var actors = _getActorsQuery.Handle();
            return Ok(actors);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateActorModelDto modelDto)
        { 
            _createActorCommand.Model = modelDto;
            _createActorCommand.Handle();

            return StatusCode(201);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateActorModelDto modelDto)
        {
            _updateActorCommand.ActorId = id;
            _updateActorCommand.Model = modelDto;

            _updateActorCommand.Handle();

            return Ok();

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute]int id)
        {
            _deleteActorCommand.ActorId = id;

            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            validator.ValidateAndThrow(_deleteActorCommand);

            _deleteActorCommand.Handle();
            
            return Ok();

        }


    }
}
