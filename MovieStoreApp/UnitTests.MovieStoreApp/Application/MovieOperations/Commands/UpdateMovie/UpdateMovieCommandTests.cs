using AutoMapper;
using FluentAssertions;
using MovieStoreApp.Application.DirectorOperations.Commands.UpdateDirector;
using MovieStoreApp.Application.MovieOperations.Commands.UpdateMovie;
using MovieStoreApp.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MovieStoreApp.TestSetup;

namespace UnitTests.MovieStoreApp.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandTests : IClassFixture<CommonTestFixture>
    {

        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateMovieCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNonValidIdIsGiven_Movie_ThrowsInvalidOperationException()
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_dbContext, _mapper);


            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Movie could not find.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Movie_ShouldBeUpdated()
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_dbContext, _mapper);

            UpdateMovieModelDto model = new UpdateMovieModelDto()
            {
                Name = "Hobbits",
                PublishDate = DateTime.Now,
                GenreId = 2,
                Price = 30,
                IsActive = true
            };

            command.MovieId = 1;
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var director = _dbContext.Movies.SingleOrDefault(movie => movie.Id == command.MovieId);
            director.Should().NotBeNull();
            director.Name.Should().Be(model.Name);
            
        }

    }
}
