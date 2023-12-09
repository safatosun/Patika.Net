using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PatikaRestfulApi.Controllers.Attributes;
using PatikaRestfulApi.Entities.DataTransferObject;
using PatikaRestfulApi.Entities.Models;
using PatikaRestfulApi.Repositories.Contracts;
using PatikaRestfulApi.Repositories.EFCore;
using PatikaRestfulApi.Services.Contracts;
using System.Globalization;

namespace PatikaRestfulApi.Controllers
{
    [ApiController]
    [Route("api/products")]    
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Login")]
        [ServiceFilter(typeof(FakeUserAttribute))]
        public IActionResult Login([FromQuery] string name, [FromQuery] string password)
        {
            
            return Ok("Giriş başarılı!");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _productService.GetAll();
            return Ok(entities);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute(Name = "id")] int id)
        {
            var entity = _productService.GetById(id);

            return Ok(entity);
        }

        [HttpGet("list")]
        public IActionResult GetByName([FromQuery] string name)
        {
            var entities = _productService.GetByName(name);
            return Ok(entities);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookDtoForInsertion product)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = _productService.Create(product);

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);

        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate product)
        {             
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _productService.Update(id,product); 
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _productService.Delete(id);
            return NoContent();  
        }

        [HttpPatch("{id:int}")]
        public IActionResult Patch([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<BookDtoForUpdate> patchDoc)
        {
            _productService.Patch(id, patchDoc);
            return Ok();
        }
        
    }

}
