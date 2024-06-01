using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCS_Project.entities
{
    public class Game
    {
        public int Id;
        public string Name;
        public GameSituation Situation;
        public List<Player> Players;
    }

    public enum GameSituation
    {
        [Display(Name = "A")]
        Open = 0,
        [Display(Name = "J")]
        Playing = 1,
        [Display(Name = "F")]
        Closed = 2,
        [Display(Name = "T")]
        All = 3,
        [Display(Name = "E")]
        Finished = 4
    }
}
