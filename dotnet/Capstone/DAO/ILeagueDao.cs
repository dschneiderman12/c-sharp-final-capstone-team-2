﻿using Capstone.Models;
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
    }
}