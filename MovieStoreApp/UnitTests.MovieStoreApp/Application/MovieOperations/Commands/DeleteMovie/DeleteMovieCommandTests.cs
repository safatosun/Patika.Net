using AutoMapper;
using FluentAssertions;
using MovieStoreApp.Application.DirectorOperations.Commands.DeleteDirector;
using MovieStoreApp.Application.MovieOperations.Commands.DeleteMovie;
using MovieStoreApp.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MovieStoreApp.TestSetup;

namespace UnitTests.MovieStoreApp.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteMovieCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenMovieIsNotFound_InvalidOperationException_ThrowsInvalidOperationException()
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_dbContext);

            command.MovieId = 0;

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("The Movie could not find.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Movie_ShouldBeDeleted()
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_dbContext);

            command.MovieId = 1;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == 1);
            movie.IsActive.Should().BeFalse();
        }
    }
}
