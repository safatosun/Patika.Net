using FluentValidation;

namespace week4_homeworks.Applications.AuthorOperations.Commands.UpdateAuthor
{ 
	public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
	{
		public UpdateAuthorCommandValidator()
		{
			RuleFor(a=>a.AuthorId).GreaterThan(0);
			RuleFor(a => a.Model.Name).MinimumLength(2).NotEmpty();
			RuleFor(a => a.Model.Surname).MinimumLength(2).NotEmpty();
			RuleFor(a => a.Model.Birthdate.Date).LessThan(DateTime.Now.Date);
		}
	}

}