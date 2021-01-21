using System;
using System.Collections.Generic;

#nullable disable

namespace Geometrica.Resources.Models
{
    public partial class Game
    {
        public int Gameid { get; set; }
        public int Uid { get; set; }
        public int Rightguesses { get; set; }
        public int Wrongguesses { get; set; }
        public int Roundnum { get; set; }
        public int Time { get; set; }

        public virtual Player UidNavigation { get; set; }
    }
}
