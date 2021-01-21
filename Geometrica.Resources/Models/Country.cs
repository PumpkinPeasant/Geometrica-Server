using System.Collections.Generic;
using Geometrica.Resources.Models;

#nullable disable

namespace Geometrica.Auth.Resources.Models
{
    public sealed partial class Country
    {
        private ICollection<Player> players;

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

        public ICollection<Player> Players
        {
            get => players;
            set => players = value;
        }
    }
}
