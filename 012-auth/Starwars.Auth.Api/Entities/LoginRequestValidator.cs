using FluentValidation;

namespace Starwars.Auth.Api.Entities
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            
            RuleFor(login => login.Username)
                    .NotNull()
                    .NotEmpty();

            RuleFor(login => login.Password)
                    .NotNull()
                    .NotEmpty()
                    .Length(8, 100);
        }
    }
}
