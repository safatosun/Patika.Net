using FluentValidation;

namespace MovieStoreApp.Application.OrderOperations.Queries.GetOrderById
{
    public class GetOrderByIdQueryValidator : AbstractValidator<GetOrderByIdQuery>  
    {
        public GetOrderByIdQueryValidator() 
        {
            RuleFor(o=> o.OrderId).GreaterThan(0);
        }
    }
}
