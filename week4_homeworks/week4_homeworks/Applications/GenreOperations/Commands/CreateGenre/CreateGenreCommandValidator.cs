using FluentValidation;

namespace week4_homeworks.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator() 
        {
            RuleFor(g=>g.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}
