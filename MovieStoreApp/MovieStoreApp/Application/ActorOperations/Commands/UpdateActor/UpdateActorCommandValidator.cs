using FluentValidation;

namespace MovieStoreApp.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorModelDto>
    {
       public UpdateActorCommandValidator()
       {
            RuleFor(a=>a.Name).MinimumLength(3);
            RuleFor(a=>a.Surname).MinimumLength(3);
        }

    }
}
