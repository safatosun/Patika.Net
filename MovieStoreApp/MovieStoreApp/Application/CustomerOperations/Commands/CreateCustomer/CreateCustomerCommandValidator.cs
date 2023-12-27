using FluentValidation;

namespace MovieStoreApp.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerModelDto>
    {
        public CreateCustomerCommandValidator() 
        {
            RuleFor(c=>c.Name).MinimumLength(3);
            RuleFor(c => c.Surname).MinimumLength(3);
            RuleFor(c => c.Password).MinimumLength(4);
        }

    }
}
