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
        public int Id { get; set; }
        public string Name { get; set; }
        public GameSituation Situation { get; set; }
        public List<Player> Players {get;set;}
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
        All = 3
    }
}
