using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MovieStoreApp.TestSetup
{
    public static class Directors
    {
        public static void AddDirectors(this MovieStoreDbContext context)
        {
            context.Directors.AddRange(
              new Director { Name = "Alfred", Surname = "Hitchcock" },
              new Director { Name = "Orson", Surname = "Welles" },
              new Director { Name = "John", Surname = "Ford" },
              new Director { Name = "Howard", Surname = "Hawks" }
             );
        }
    }
}
