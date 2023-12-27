using FluentValidation;

namespace MovieStoreApp.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommanValidator : AbstractValidator<CreateOrderModelDto>
    {
        public CreateOrderCommanValidator() 
        {
            RuleFor(o => o.CustomerId).GreaterThan(0);
            RuleFor(o => o.MovieId).GreaterThan(0);

        }
    }
}
