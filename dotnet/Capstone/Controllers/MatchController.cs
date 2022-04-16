﻿using Capstone.DAO;
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
        [HttpGet("league/users/{leagueId}")]
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
        //we need to add http post for create tee time here


    }
}
