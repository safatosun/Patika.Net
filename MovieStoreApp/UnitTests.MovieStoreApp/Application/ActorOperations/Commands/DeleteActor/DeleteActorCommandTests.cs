using AutoMapper;
using FluentAssertions;
using MovieStoreApp.Application.ActorOperations.Commands.DeleteActor;
using MovieStoreApp.Application.ActorOperations.Commands.UpdateActor;
using MovieStoreApp.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MovieStoreApp.TestSetup;

namespace UnitTests.MovieStoreApp.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteActorCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenActorIsNotFound_InvalidOperationException_ThrowsInvalidOperationException()
        {
            DeleteActorCommand command = new DeleteActorCommand(_dbContext);

            command.ActorId = 0;

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("The actor could not find.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Actor_ShouldBeDeleted()
        {
            DeleteActorCommand command = new DeleteActorCommand(_dbContext);

            command.ActorId = 4;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var book = _dbContext.Actors.SingleOrDefault(x => x.Id == 4);
            book.Should().BeNull();
        }

    }
}
