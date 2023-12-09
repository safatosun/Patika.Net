using Microsoft.AspNetCore.JsonPatch;
using PatikaRestfulApi.Entities.Models;
using PatikaRestfulApi.Repositories.Contracts;

namespace PatikaRestfulApi.Repositories.EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly RepositoryDbContext _repositoryDbContext;

        public ProductRepository(RepositoryDbContext repositoryDbContext)
        {
            _repositoryDbContext = repositoryDbContext;
        }

        public List<Product> GetAll()
        {
            return _repositoryDbContext.Products.ToList();  
        }

        public Product GetById(int id)
        {
            return _repositoryDbContext.Products.Where(p=> p.Id.Equals(id)).SingleOrDefault();
        }


        public void Create(Product product)
        {
             _repositoryDbContext.Products.Add(product);
             _repositoryDbContext.SaveChanges();
        }

        public void Update(Product product)
        {
            _repositoryDbContext.Products.Update(product);
            _repositoryDbContext.SaveChanges();
        }

        public void Delete(Product product)
        {
            _repositoryDbContext.Products.Remove(product);
            _repositoryDbContext.SaveChanges();
        }

    }
}
