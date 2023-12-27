using FluentAssertions;
using week4_homeworks.Applications.BookOperations.Queries.GetById;
using week4_homeworks.UnitTests.TestSetup;
using Xunit;

public class GetByIdQueryValidatorTests : IClassFixture<CommonTestFixture>
{
    GetByIdQuery query = new GetByIdQuery(null, null);
    GetByIdQueryValidator validator = new GetByIdQueryValidator();
	
	[Theory]
	[InlineData(-1)]
	[InlineData(0)]
	public void WhenInvalidIdAreGiven_Validator_ShouldBeReturnErrors(int id)
	{
		query.BookId = id;

		var result = validator.Validate(query);

		result.Errors.Count.Should().BeGreaterThan(0);
	}
}