using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreApp.Entities
{
    public class FavoriteGenre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FavoriteGenreId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
       
    }
}
