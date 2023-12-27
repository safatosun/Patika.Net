using AutoMapper;
using FluentAssertions;
using MovieStoreApp.Application.ActorOperations.Commands.CreateActor;
using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MovieStoreApp.TestSetup;

namespace UnitTests.MovieStoreApp.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandTests : IClassFixture<CommonTestFixture>
    {

        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateActorCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistActorNameAndSurnameIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            //Arrange
            var actor = new Actor
            {
                Name = "WhenAlreadyExistActorNameAndSurnameIsGiven_InvalidOperationException",
                SurName = "ShouldBeReturn"

            };

            _dbContext.Actors.Add(actor);
            _dbContext.SaveChanges();

            CreateActorCommand command = new CreateActorCommand(_dbContext, _mapper);

            command.Model = new CreateActorModelDto()
            {
                Name = "WhenAlreadyExistActorNameAndSurnameIsGiven_InvalidOperationException",
                SurName = "ShouldBeReturn"
            };

            //Act && Assert

            FluentActions
                .Invoking(() => command.Handle())
                .Should()
                .Throw<InvalidOperationException>().And.Message.Should().Be("Actor already exists.");

            //Doğrulama
        }

        [Fact]
        public void WhenValidInputAreGiven_Actor_ShouldBeCreated()
        {
            //arrange
            CreateActorCommand command = new CreateActorCommand(_dbContext, _mapper);
            CreateActorModelDto model = new CreateActorModelDto()
            {
                Name = "NewName",
                SurName = "NewSurname"
            };

            command.Model = model;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert

            var actor = _dbContext.Actors.SingleOrDefault(a => a.Name == model.Name && a.SurName == model.SurName);

            actor.Should().NotBeNull();
            actor.Name.Should().Be(model.Name);
            actor.SurName.Should().Be(model.SurName);
        }

    }

}
