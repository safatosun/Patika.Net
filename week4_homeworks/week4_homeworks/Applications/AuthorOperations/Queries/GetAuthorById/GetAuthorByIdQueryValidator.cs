using FluentValidation;

namespace week4_homeworks.Applications.AuthorOperations.Queries.GetAuthorById
{
	public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
	{
		public GetAuthorByIdQueryValidator()
		{
			RuleFor(a => a.AuthorId).GreaterThan(0);
		}
	}
}