using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StarTipp.Entities
{
    public class PointPolicy : Entity
    {
        public virtual int WinPoints { get; set; }
        public virtual int ScorePoints { get; set; }
        public virtual int RankingPositionPoints { get; set; }
    }
}