using FluentValidation;

namespace MovieStoreApp.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieModelDto>
    {
        public CreateMovieCommandValidator() 
        {
            RuleFor(m => m.Name).MinimumLength(3);
            RuleFor(m => m.GenreId).GreaterThan(0);
            RuleFor(m => m.ActorId).GreaterThan(0);
            RuleFor(m => m.Price).GreaterThan(0);
            RuleFor(m => m.DirectorId).GreaterThan(0);
        }
    }
}
