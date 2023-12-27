using FluentValidation;

namespace MovieStoreApp.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(c=>c.CustomerId).GreaterThan(0);

        }
    }
}
