using System;
using System.Collections.Generic;

#nullable disable

namespace Geometrica.Resources.Models
{
    public partial class Country
    {
        public Country()
        {
            Players = new HashSet<Player>();
        }

        public int Countryid { get; set; }
        public string Iso { get; set; }
        public string Name { get; set; }
        public string Nicename { get; set; }
        public string Iso3 { get; set; }
        public int? Numcode { get; set; }
        public int Phonecode { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
