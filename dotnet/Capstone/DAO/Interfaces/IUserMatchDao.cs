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
<<<<<<< HEAD
=======
        public List<UserMatch> GetUserMatchesUpcoming(int userId);
>>>>>>> 26b1b4afaba4993f5a3b977693f7728663f6c261
    }
}
