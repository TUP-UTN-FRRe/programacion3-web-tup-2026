namespace Starwars.Auth.Api
{
    public class AuthService
    {

        public AuthService() 
        { 
        
        }

        public bool IsValid(User usarData, string pass)
        {
            // Valida el password usando el salt y hash almacenados en userData
            return PasswordSha256.ValidatePassword(pass,
                                                   usarData.Salt,
                                                   usarData.PasswordHash);
        }
    }
}
