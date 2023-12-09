using PatikaRestfulApi.Entities.Models;
using PatikaRestfulApi.Repositories.Contracts;

namespace PatikaRestfulApi.Repositories.EFCore
{
    public class UserRepository : IUserRepository
    {
        private readonly RepositoryDbContext _repositoryDbContext;

        public UserRepository(RepositoryDbContext repositoryDbContext)
        {
            _repositoryDbContext = repositoryDbContext;
        }

        public User GetByNameAndPassword(string name, string password)
        {
           return _repositoryDbContext.Users.Where(user => user.Name.Equals(name) && user.Password.Equals(password)).SingleOrDefault();
        }

    }


}
