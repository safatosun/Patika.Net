using AutoMapper;
using FluentAssertions;
using MovieStoreApp.Application.ActorOperations.Commands.CreateActor;
using MovieStoreApp.Application.CustomerOperations.Commands.CreateCustomer;
using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MovieStoreApp.TestSetup;

namespace UnitTests.MovieStoreApp.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateCustomerCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistCustomerEmailIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            //Arrange
            var customer = new Customer
            {
                Name = "WhenAlreadyExistActorNameAndSurnameIsGiven_InvalidOperationException",
                Surname = "ShouldBeReturn",
                Email = "error@gmail.com",
                Password ="123456"
            };

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            CreateCustomerCommand command = new CreateCustomerCommand(_dbContext, _mapper);

            command.Model = new CreateCustomerModelDto()
            {
                Name = "WhenAlreadyExistActorNameAndSurnameIsGiven_InvalidOperationException",
                Surname = "ShouldBeReturn",
                Email = "error@gmail.com",
                Password = "123456"
            };

            //Act && Assert

            FluentActions
                .Invoking(() => command.Handle())
                .Should()
                .Throw<InvalidOperationException>().And.Message.Should().Be("The Customer already exists.");

            //Doğrulama
        }

        [Fact]
        public void WhenValidInputAreGiven_Customer_ShouldBeCreated()
        {
            //arrange
            CreateCustomerCommand command = new CreateCustomerCommand(_dbContext, _mapper);
            CreateCustomerModelDto model = new CreateCustomerModelDto()
            {
                Name = "Name",
                Surname = "Function",
                Email = "deneme@gmail.com",
                Password = "123456"
            };

            command.Model = model;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert

            var actor = _dbContext.Customers.SingleOrDefault(a => a.Name == model.Name && a.Surname == model.Surname);

            actor.Should().NotBeNull();
            actor.Name.Should().Be(model.Name);
            actor.Surname.Should().Be(model.Surname);
        }
    }
}
