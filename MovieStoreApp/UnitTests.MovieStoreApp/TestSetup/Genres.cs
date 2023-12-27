using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MovieStoreApp.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this MovieStoreDbContext context)
        {
            context.Genres.AddRange(
              new Genre { Name = "Action" },
              new Genre { Name = "Comedy" },
              new Genre { Name = "Drama" },
              new Genre { Name = "Fantasy" }
             );
        }
    }
}