using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface IUserMatchDao
    {
        public List<UserMatch> GetUserMatchesForLeague(int leagueId);
        public void InsertMatchScore(UserMatch userMatch);
        public void SetTeeTimeForUser(UserMatch userMatch);
        public List<UserMatch> GetUserMatchesUpcoming(int userId);
    }
}
