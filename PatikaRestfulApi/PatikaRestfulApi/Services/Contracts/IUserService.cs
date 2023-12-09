using PatikaRestfulApi.Entities.Models;

namespace PatikaRestfulApi.Services.Contracts
{
    public interface IUserService
    {
        User Login(string name, string password);

    }
}
