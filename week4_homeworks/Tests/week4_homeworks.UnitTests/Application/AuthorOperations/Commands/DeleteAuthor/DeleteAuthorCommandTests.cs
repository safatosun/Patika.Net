using FluentAssertions;
using week4_homeworks.Applications.AuthorOperations.Commands.DeleteAuthor;
using week4_homeworks.DBOperations;
using week4_homeworks.Entities;
using week4_homeworks.UnitTests.TestSetup;
using Xunit;

namespace week4_homeworks.UnitTests.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAuthorIdIsNotExist_InvalidOperationException_ShouldBeReturn()
        {

            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId= 20;
            FluentActions
                .Invoking(() => command.Handle())
                .Should()
                .Throw<InvalidOperationException>().And.Message.Should().Be("Author could not found.");

        }

        [Fact]
        public void WhenAuthorIdIsExist_Author_ShouldBeDeleted()
        {
            
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            
            var author = new Author
            {
                Name = "WhenAuthorIdIsExist",
                Surname = "ShouldBeDeleted",
                Birthdate = new DateTime(2010, 06 ,12)
            };

            _context.Authors.Add(author);
            _context.SaveChanges();
            
            command.AuthorId = author.Id;

            FluentActions.Invoking(() => command.Handle()).Invoke();
            
            _context.Authors.Any(x => x.Id == command.AuthorId).Should().BeFalse();
        }
    }
}