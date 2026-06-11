namespace Starwars.Auth.Api
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }

    }
}
