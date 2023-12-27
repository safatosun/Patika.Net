using FluentAssertions;
using week4_homeworks.Applications.GenreOperations.Queries.GetGenreById;
using Xunit;

namespace week4_homeworks.UnitTests.Application.Genreperations.Queries.GetGenreById

{
    public class GetGenreByIdQueryValidatorTests
    {
        public GetGenreByIdQueryValidatorTests()
        {
        }

        [Fact]
        public void WhenInvalidGenreIdGiven_InvalidOperationException_ShouldBeReturn()
        {
            GetGenreByIdQuery query = new GetGenreByIdQuery(null, null);
            GetGenreByIdQueryValidator validator = new GetGenreByIdQueryValidator();

            query.GenreId = 0;
            
            var result = validator.Validate(query);
           
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidGenreIdIsGiven_Validation_ShouldNotBeReturnErrors()
        {
            GetGenreByIdQuery query = new GetGenreByIdQuery(null, null);

            GetGenreByIdQueryValidator validator = new GetGenreByIdQueryValidator();
           
            query.GenreId = 1;
            
            var result = validator.Validate(query);
            
            result.Errors.Count.Should().Be(0);
        }
    }
}