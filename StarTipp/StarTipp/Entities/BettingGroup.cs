using System.Collections.Generic;

namespace StarTipp.Entities
{
    public class BettingGroup : Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<Player> Players { get; set; }
        public virtual IList<Tournement> Tournements { get; set; }
    }
}