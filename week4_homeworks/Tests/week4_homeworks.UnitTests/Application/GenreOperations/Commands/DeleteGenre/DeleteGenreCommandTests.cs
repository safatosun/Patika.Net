using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using week4_homeworks.Applications.GenreOperations.Commands.DeleteGenre;
using week4_homeworks.DBOperations;
using week4_homeworks.Entities;
using week4_homeworks.UnitTests.TestSetup;
using Xunit;

namespace week4_homeworks.UnitTests.Application.GenreOperations.Command.DeleteGenre
{
    public class DeleteGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenNotExistGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            
            DeleteGenreCommand command = new DeleteGenreCommand(_context);

            
            command.GenreId = 0;
            
           FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre could not found.");


        }

        [Fact]
        public void WhenGenreNotUsingByAnyBook_Genre_ShouldBeDeleted()
        {
          
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            
            var genre = new Genre
            {
                Name = "WhenGenreNotUsingByAnyBook_Genre_ShouldBeDeleted"
            };
            
            _context.Genres.Add(genre);
            _context.SaveChanges();
           
            command.GenreId = genre.Id;
            
            FluentActions.Invoking(() => command.Handle()).Invoke();

            var testGenre = _context.Genres.SingleOrDefault(x => x.Id == command.GenreId);
            testGenre.Should().BeNull();
        }

    }
}