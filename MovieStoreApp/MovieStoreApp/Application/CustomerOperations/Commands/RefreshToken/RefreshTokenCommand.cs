using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;
using MovieStoreApp.TokenOperations;
using MovieStoreApp.TokenOperations.Models;

namespace MovieStoreApp.Application.CustomerOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {

        public string RefreshToken { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IConfiguration _config;

        public RefreshTokenCommand(IMovieStoreDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        public Token Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(user => user.RefreshToken == RefreshToken && user.RefreshTokenExpireDate > DateTime.Now);

            if (customer is null)
            {
                throw new InvalidOperationException("Valid Refresh token could not found.");
            }

            TokenHandler handler = new TokenHandler(_config);
            Token token = handler.CreateAccessToken(customer);

            customer.RefreshToken = token.RefreshToken;
            customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
            _dbContext.SaveChanges();
            return token;
        }


    }
}
