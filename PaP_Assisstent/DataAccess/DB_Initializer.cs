using PaP_Assisstent.Models;
using System.Collections.Generic;

namespace PaP_Assisstent.DataAccess
{
    public class DB_Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PlayerContext>
    {
        protected override void Seed(PlayerContext context)
        {
            var players = new List<Player>
            {
            };

            players.ForEach(s => context.Players.Add(s));
            context.SaveChanges();
        }
    }
}