using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MovieStoreApp.TestSetup
{
    public static class Movies
    {
        public static void AddMovies(this MovieStoreDbContext context)
        {
            context.Movies.AddRange(

               new Movie
               {
                   Name = "The Godfather",
                   GenreId = 1,
                   DirectorId = 1,
                   Price = 30,
                   PublishDate = new DateTime(1972, 1, 1),
                   IsActive = true,
               },
                new Movie
                {
                    Name = "The Godfather 2",
                    GenreId = 2,
                    DirectorId = 2,
                    Price = 30,
                    PublishDate = new DateTime(1974, 1, 1),
                    IsActive = true,
                },
                new Movie
                {
                    Name = "Citizen Kane",
                    GenreId = 3,
                    DirectorId = 3,
                    Price = 20,
                    PublishDate = new DateTime(1941, 1, 1),
                    IsActive = true,
                },
                new Movie
                {
                    Name = "La Dolce Vita",
                    GenreId = 4,
                    DirectorId = 1,
                    Price = 10,
                    PublishDate = new DateTime(1960, 1, 1),
                    IsActive = true,
                }
             );
        }

    }
}
