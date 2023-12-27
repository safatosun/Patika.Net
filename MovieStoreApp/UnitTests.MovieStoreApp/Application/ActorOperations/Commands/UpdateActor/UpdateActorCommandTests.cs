using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MovieStoreApp.Application.ActorOperations.Commands.UpdateActor;
using MovieStoreApp.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MovieStoreApp.TestSetup;

namespace UnitTests.MovieStoreApp.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateActorCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNonValidIdIsGiven_Actor_ThrowsInvalidOperationException()
        {
            UpdateActorCommand command = new UpdateActorCommand(_dbContext, _mapper);


            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Actor could not find.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Actor_ShouldBeUpdated()
        {
            UpdateActorCommand command = new UpdateActorCommand(_dbContext, _mapper);

            UpdateActorModelDto model = new UpdateActorModelDto() { Name = "Hobbits", Surname = "Ali" };

            command.ActorId = 1;
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var actor = _dbContext.Actors.SingleOrDefault(actor => actor.Id == command.ActorId);
            actor.Should().NotBeNull();
            actor.Name.Should().Be(model.Name);
            actor.SurName.Should().Be(model.Surname);
        }

    }
}
