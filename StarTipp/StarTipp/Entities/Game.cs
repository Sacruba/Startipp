using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarTipp.Entities
{
    public class Game : Entity
    {
        public virtual Gamer Gamer1 { get; set; }
        public virtual Gamer Gamer2 { get; set; }
        public virtual int WinsGamer1 { get; set; }
        public virtual int WinsGamer2 { get; set; }
        public virtual PlayoffFormat PlayoffFormat { get; set; }
    }
}