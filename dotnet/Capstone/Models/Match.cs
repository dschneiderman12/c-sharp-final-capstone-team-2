using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public string MatchName { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }

    }
}
