using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using week4_homeworks.Applications.GenreOperations.Commands.CreateGenre;
using week4_homeworks.DBOperations;
using week4_homeworks.Entities;
using week4_homeworks.UnitTests.TestSetup;
using Xunit;

namespace week4_homeworks.UnitTests.Application.GenreOperations.Command.CreateGenre
{
    public class CreateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenExistGenreNameIsGiven_InvalidOperationException_ThrowsInvalidOperationException()
        {

            var genre = new Genre
            {
                Name="Science",
                IsActive=true,
                
            };

            _context.Genres.Add(genre);
            _context.SaveChanges();

           
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = new CreateGenreModel
            {
                Name = genre.Name,
            };

            FluentActions
               .Invoking(() => command.Handle())
               .Should()
               .Throw<InvalidOperationException>().And.Message.Should().Be("Genre already exists.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Genre_ShouldBeCreated()
        {
            
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = new CreateGenreModel
            {
                Name = "Story"
            };
           
            FluentActions.Invoking(() => command.Handle()).Invoke();

            var genre = _context.Genres.SingleOrDefault(x => x.Name == command.Model.Name);
            genre.Should().NotBeNull();
            genre.IsActive.Should().BeTrue();
        }
    }
}