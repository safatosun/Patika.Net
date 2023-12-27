using AutoMapper;
using FluentAssertions;
using week4_homeworks.Applications.GenreOperations.Queries.GetGenreById;
using week4_homeworks.DBOperations;
using week4_homeworks.Entities;
using week4_homeworks.UnitTests.TestSetup;
using Xunit;

namespace week4_homeworks.UnitTests.Application.Genreperations.Queries.GetGenreById
{
    public class GetGenreByIdQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreByIdQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotExistGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
             
            GetGenreByIdQuery query = new GetGenreByIdQuery(_context, _mapper);
            
            query.GenreId = 0;
            
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Genre type could not found.");
        }
    
      
    }
}