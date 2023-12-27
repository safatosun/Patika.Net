using FluentValidation;

namespace week4_homeworks.Applications.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator() 
        {
            RuleFor(g => g.Model.Name).MinimumLength(4).When(x=>x.Model.Name.Trim() != string.Empty);
        }
    }
}
