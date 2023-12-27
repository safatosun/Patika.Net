using week4_homeworks.DBOperations;
using week4_homeworks.TokenOperations;
using week4_homeworks.TokenOperations.Models;

namespace week4_homeworks.Applications.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {

        public string RefreshToken { get; set; }

        private readonly IBookStoreDbContext _dbContext;
        private readonly IConfiguration _config;

        public RefreshTokenCommand(IBookStoreDbContext dbContext,IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        public Token Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(user => user.RefreshToken== RefreshToken && user.RefreshTokenExpireDate > DateTime.Now);

            if (user is null)
            {
                throw new InvalidOperationException("Valid Refresh token could not found.");
            }

            TokenHandler handler = new TokenHandler(_config);
            Token token = handler.CreateAccessToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
            _dbContext.SaveChanges();
            return token;
        }


    }
}
