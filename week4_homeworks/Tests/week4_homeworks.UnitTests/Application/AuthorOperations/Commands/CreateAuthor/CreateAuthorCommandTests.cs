using AutoMapper;
using FluentAssertions;
using week4_homeworks.Applications.AuthorOperations.Commands.CreateAuthor;
using week4_homeworks.DBOperations;
using week4_homeworks.UnitTests.TestSetup;
using Xunit;

namespace week4_homeworks.UnitTests.Application.AuthorOperations.Command.CreateAuthor
{
    public class CreateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData("Turgut", "Özakman")]
        [InlineData("İlber", "Ortaylı")]
        public void WhenAlreadyExistAuthorIsGiven_InvalidOperationException_ShouldBeReturn(string firstName, string lastName)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = new CreateAuthorModel
            {
                Name = firstName,
                Surname = lastName,
                Birthdate = new DateTime(2000, 08, 26)
            };            

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Author is already exists.");
        }

        [Fact]
        public void WhenNotExistAuthorIsGiven_Author_ShouldBeCreated()
        {
           
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = new CreateAuthorModel
            {
                Name = "Furkan",
                Surname = "Efe",
                Birthdate = new DateTime(2000, 08, 26)
            };
            
            FluentActions.Invoking(() => command.Handle()).Invoke();
            
            var author = _context.Authors.SingleOrDefault(x => x.Name == command.Model.Name && x.Surname == command.Model.Surname);
            author.Should().NotBeNull();
        }
    }
}