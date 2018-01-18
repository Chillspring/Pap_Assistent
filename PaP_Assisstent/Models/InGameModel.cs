using System.Collections.Generic;

namespace PaP_Assisstent.Models
{
    public class InGameModel
    {
        public string Name { get; set; }

        public IEnumerable<Player> Players { get; set; }
    }
}