using FluentAssertions;
using week4_homeworks.Applications.AuthorOperations.Commands.CreateAuthor;
using Xunit;

namespace Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidatorTests
    {
        public CreateAuthorCommandValidatorTests() { }

       
        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {

            CreateAuthorCommand command = new CreateAuthorCommand(null, null);
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            command.Model = new CreateAuthorModel
            {
                Name = null,
                Surname = default,             
                Birthdate = new DateTime(1920, 08, 26)
            };

            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);            
            
        }

        

        [Fact]
        public void WhenDateOfBirthIsGivenAsEqualOrBiggerThanToday_Validator_ShouldBeReturn()
        {

            CreateAuthorCommand command = new CreateAuthorCommand(null, null);
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            command.Model = new CreateAuthorModel
            {
                Name = null,
                Surname = default,
                Birthdate = DateTime.Now
            };
           
            var result = validator.Validate(command);
            
            result.Errors.Count.Should().BeGreaterThan(0);            
      
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            CreateAuthorCommand command = new CreateAuthorCommand(null, null);
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            command.Model = new CreateAuthorModel
            {
                Name = "Yaren",
                Surname = "Arpa",
                Birthdate = new DateTime(1920, 08, 26)
            };

            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}