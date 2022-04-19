using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueDao leagueDao;

        public LeagueController(ILeagueDao _leagueDao)
        {
            leagueDao = _leagueDao;
        }

        [HttpPost()]
        public ActionResult<League> NewLeague(League league)
        {
            League addedLeague = leagueDao.CreateLeague(league);
            leagueDao.AddUserLeagueTable(league.OrganizerId, addedLeague.LeagueId);
            return Created($"/league/{addedLeague.LeagueId}", addedLeague);
        }


        [HttpGet("{leagueId}")]
        public ActionResult<League> GetLeagueById(int leagueId)
        {
            League league = leagueDao.GetLeague(leagueId);
            if (league != null)
            {
                return league;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("user/{userId}")]
        public ActionResult<List<League>> GetLeaguesByUserId(int userId)
        {
            List<League> userLeagues = leagueDao.GetLeaguesByUserId(userId);
            if (userLeagues != null)
            {
                return userLeagues;
            }
            else
            {
                return NotFound();
            }
        }

<<<<<<< HEAD
        [HttpGet("/courses")]
        public ActionResult<List<Course>> GetAllCourses()
        {
            List<Course> allCourses = leagueDao.GetCourses();
            if (allCourses != null)
            {
                return allCourses;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("scores/{leagueId}")]
        public ActionResult<List<LeagueScore>> GetUserLeagueScores(int leagueId)
        {
            List<LeagueScore> userLeagueScores = leagueDao.GetLeagueScores(leagueId);
            if (userLeagueScores != null)
            {
                return userLeagueScores;
            }
            else
            {
                return NotFound();
            }
        }
=======
        
        
>>>>>>> 3bc3c64ff45a75e1fae85725ef0f03824028b237
    }
}

