using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace StarTipp.Entities
{
    public class Gamer : Entity
    {
        public virtual string Name { get; set; }
    }
}