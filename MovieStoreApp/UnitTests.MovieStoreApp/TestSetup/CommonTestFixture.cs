using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreApp.Common;
using MovieStoreApp.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MovieStoreApp.TestSetup
{
    public class CommonTestFixture
    {
        public MovieStoreDbContext Context { get; set; }

        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<MovieStoreDbContext>().UseInMemoryDatabase(databaseName: "MovieStoreTestDB").Options;
            Context = new MovieStoreDbContext(options);

            Context.Database.EnsureCreated();

            Context.AddActors();
            Context.AddCustomers();            
            Context.AddDirectors();
            Context.AddGenres();
            Context.AddMovies();
            Context.AddOrders();

            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();

        }

    }
}
