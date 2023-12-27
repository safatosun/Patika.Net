using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieStoreApp.Application.CustomerOperations.Commands.CreateCustomer;
using MovieStoreApp.Application.CustomerOperations.Commands.CreateToken;
using MovieStoreApp.Application.CustomerOperations.Commands.DeleteCustomer;
using MovieStoreApp.Application.CustomerOperations.Commands.RefreshToken;
using MovieStoreApp.Application.OrderOperations.Queries.GetOrderByCustomerId;
using MovieStoreApp.TokenOperations.Models;

namespace MovieStoreApp.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly CreateCustomerCommand _createCustomerCommand;
        private readonly DeleteCustomerCommand _deleteCustomerCommand;
        private readonly CreateTokenCommand _createTokenCommand;
        private readonly RefreshTokenCommand _refreshTokenCommand;
        private readonly GetOrderByCustomerIdQuery _getOrderByCustomerIdQuery;

        public CustomerController(CreateCustomerCommand createCustomerCommand, DeleteCustomerCommand deleteCustomerCommand, CreateTokenCommand createTokenCommand, RefreshTokenCommand refreshTokenCommand, GetOrderByCustomerIdQuery getOrderByCustomerIdQuery)
        {
            _createCustomerCommand = createCustomerCommand;
            _deleteCustomerCommand = deleteCustomerCommand;
            _createTokenCommand = createTokenCommand;
            _refreshTokenCommand = refreshTokenCommand;
            _getOrderByCustomerIdQuery = getOrderByCustomerIdQuery;
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateCustomerModelDto modelDto)
        {
            _createCustomerCommand.Model = modelDto;
            _createCustomerCommand.Handle();
            return StatusCode(201);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _deleteCustomerCommand.CustomerId= id;

            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            validator.ValidateAndThrow(_deleteCustomerCommand);

            _deleteCustomerCommand.Handle();
            return Ok();
        }

        [HttpGet("{id:int}/orders")]
        public IActionResult GetByCustomerId([FromRoute] int id)
        {
            _getOrderByCustomerIdQuery.CustomerId = id;

            var order = _getOrderByCustomerIdQuery.Handle();

            return Ok(order);

        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModelDto login)
        {
            _createTokenCommand.Model = login;

            var token = _createTokenCommand.Handle();
            return token;
        }

        [HttpGet("refresh")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            _refreshTokenCommand.RefreshToken = token;

            var resultToken = _refreshTokenCommand.Handle();

            return resultToken;
        }

    }
}
