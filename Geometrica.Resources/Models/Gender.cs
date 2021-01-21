using System;
using System.Collections.Generic;

#nullable disable

namespace Geometrica.Resources.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Players = new HashSet<Player>();
        }

        public int Genderid { get; set; }
        public string Value { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
