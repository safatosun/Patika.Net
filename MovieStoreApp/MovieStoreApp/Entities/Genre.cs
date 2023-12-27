using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreApp.Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

