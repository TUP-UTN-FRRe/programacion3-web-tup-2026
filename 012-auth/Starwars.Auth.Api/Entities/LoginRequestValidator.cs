using FluentValidation;

namespace Starwars.Auth.Api.Entities
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {            
            RuleFor(x => x.Username)
                    .NotNull()
                    .NotEmpty();

            RuleFor(x => x.Password)
                    .NotNull()
                    .NotEmpty()
                    .Length(8, 100);
        }
    }
}
