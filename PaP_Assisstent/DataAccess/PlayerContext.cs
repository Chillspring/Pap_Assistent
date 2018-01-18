using PaP_Assisstent.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PaP_Assisstent.DataAccess
{
    public class PlayerContext : DbContext
    {
        public PlayerContext() : base("PlayerContext")
        {
        }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}