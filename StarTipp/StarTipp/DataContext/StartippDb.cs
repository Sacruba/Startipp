using System.Data.Entity;
using StarTipp.Entities;

namespace StarTipp.DataContext
{
    public class StarTippDb : DbContext
    {
        public virtual DbSet<Tournement> Tournements { get; set; }
        public virtual DbSet<BettingGroup> BettingGroup { get; set; }

        public StarTippDb():base("DefaultConnection")
        {
            
        }
    }
}