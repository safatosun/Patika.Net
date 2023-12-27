using FluentAssertions;

using Xunit;

namespace week4_homeworks.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidatorTests
    {
        public CreateGenreCommandValidatorTests() { }

       

        [Theory]
        [InlineData("foo")]
        [InlineData("fo")]
        [InlineData("f")]
        [InlineData("")]       
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string genreName)
        {

            CreateGenreCommand command = new CreateGenreCommand(null, null);
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            command.Model = new CreateGenreModel
            {
                Name = genreName
            };

            var result = validator.Validate(command);

            result.Errors.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {

            CreateGenreCommand command = new CreateGenreCommand(null, null);
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            command.Model = new CreateGenreModel
            {
                Name = "Story"
            };

            var result = validator.Validate(command);

            result.Errors.Count().Should().Be(0);
        }
    }
}