using Microsoft.AspNetCore.JsonPatch;
using PatikaRestfulApi.Entities.DataTransferObject;
using PatikaRestfulApi.Entities.Models;
using PatikaRestfulApi.Repositories.Contracts;
using PatikaRestfulApi.Services.Contracts;

namespace PatikaRestfulApi.Services
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
       
        }

        public List<Product> GetAll()
        {
            var entities = _productRepository.GetAll();
            return entities;
        }

        public Product GetById(int id)
        {
            var entity = GetByIdAndCheckExits(id);
            return entity;
        }


        public List<Product> GetByName(string name)
        {
            var entities = _productRepository.GetAll().Where(x => x.Name.ToLower() == name.ToLower()).ToList();
            return entities;
        }

        public Product Create(BookDtoForInsertion product)
        {

            if (product is null)
                throw new Exception($"No product object was found in reqeust body.");

            Product entity = new Product();

            entity.Name = product.Name; 
            entity.Price= product.Price;    

            _productRepository.Create(entity);
            return entity;
        }
        public void Update(int id, BookDtoForUpdate product)
        {

            var entity = GetByIdAndCheckExits(id);

            entity.Name=product.Name;   
            entity.Price=product.Price; 

            _productRepository.Update(entity); 
        }

        public void Delete(int id)
        {

            var entity = GetByIdAndCheckExits(id);

            _productRepository.Delete(entity);

        }

        public void Patch(int id, JsonPatchDocument<BookDtoForUpdate> patchDoc)
        {
            var entity = GetByIdAndCheckExits(id);

            BookDtoForUpdate patchEntity = new BookDtoForUpdate()
            {
               Name=entity.Name,
               Price=entity.Price,  
            };

            patchDoc.ApplyTo(patchEntity);

            entity.Name=patchEntity.Name;
            entity.Price = patchEntity.Price;

            _productRepository.Update(entity);

        }

        private Product GetByIdAndCheckExits(int id)
        {
            var entity=_productRepository.GetById(id);

            if (entity is null)
                throw new Exception($"No product object with ID number {id} was found.");

            return entity;
        }

    }
}
