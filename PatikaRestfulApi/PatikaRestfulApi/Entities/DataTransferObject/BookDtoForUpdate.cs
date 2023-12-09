using System.ComponentModel.DataAnnotations;

namespace PatikaRestfulApi.Entities.DataTransferObject
{
    public record BookDtoForUpdate
    {

        [Required(ErrorMessage = "Name is a required field.")]
        [MinLength(2, ErrorMessage = "Name must consist of a at least 2 characters")]
        [MaxLength(40, ErrorMessage = "Name must consist of a at maximum 40 characters")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Price is a required field.")]
        [Range(10, 10000)]
        public decimal Price { get; init; }
    }
}
