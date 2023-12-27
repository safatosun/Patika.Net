
using FluentAssertions;
using week4_homeworks.Applications.BookOperations.Commands.DeleteBook;
using week4_homeworks.DBOperations;
using week4_homeworks.Entities;
using week4_homeworks.UnitTests.TestSetup;
using Xunit;
namespace week4_homeworks.UnitTests.Application.BookOperations.Command.CreateBook
{
	public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _dbContext;

		public DeleteBookCommandTests(CommonTestFixture testFixture)
		{
            _dbContext = testFixture.Context;
		}

		[Fact]
		public void WhenBookIsNotFound_InvalidOperationException_ThrowsInvalidOperationException()
		{
			DeleteBookCommand command = new DeleteBookCommand(_dbContext);

			command.BookId = 0;

			FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book not found.");
		}

		[Fact]
		public void WhenValidInputAreGiven_Book_ShouldBeDeleted()
		{
			DeleteBookCommand command = new DeleteBookCommand(_dbContext);

			command.BookId = 1;

			FluentActions.Invoking(() => command.Handle()).Invoke();

            var book = _dbContext.Books.SingleOrDefault(x => x.Id == 1);
            book.Should().BeNull();
        }
	}
}