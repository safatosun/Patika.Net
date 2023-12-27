using FluentValidation;

namespace week4_homeworks.Applications.BookOperations.Queries.GetById
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}
