using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarTipp.Entities
{
    public class GameBet : Entity
    {
        public virtual BettingGroup BettingGroup { get; set; }
        public virtual Game Game { get; set; }
        public virtual int WinsGamer1 { get; set; }
        public virtual int WinsGamer2 { get; set; }
    }
}