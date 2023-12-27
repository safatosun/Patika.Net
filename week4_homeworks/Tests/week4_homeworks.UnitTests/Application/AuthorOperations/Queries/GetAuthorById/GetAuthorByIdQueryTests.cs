using AutoMapper;
using FluentAssertions;
using week4_homeworks.Applications.AuthorOperations.Queries.GetAuthorById;
using week4_homeworks.DBOperations;
using week4_homeworks.Entities;
using week4_homeworks.UnitTests.TestSetup;
using Xunit;

namespace week4_homeworks.UnitTests.Application.AuthorOperations.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAuthorIdIsNotExist_InvalidOperationException_ShouldBeReturn()
        {
            GetAuthorByIdQuery query = new GetAuthorByIdQuery(_context, null);
           
            query.AuthorId = 0;
           

            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("The Author could not found.");
        }

        [Fact]
        public void WhenAuthorIdIsExist_Author_ShouldBeReturn()
        {

            GetAuthorByIdQuery query = new GetAuthorByIdQuery(_context, _mapper);
            
            var author = new Author
            {
                Name = "WhenAuthorIdIsExist",
                Surname = "ShouldBeTaken",
                Birthdate = new DateTime(2010, 03, 14)
            };
           
            _context.Authors.Add(author);
            _context.SaveChanges();
            
            query.AuthorId = author.Id;

            AuthorDetailViewModel vm = query.Handle();

            vm.Should().NotBeNull();
            vm.Name.Should().Be(author.Name);
        }

    }
}