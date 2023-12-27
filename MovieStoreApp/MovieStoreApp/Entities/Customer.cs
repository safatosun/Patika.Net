using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreApp.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
        public  List<Order> Orders { get; set; }
        public  List<FavoriteGenre> FavoriteGenres { get; set; }
    }
}
