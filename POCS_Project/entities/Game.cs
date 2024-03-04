using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCS_Project.entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GameSituation Situation { get; set; }
        public List<Player> Players {get;set;}
    }
    public enum GameSituation
    {
        // Open = A
        Open = 0,
        // Playing = T
        Playing = 1,
        // Closed = E
        Closed = 2
    }
}
