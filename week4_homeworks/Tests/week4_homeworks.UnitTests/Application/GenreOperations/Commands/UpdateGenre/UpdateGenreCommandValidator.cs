using FluentAssertions;
using week4_homeworks.Applications.GenreOperations.Commands.UpdateGenre;
using Xunit;

namespace week4_homeworks.UnitTests.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidatorTests
    {
        public UpdateGenreCommandValidatorTests() {}

 

        [Theory]
        [InlineData("nul")]
        [InlineData("nu")]
        [InlineData("n")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string genreName)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null, null);
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            command.GenreId = 2;
            command.Model = new UpdateGenreModel
            {
                Name = genreName
            };
            
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("Science")]
        [InlineData("Action")]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(string genreName)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null, null);
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            command.GenreId = 2;
            command.Model = new UpdateGenreModel
            {
                Name = genreName
            };

            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}