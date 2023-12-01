using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PatikaRestfulApi.Entities.Models;
using System.Globalization;

namespace PatikaRestfulApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Bilgisayar", Price = 2000 },
            new Product { Id = 2, Name = "Televizyon", Price = 1000 },
            new Product { Id = 3, Name = "Tablet", Price = 400 },
        };

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_products);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneProductById([FromRoute(Name = "id")] int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet("list")]
        public IActionResult GetAllProductsByName([FromQuery] string name)
        {
            var Products = _products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).OrderBy(p => p.Name);

            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            return Ok(Products);    
        }

        [HttpPost]
        public IActionResult CreateOneProduct([FromBody] Product product)
        {
            if (product is null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _products.Add(product);

            return StatusCode(201, product);

        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneProduct([FromRoute(Name = "id")] int id, [FromBody] Product product)
        {
            if(id != product.Id)
            {
                return BadRequest();
            }

            var Product = _products.FirstOrDefault(p => p.Id == id);

            if (Product == null)
            {
                return NotFound(); 
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            Product.Name = product.Name;
            Product.Price = product.Price;

            return NoContent(); 
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneProduct([FromRoute(Name = "id")] int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();  
            }

            _products.Remove(product);

            return NoContent();  
        }

        [HttpPatch("{id:int}")]
        public IActionResult Patch([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Product> productPatch)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
           
            if (product == null)
            {
                return NotFound(); 
            }

            productPatch.ApplyTo(product, ModelState);
            
            TryValidateModel(product);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            return NoContent(); 
        }

       

    }
}
