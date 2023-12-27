using FluentValidation;

namespace MovieStoreApp.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>    
    {
        public DeleteActorCommandValidator() 
        {
            RuleFor(a=>a.ActorId).GreaterThan(0);
        }
    }
}
