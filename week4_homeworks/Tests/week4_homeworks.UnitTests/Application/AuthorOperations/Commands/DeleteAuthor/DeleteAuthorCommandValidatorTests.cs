using FluentAssertions;
using week4_homeworks.Applications.AuthorOperations.Commands.DeleteAuthor;
using Xunit;

namespace week4_homeworks.UnitTests.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidatorTests
    {
        public DeleteAuthorCommandValidatorTests() { }

        [Fact]
        public void WhenAuthorIdIsNotGiven_InvalidOperationException_ShouldBeReturn()
        {
            
            DeleteAuthorCommand command = new DeleteAuthorCommand(null);
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            command.AuthorId = default;

            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidAuthorIdIsGiven_Validation_ShouldNotBeReturnErrors()
        {

            DeleteAuthorCommand command = new DeleteAuthorCommand(null);
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            command.AuthorId = 1;

             var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}