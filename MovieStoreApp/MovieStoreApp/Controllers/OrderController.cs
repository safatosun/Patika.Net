using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApp.Application.OrderOperations.Commands.CreateOrder;
using MovieStoreApp.Application.OrderOperations.Queries.GetOrderByCustomerId;
using MovieStoreApp.Application.OrderOperations.Queries.GetOrderById;

namespace MovieStoreApp.Controllers
{
    [Authorize]
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly GetOrderByIdQuery _getOrderByIdQuery;
        private readonly CreateOrderCommand _createOrderCommand;
        private readonly GetOrderByCustomerIdQuery _getOrderByCustomerIdQuery;

        public OrderController(GetOrderByIdQuery getOrderByIdQuery, CreateOrderCommand createOrderCommand, GetOrderByCustomerIdQuery getOrderByCustomerIdQuery)
        {
            _getOrderByIdQuery = getOrderByIdQuery;
            _createOrderCommand = createOrderCommand;
            _getOrderByCustomerIdQuery = getOrderByCustomerIdQuery;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute]int id)
        {
            _getOrderByIdQuery.OrderId = id;
            
            GetOrderByIdQueryValidator validator = new GetOrderByIdQueryValidator();
            
            validator.ValidateAndThrow(_getOrderByIdQuery);

            var order = _getOrderByIdQuery.Handle();
            
            return Ok(order);

        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderModelDto modelDto)
        {
            _createOrderCommand.Model = modelDto;
            _createOrderCommand.Handle();
            
            return StatusCode(201);
        }

    }
}
