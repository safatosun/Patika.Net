using FluentValidation;

namespace week4_homeworks.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>    
    {
        public DeleteGenreCommandValidator() 
        {
            RuleFor(g=>g.GenreId).GreaterThan(0);
        }
    }
}
