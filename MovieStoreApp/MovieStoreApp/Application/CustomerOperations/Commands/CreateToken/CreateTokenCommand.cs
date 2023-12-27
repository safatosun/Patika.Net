using MovieStoreApp.DBOperations;
using MovieStoreApp.TokenOperations;
using MovieStoreApp.TokenOperations.Models;

namespace MovieStoreApp.Application.CustomerOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModelDto Model { get; set; }
        
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IConfiguration _config;

        public CreateTokenCommand(IMovieStoreDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        public Token Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(user => user.Email == Model.Email && user.Password == Model.Password);

            if (customer is null)
            {
                throw new InvalidOperationException("The Customer could not found.");
            }

            TokenHandler handler = new TokenHandler(_config);
            Token token = handler.CreateAccessToken(customer);

            customer.RefreshToken = token.RefreshToken;
            customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
            _dbContext.SaveChanges();
            return token;
        }

    }

    public class CreateTokenModelDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
