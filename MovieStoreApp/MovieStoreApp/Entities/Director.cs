using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreApp.Entities
{
    public class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public  List<Movie> Movies { get; set; }
    }
}
