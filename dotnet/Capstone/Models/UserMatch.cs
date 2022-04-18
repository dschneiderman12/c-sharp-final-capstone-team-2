using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class UserMatch
    {
        public int MatchId { get; set; }
        public string MatchName { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public DateTime TeeTime { get; set; }
        public int Score { get; set; }
        public int Counter { get; set; }

        public UserMatch()
        {
            Counter = 0;
        }
    }
}
