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
        public void setTeeTimeForUser(UserMatch userMatch);
<<<<<<< HEAD:dotnet/Capstone/DAO/Interfaces/IMatchDao.cs
        public void InsertMatchScore(UserMatch userMatch);
=======
        public List<Match> GetMatchesByLeagueId(int leagueId);

>>>>>>> ca52ddf5cd0df1d2b279ed58adfb1386ad55a08d:dotnet/Capstone/DAO/IMatchDao.cs

    }
}
