using AutoMapper;
using FluentAssertions;
using MovieStoreApp.Application.ActorOperations.Commands.CreateActor;
using MovieStoreApp.Application.DirectorOperations.Commands.CreateDirector;
using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MovieStoreApp.TestSetup;

namespace UnitTests.MovieStoreApp.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateDirectorCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistDirectorNameAndSurnameIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            //Arrange
            var director = new Director
            {
                Name = "WhenAlreadyExistDirectorNameAndSurnameIsGiven",
                Surname = "ShouldBeReturn"

            };

            _dbContext.Directors.Add(director);
            _dbContext.SaveChanges();

            CreateDirectorCommand command = new CreateDirectorCommand(_dbContext, _mapper);

            command.modelDto = new CreateDirectorModelDto()
            {
                Name = "WhenAlreadyExistDirectorNameAndSurnameIsGiven",
                Surname = "ShouldBeReturn"
            };

            //Act && Assert

            FluentActions
                .Invoking(() => command.Handle())
                .Should()
                .Throw<InvalidOperationException>().And.Message.Should().Be("The director already exists.");

            //Doğrulama
        }

        [Fact]
        public void WhenValidInputAreGiven_Actor_ShouldBeCreated()
        {
            //arrange
            CreateDirectorCommand command = new CreateDirectorCommand(_dbContext, _mapper);
            CreateDirectorModelDto model = new CreateDirectorModelDto()
            {
                Name = "NewName",
                Surname = "NewSurname"
            };

            command.modelDto = model;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert

            var director = _dbContext.Directors.SingleOrDefault(a => a.Name == model.Name && a.Surname == model.Surname);

            director.Should().NotBeNull();
            director.Name.Should().Be(model.Name);
            director.Surname.Should().Be(model.Surname);
        }

    }
}
