﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Geometrica.Auth.Models
{
    public partial class Player
    {
        public int Uid { get; set; }
        public string Nickname { get; set; }
        public int Genderid { get; set; }
        public DateTime Birthdate { get; set; }
        public int Countryid { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
