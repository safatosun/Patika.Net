using FluentAssertions;
using week4_homeworks.Applications.GenreOperations.Commands.DeleteGenre;
using Xunit;

namespace Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidatorTests
    {
        public DeleteGenreCommandValidatorTests() { }

        [Fact]
        public void WhenGenreIdIsNotGiven_InvalidOperationException_ShouldBeReturn()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(null);
           
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            command.GenreId = 0;
            
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidGenreIdIsGiven_Validation_ShouldNotBeReturnErrors()
        {           
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            
            command.GenreId = 1;
            
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}