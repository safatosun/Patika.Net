using AutoMapper;
using FluentAssertions;
using week4_homeworks.Applications.AuthorOperations.Commands.UpdateAuthor;
using week4_homeworks.DBOperations;
using week4_homeworks.Entities;
using week4_homeworks.UnitTests.TestSetup;
using Xunit;

namespace week4_homeworks.UnitTests.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotExistAuthorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            UpdateAuthorCommand command = new UpdateAuthorCommand(_context, null);
            command.AuthorId = 0;
           

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Author could not found.");
        }


        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeUpdated()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context, _mapper);
            var author = new Author
            {
                Name = "WhenValidInputsAreGiven",
                Surname = "ShouldBeUpdated",
                Birthdate = new DateTime(2000, 04, 06)
            };
           
            _context.Authors.Add(author);
            _context.SaveChanges();
            
            command.AuthorId = author.Id;
            command.Model = new UpdateAuthorModel
            {
                Name = "WhenValidInputsAreGivenChanged",
                Surname = "ShouldBeUpdatedChanged",
                Birthdate = new DateTime(2002, 04, 16),
            };

            FluentActions.Invoking(() => command.Handle()).Invoke();        

            author = _context.Authors.SingleOrDefault(x => x.Id == command.AuthorId);
          
            author.Should().NotBeNull();
            author.Name.Should().Be(command.Model.Name);
            author.Surname.Should().Be(command.Model.Surname);
            author.Birthdate.Should().Be(command.Model.Birthdate);
        }

    }
}