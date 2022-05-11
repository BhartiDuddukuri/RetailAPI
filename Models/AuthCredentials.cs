using System.ComponentModel.DataAnnotations;

namespace RetailAPI.Models
{
    public class AuthCredentials
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}