using System.ComponentModel.DataAnnotations;

namespace PatikaRestfulApi.Entities.Models
{
    public class Product
    {

        [Required(ErrorMessage = "Id is a required field.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is a required field.")]
        [MinLength(2, ErrorMessage = "Name must consist of a at least 2 characters")]
        [MaxLength(40, ErrorMessage = "Name must consist of a at maximum 40 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is a required field.")]
        [Range(10, 10000)]
        public decimal Price { get; set; }

    }
}
