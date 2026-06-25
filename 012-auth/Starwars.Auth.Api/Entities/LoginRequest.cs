using System.ComponentModel.DataAnnotations;

namespace Starwars.Auth.Api.Entities
{
    
    public record LoginRequest(string? Username, 
                               string? Password)
    {
        [Required]
        public string Username { get; init; }


        [Required]  
        [MinLength(8)]  
        [MaxLength(100)]
        public string Password { get; init; }
    }
}

