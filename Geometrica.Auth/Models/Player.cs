using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Geometrica.Auth.Models
{
    public partial class Player
    {
        public int Uid { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public int Genderid { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public int Countryid { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
