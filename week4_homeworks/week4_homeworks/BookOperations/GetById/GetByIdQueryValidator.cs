using FluentValidation;

namespace week4_homeworks.BookOperations.GetById
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }    
    }
}
