using System.ComponentModel.DataAnnotations;

namespace Geometrica.Resources
{
    public class User
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}