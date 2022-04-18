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
    // [Authorize]
    public class MatchController : ControllerBase
    {
        private readonly IMatchDao matchDao;

        public MatchController(IMatchDao _matchDao)
        {
            matchDao = _matchDao;
        }
        [HttpGet("user/{leagueId}")]
        public ActionResult<List<User>> GetUsersByLeague(int leagueId)
        {
            List<User> userlist = matchDao.GetUsersByLeague(leagueId);

            if (userlist != null)
            {
                return userlist;
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet("{leagueId}")]
        public ActionResult<List<Match>> GetMatchesByLeagueId(int leagueId)
        {
            List<Match> matches = matchDao.GetMatchesByLeagueId(leagueId);
            if (matches != null)
            {
                return matches;
            }
            else
            {
                return NotFound();
            }
        }
        
        [HttpPost("/createMatch")]
        public ActionResult CreateMatch(Match match)
        {
            matchDao.CreateMatch(match);
            return Ok();

        }

        [HttpPost()]
        public ActionResult TeeTimeForUser(UserMatch userMatch)
        {
            matchDao.SetTeeTimeForUser(userMatch);
            return Ok();

        }

       
    }
}
