using FluentAssertions;
using week4_homeworks.Applications.AuthorOperations.Commands.UpdateAuthor;
using Xunit;

namespace week4_homeworks.UnitTests.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidatorTests
    {
        public UpdateAuthorCommandValidatorTests() { }

        [Fact]
        public void WhenInvalIdAuthorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            UpdateAuthorCommand command = new UpdateAuthorCommand(null, null);
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
           
            command.AuthorId = 0;
            command.Model = new UpdateAuthorModel();

            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null, null);
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            command.Model = new UpdateAuthorModel
            {
                Name = "s",
                Surname = "t",
                Birthdate = DateTime.Now.AddDays(5)
            };

            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);                       
        }

        
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors()
        {

            UpdateAuthorCommand command = new UpdateAuthorCommand(null, null);
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            command.AuthorId = 1;
            command.Model = new UpdateAuthorModel
            {
                Name = "Ali",
                Surname = "İnceman",
                Birthdate = new DateTime(1998, 08, 06)
            };

            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}