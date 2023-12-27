using AutoMapper;
using FluentAssertions;
using week4_homeworks.DBOperations;
using week4_homeworks.UnitTests.TestSetup;
using Xunit;

namespace week4_homeworks.Applications.BookOperations.Queries.GetById
{

	public class GetByIdQueryTests : IClassFixture<CommonTestFixture>
	{
		private readonly IBookStoreDbContext _dbContext;
		private readonly IMapper _mapper;
		public GetByIdQueryTests(CommonTestFixture testFixture)
		{
			_dbContext = testFixture.Context;
			_mapper = testFixture.Mapper;
		}

		[Fact]
		public void WhenNonValidIdIsGiven_Book_ThrowsInvalidOperationException()
		{
			GetByIdQuery query = new GetByIdQuery(_dbContext, _mapper);
			query.BookId = 0;

			FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book not found.");
		}
	}
}