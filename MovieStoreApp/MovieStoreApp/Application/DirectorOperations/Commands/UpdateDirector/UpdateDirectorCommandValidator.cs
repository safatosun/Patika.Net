using FluentValidation;

namespace MovieStoreApp.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorModelDto>
    {
        public UpdateDirectorCommandValidator() 
        {
            RuleFor(d=>d.Name).MinimumLength(3);
            RuleFor(d=>d.Surname).MinimumLength(3);
        }
    }
}
