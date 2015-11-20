using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarTipp.Entities
{
    public class Stage : Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<Game> Games { get; set; }
        public virtual IList<Gamer> Gamer { get; set; }
        public virtual StageType StageType { get; set; }
        public virtual PointPolicy PointPolicy { get; set; }
    }
}