using AutoMapper;
using FluentAssertions;
using week4_homeworks.Applications.BookOperations.Commands.UpdateBook;
using week4_homeworks.DBOperations;
using week4_homeworks.UnitTests.TestSetup;
using Xunit;

namespace week4_homeworks.UnitTests.Application.BookOperations.Command.UpdateBook
{
	public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;

		public UpdateBookCommandTests(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;
			_mapper = testFixture.Mapper;
		}

		[Fact]
		public void WhenNonValidIdIsGiven_Book_ThrowsInvalidOperationException()
		{
			UpdateBookCommand command = new UpdateBookCommand(_context);


			FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book not found.");
		}

		[Fact]
		public void WhenValidInputsAreGiven_Book_ShouldBeUpdated()
		{
			UpdateBookCommand command = new UpdateBookCommand(_context);
			UpdateBookModel model = new UpdateBookModel() { Title = "Hobbits",GenreId = 1};
			command.BookId = 1;
			command.Model = model;

			FluentActions.Invoking(() => command.Handle()).Invoke();

			var book = _context.Books.SingleOrDefault(book => book.Id == command.BookId);
			book.Should().NotBeNull();
			book.Title.Should().Be(model.Title);
			book.GenreId.Should().Be(model.GenreId);			
		}
	}
}