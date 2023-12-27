using FluentValidation;

namespace MovieStoreApp.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorModelDto>
    {
        public CreateActorCommandValidator() {

            RuleFor(a=>a.Name).MinimumLength(3);
            RuleFor(a=>a.SurName).MinimumLength(3);
        }
    }
}
