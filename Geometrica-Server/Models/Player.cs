﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Geometrica_Server.Models
{
    public partial class Player
    {
        public Player()
        {
            Games = new HashSet<Game>();
        }

        public int Uid { get; set; }
        public string Nickname { get; set; }
        public int Genderid { get; set; }
        public DateTime Birthdate { get; set; }
        public int Countryid { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Country Country { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
