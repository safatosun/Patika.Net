using FluentValidation;

namespace MovieStoreApp.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
    {
       public DeleteDirectorCommandValidator() 
       {
           RuleFor(d=>d.DirectorId).GreaterThan(0);
       }
    }
}
