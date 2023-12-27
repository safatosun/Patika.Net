using FluentValidation;

namespace MovieStoreApp.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorModelDto>
    {
        public CreateDirectorCommandValidator() 
        {
            RuleFor(d=> d.Name).MinimumLength(3);
            RuleFor(d=>d.Surname).MinimumLength(3);
        }
    }
}
