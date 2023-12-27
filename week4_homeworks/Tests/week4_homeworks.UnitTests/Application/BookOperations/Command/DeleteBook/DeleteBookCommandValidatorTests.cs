using FluentAssertions;
using week4_homeworks.Applications.BookOperations.Commands.DeleteBook;
using week4_homeworks.UnitTests.TestSetup;
using Xunit;

namespace week4_homeworks.UnitTests.Application.GenreOperations.Command.DeleteGenre
{

	public class DeleteBookCommandValidatorTests : IClassFixture<CommonTestFixture>
	{
		DeleteBookCommand command = new DeleteBookCommand(null);
		DeleteBookCommandValidator validator = new DeleteBookCommandValidator();

		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInValidInputAreGiven_Validator_ShouldBeReturnErrors(int id)
		{

			command.BookId = id;

			var result = validator.Validate(command);

			result.Errors.Count.Should().BeGreaterThan(0);
		}
	}
}