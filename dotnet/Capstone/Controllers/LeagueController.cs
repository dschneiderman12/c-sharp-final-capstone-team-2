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
            return Created($"/league/{addedLeague.LeagueId}", addedLeague);
        }
    }
}
