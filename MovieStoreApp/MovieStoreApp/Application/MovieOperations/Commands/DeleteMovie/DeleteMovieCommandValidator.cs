using FluentValidation;

namespace MovieStoreApp.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator() 
        {
            RuleFor(m => m.MovieId).GreaterThan(0);
        }
    }
}
