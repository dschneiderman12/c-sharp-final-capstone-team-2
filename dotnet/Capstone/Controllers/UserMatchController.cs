using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("userMatch")]
    [ApiController]
    //[Authorize]
    public class UserMatchController : ControllerBase
    {
        private IUserMatchDao userMatchDao;
        public UserMatchController(IUserMatchDao _userMatchDao)
        {
            this.userMatchDao = _userMatchDao;
        }

        [HttpPost()]
        public ActionResult TeeTimeForUser(UserMatch userMatch)
        {
            userMatchDao.SetTeeTimeForUser(userMatch);
            return Ok();

        }

        [HttpGet("{leagueId}")]
        public ActionResult<List<UserMatch>> UserMatchesInLeague(int leagueId)
        {
            List<UserMatch> userMatchesInLeague = userMatchDao.GetUserMatchesForLeague(leagueId);
            if (userMatchesInLeague != null)
            {
                return userMatchesInLeague;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut()]
        public ActionResult AddMatchScore(UserMatch userMatch)
        {
            userMatchDao.InsertMatchScore(userMatch);
            return Ok();
        }

    }
}
