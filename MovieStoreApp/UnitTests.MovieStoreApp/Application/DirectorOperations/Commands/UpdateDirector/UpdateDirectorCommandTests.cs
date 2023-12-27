using AutoMapper;
using FluentAssertions;
using MovieStoreApp.Application.ActorOperations.Commands.UpdateActor;
using MovieStoreApp.Application.DirectorOperations.Commands.UpdateDirector;
using MovieStoreApp.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MovieStoreApp.TestSetup;

namespace UnitTests.MovieStoreApp.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateDirectorCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNonValidIdIsGiven_Actor_ThrowsInvalidOperationException()
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_dbContext, _mapper);


            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("The Director could not find.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Actor_ShouldBeUpdated()
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_dbContext, _mapper);

            UpdateDirectorModelDto model = new UpdateDirectorModelDto() { Name = "Hobbits", Surname = "Ali" };

            command.DirectorId = 1;
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var director = _dbContext.Directors.SingleOrDefault(director => director.Id == command.DirectorId);
            director.Should().NotBeNull();
            director.Name.Should().Be(model.Name);
            director.Surname.Should().Be(model.Surname);
        }

    }
}
