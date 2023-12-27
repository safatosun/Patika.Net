using Microsoft.EntityFrameworkCore;
using MovieStoreApp.Entities;

namespace MovieStoreApp.DBOperations
{
    public interface IMovieStoreDbContext
    {
        DbSet<Actor> Actors { get; set; }
        DbSet<ActorMovie> ActorMovie { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Director> Directors { get; set; }
        DbSet<FavoriteGenre> FavoriteGenre { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<Order> Orders { get; set; }

        int SaveChanges();
    }
}
