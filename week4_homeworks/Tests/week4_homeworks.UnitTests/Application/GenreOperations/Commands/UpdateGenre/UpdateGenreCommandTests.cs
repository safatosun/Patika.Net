using AutoMapper;
using FluentAssertions;
using week4_homeworks.Applications.BookOperations.Commands.UpdateBook;
using week4_homeworks.Applications.GenreOperations.Commands.UpdateGenre;
using week4_homeworks.DBOperations;
using week4_homeworks.UnitTests.TestSetup;
using Xunit;

namespace week4_homeworks.UnitTests.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNonValidIdIsGiven_Book_ThrowsInvalidOperationException()
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context,_mapper);

            command.GenreId = 0;
            
            command.Model = new UpdateGenreModel
            {
                Name = "Story",
                IsActive = true
            };

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("genre could not found.");
        }


        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeUpdated()
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context, _mapper);

            command.GenreId = 2;
            command.Model = new UpdateGenreModel
            {
                Name = "Story",
                IsActive = true
            };

                 
            FluentActions.Invoking(() => command.Handle()).Invoke();      

            var genre = _context.Genres.SingleOrDefault(x => x.Id == command.GenreId);
            genre.Should().NotBeNull();
            genre.Name.Should().Be(command.Model.Name);
            genre.IsActive.Should().Be(command.Model.IsActive);
        }
    }
}