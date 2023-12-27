using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MovieStoreApp.TestSetup
{
    public static class Actors
    {
        public static void AddActors(this MovieStoreDbContext context)
        {
            context.Actors.AddRange(
             new Actor {  Name = "Buddy", SurName = "Hackett" },
             new Actor {  Name = "Todd", SurName = "Haberkorn" },
             new Actor {  Name = "Bill", SurName = "Hader" },
             new Actor {  Name = "Lukas", SurName = "Haas" }
             );
        }
    }
}
