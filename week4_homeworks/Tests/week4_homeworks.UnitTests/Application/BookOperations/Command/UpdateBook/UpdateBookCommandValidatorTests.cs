using FluentAssertions;
using week4_homeworks.Applications.BookOperations.Commands.UpdateBook;
using week4_homeworks.UnitTests.TestSetup;
using Xunit;

namespace week4_homeworks.UnitTests.Application.BookOperations.Command.UpdateBook
{
    public class UpdateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData("", 0)]
        [InlineData("", 1)]
        [InlineData("A", 0)]
        [InlineData("A", 1)]
        [InlineData("Aa", 0)]
        [InlineData("AAA", 0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int genreid)
        {

            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Model = new UpdateBookModel
            {
                Title = title,
                GenreId = genreid
            };

            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors()
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.BookId = 1;
            command.Model = new UpdateBookModel
            {
                Title = "1984",
                GenreId = 1
            };

            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count().Should().Be(0);

        }
    }
}