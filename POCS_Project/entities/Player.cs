using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCS_Project.entities
{
    public class Player
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Password { get; set; }
        public int Score { get; set; }
        public int RoundsWon { get; set; }
    }
}
