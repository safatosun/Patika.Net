using PatikaRestfulApi.Entities.Models;

namespace PatikaRestfulApi.Repositories.Contracts
{
    public interface IUserRepository
    {
        User GetByNameAndPassword(string name,string password);

    }
}
