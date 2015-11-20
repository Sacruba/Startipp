using System.Collections.Generic;

namespace StarTipp.Entities
{
    public class Tournement : Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<BettingGroup> BettingGroups { get; set; }
        public virtual IList<Stage> Stages { get; set; }
    }
}