﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week4_homeworks.Common;
using week4_homeworks.DBOperations;

namespace week4_homeworks.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public BookStoreDbContext Context { get; set; }

        public IMapper Mapper { get; set; }

        public CommonTestFixture() 
        {
            var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName:"BookStoreTestDB").Options;
            Context = new BookStoreDbContext(options);
            
            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddGenres();
            Context.AddAuthors();
            Context.SaveChanges(); 
            
            Mapper = new MapperConfiguration(cfg=> cfg.AddProfile<MappingProfile>()).CreateMapper();

        }

    }
}
