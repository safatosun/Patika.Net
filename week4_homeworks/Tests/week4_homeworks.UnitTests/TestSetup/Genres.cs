using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week4_homeworks.DBOperations;
using week4_homeworks.Entities;

namespace week4_homeworks.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
           
            context.Genres.AddRange(
                new Genre
                {
                    Name = "Personel Growth",
                },
                new Genre
                {
                    Name = "Science Fiction"
                },
                new Genre
                {
                    Name = "Romance"
                }
            );
        }
    }
}
