using AutoMapper;
using week4_homeworks.DBOperations;
using week4_homeworks.TokenOperations;
using week4_homeworks.TokenOperations.Models;

namespace week4_homeworks.Applications.UserOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {

        public CreateTokenModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
    
        public CreateTokenCommand(IBookStoreDbContext dbContext, IMapper mapper, IConfiguration config)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _config = config;
        }

        public Token Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(user => user.Email == Model.Email && user.Password == Model.Password);

            if (user is null)
            {
                throw new InvalidOperationException("The User could not found.");
            }

            TokenHandler handler = new TokenHandler(_config);
            Token token= handler.CreateAccessToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
            _dbContext.SaveChanges();
            return token;
        }


    }

    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }


}

