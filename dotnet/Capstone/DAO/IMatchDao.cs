using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IMatchDao
    {
        public Match GetMatch(int matchId);
        public Match CreateMatch(Match match);
        public List<User> GetUsersByLeague(int LeagueId);
        public void setTeeTimeForUser(int marchId, int userId, DateTime teetime);


    }
}
