using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace MovieStoreApp.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieModelDto>    
    {
        public UpdateMovieCommandValidator() 
        {
            RuleFor(m=>m.Name).MinimumLength(3).When(m=>m.Name.IsNullOrEmpty());
            RuleFor(m=>m.GenreId).GreaterThan(0);
            RuleFor(m=>m.Price).GreaterThan(0);
        }
    }
}
