using Microsoft.AspNetCore.JsonPatch;
using PatikaRestfulApi.Entities.DataTransferObject;
using PatikaRestfulApi.Entities.Models;

namespace PatikaRestfulApi.Services.Contracts
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        List<Product> GetByName(string name);
        Product Create(BookDtoForInsertion product);
        void Update(int id,BookDtoForUpdate product);
        void Delete(int id);
        void Patch(int id, JsonPatchDocument<BookDtoForUpdate> patchDoc);
    }
}
