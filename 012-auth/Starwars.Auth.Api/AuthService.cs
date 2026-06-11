namespace Starwars.Auth.Api
{
    public class AuthService
    {

        public AuthService() 
        { 
        
        }

        public bool IsValid(User usarData, string pass)
        {
            //Hash input password with salt and compare with stored hash
            string passwordHashBase64 = PasswordSha256.HashPassword(pass, usarData.Salt);

            var isValid = PasswordSha256.ValidatePassword(pass,
                                                          usarData.Salt,
                                                          usarData.PasswordHash);

            //var isValid = PasswordSha256.ValidatePassword(pass, 
            //                                              usarData.Salt,
            //                                              usarData.PasswordHash);

            return isValid;
        }
    }
}
