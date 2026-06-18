using Starwars.Auth.Api.Extensiones;

namespace Starwars.Auth.Api.Entities
{
    public class LoginRequestValidatorCustom
    {
        public bool IsValid { get; private set; }

        public bool Validate(LoginRequest loginRequest) {

             if (loginRequest is null) {
                IsValid = false;
                return false;
             }

             if (string.IsNullOrEmpty(loginRequest.Username)) {
                IsValid = false;
                return false;
             }

            //if (string.IsNullOrEmpty(loginRequest.Password)) {
            //   IsValid = false;
            //   return false;
            //}

            if (!loginRequest.Password.NotEmpty()) {
                IsValid = false;
                return false;
            }

             IsValid = true;
             return true;
        }

    }
}
