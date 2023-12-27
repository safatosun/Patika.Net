using FluentValidation;

namespace week4_homeworks.Applications.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator() 
        {
            RuleFor(a=> a.AuthorId).GreaterThan(0);
        }
    }
}
