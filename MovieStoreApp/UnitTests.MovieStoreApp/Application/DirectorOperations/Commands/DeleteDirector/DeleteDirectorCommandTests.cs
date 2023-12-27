using AutoMapper;
using FluentAssertions;
using MovieStoreApp.Application.ActorOperations.Commands.DeleteActor;
using MovieStoreApp.Application.DirectorOperations.Commands.DeleteDirector;
using MovieStoreApp.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MovieStoreApp.TestSetup;

namespace UnitTests.MovieStoreApp.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteDirectorCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenDirectorIsNotFound_InvalidOperationException_ThrowsInvalidOperationException()
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_dbContext);

            command.DirectorId = 0;

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Director could not find.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Director_ShouldBeDeleted()
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_dbContext);

            command.DirectorId = 5;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var director = _dbContext.Directors.SingleOrDefault(x => x.Id == 5);
            director.Should().BeNull();
        }
    }
}
