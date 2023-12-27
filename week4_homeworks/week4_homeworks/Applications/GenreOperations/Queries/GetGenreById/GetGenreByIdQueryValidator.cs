using FluentValidation;

namespace week4_homeworks.Applications.GenreOperations.Queries.GetGenreById
{
    public class GetGenreByIdQueryValidator : AbstractValidator<GetGenreByIdQuery>
    {
        public GetGenreByIdQueryValidator()
        {
            RuleFor(query => query.GenreId).GreaterThan(0);
        }

    }
    
}
