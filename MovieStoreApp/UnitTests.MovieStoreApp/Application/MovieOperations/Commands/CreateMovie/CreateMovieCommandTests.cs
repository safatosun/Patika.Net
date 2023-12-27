using AutoMapper;
using FluentAssertions;
using MovieStoreApp.Application.DirectorOperations.Commands.CreateDirector;
using MovieStoreApp.Application.MovieOperations.Commands.CreateMovie;
using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MovieStoreApp.TestSetup;

namespace UnitTests.MovieStoreApp.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateMovieCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistMovieNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            //Arrange
            var movie = new Movie
            {
                Name = "WhenAlreadyExistMovieNameAndSurnameIsGiven",
                GenreId = 1,
                DirectorId = 1,
                Price = 10,
                PublishDate = DateTime.Now, 
            };

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            CreateMovieCommand command = new CreateMovieCommand(_dbContext, _mapper);

            command.Model = new CreateMovieModelDto()
            {
                Name = "WhenAlreadyExistMovieNameAndSurnameIsGiven",
                GenreId = 1,
                DirectorId = 1,
                ActorId = 1,
                Price = 10,
                PublishDate = DateTime.Now,
            };

            //Act && Assert

            FluentActions
                .Invoking(() => command.Handle())
                .Should()
                .Throw<InvalidOperationException>().And.Message.Should().Be("Movie Already Exists.");

            //Doğrulama
        }

        [Fact]
        public void WhenValidInputAreGiven_Actor_ShouldBeCreated()
        {
            //arrange
            CreateMovieCommand command = new CreateMovieCommand(_dbContext, _mapper);
            CreateMovieModelDto model = new CreateMovieModelDto()
            {
                Name = "newMovie",
                GenreId = 1,
                DirectorId = 1,
                ActorId = 2,
                Price = 10,
                PublishDate = DateTime.Now,
            };

            command.Model = model;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert

            var movie = _dbContext.Movies.SingleOrDefault(a => a.Name == model.Name);

            movie.Should().NotBeNull();
            movie.Name.Should().Be(model.Name);
        }

    }

}
