using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCS_Project.entities
{
    public class Round
    {
        public int Id { get; set; }
        public int IdPLayer { get; set; }
        public Card CardPlayed { get; set; }
    }
}
