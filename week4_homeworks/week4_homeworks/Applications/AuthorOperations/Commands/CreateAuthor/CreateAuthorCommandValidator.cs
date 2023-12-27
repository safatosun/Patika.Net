using FluentValidation;

namespace week4_homeworks.Applications.AuthorOperations.Commands.CreateAuthor 
{  
	public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
	{
		public CreateAuthorCommandValidator()
		{
			RuleFor(a => a.Model.Name).MinimumLength(3).NotEmpty();
			RuleFor(a => a.Model.Surname).MinimumLength(3).NotEmpty();
			RuleFor(a => a.Model.Birthdate.Date).LessThan(DateTime.Now.Date);
		}
	}
}