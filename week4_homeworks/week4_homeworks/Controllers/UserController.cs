using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using week4_homeworks.Applications.UserOperations.Commands.CreateToken;
using week4_homeworks.Applications.UserOperations.Commands.CreateUser;
using week4_homeworks.Applications.UserOperations.Commands.RefreshToken;
using week4_homeworks.DBOperations;
using week4_homeworks.TokenOperations.Models;

namespace week4_homeworks.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserController(IBookStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateUserModel newUser)  
        {
            CreateUserCommand command = new CreateUserCommand(_dbContext,_mapper);
            command.Model = newUser;
            command.Handle();

            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login) 
        {            
            CreateTokenCommand command = new CreateTokenCommand(_dbContext,_mapper,_configuration);
            command.Model = login;

            var token = command.Handle();

            return token;
        }

        [HttpGet("refresh")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_dbContext,_configuration);

            command.RefreshToken = token;

            var resultToken = command.Handle();

            return resultToken;
        }

    }
}
