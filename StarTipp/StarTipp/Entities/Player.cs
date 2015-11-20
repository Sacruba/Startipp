using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarTipp.Entities
{
    public class Player : Entity
    {
        public virtual string RelatedUser { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<GameBet> GameBets { get; set; }
    }
}