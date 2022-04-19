using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface ILeagueDao
    {
        public League CreateLeague(League league);
        public League GetLeague(int LeagueId);
        public void AddUserLeagueTable(int userId, int leagueId);
        public List<League> GetLeaguesByUserId(int userId);
<<<<<<< HEAD
        public List<Course> GetCourses();
        public List<LeagueScore> GetLeagueScores(int leagueId);
=======
        
>>>>>>> 3bc3c64ff45a75e1fae85725ef0f03824028b237
    }
}
