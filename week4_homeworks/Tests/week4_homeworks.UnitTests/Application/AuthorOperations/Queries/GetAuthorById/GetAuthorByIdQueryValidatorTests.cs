using FluentAssertions;
using week4_homeworks.Applications.AuthorOperations.Queries.GetAuthorById;
using Xunit;

namespace week4_homeworks.UnitTests.Application.AuthorOperations.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryValidatorTests
    {
        public GetAuthorByIdQueryValidatorTests() { }

        [Fact]
        public void WhenInvalidAuthorIdGiven_InvalidOperationException_ShouldBeReturn()
        {

            GetAuthorByIdQuery query = new GetAuthorByIdQuery(null, null);
            GetAuthorByIdQueryValidator validator = new GetAuthorByIdQueryValidator();
            
            query.AuthorId = 0;

            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidAuthorIdIsGiven_Validation_ShouldNotBeReturnErrors()
        {

            GetAuthorByIdQuery query = new GetAuthorByIdQuery(null, null);
            GetAuthorByIdQueryValidator validator = new GetAuthorByIdQueryValidator();
            
            query.AuthorId = 1;

             var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }
    }
}