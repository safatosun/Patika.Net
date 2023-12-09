using Microsoft.AspNetCore.JsonPatch;
using PatikaRestfulApi.Entities.Models;

namespace PatikaRestfulApi.Repositories.Contracts
{
    public interface IProductRepository
    {

        List<Product> GetAll();
        Product GetById(int id);
        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);

    }
}
