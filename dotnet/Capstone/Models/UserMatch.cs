using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class UserMatch
    {
        public User User { get; set; }
        public Match Match { get; set; }
        public DateTime TeeTime { get; set; }
        public int Score { get; set; }
        public League MatchLeague { get; set; }

    }
}
