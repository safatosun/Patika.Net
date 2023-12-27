using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week4_homeworks.Applications.BookOperations.Commands.CreateBook;
using week4_homeworks.DBOperations;
using week4_homeworks.Entities;
using week4_homeworks.UnitTests.TestSetup;

namespace week4_homeworks.UnitTests.Application.BookOperations.Command.CreateBook
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            //Arrange

            var book = new Book
            {
                Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn",
                PageCount = 100,
                PublishDate = new DateTime(1990,01,10),
                GenreId=1
            };

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_dbContext,_mapper);
            command.Model = new CreateBookModel() { Title=book.Title };

            //Act && Assert

            FluentActions
                .Invoking(() => command.Handle())
                .Should()
                .Throw<InvalidOperationException>().And.Message.Should().Be("The book already exists");

            //Doğrulama
        }

        [Fact]
        public void WhenValidInputAreGiven_Book_ShouldBeCreated()
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(_dbContext, _mapper);
            CreateBookModel model = new CreateBookModel() { Title = "Hobbit", PageCount = 100, PublishDate = DateTime.Now.Date.AddYears(-10), GenreId = 1 };

            command.Model = model;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            
            var book = _dbContext.Books.SingleOrDefault(b=>b.Title==model.Title);
            book.Should().NotBeNull();  
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            book.GenreId.Should().Be(model.GenreId);
        }

    }
}
