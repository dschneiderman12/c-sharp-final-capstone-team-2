using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class UserMatchSqlDao
    {
        private readonly string connectionString;

        public UserMatchSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        //public UserMatch GetUserMatchesForLeague(int leagueId)
        //{
        //    Match match = null;
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            SqlCommand cmd = new SqlCommand(@"SELECT match_id, match_name, start_time
        //                                            FROM matches
        //                                            WHERE match_id = @match_id", conn);
        //            cmd.Parameters.AddWithValue("@match_id", matchId);

        //            SqlDataReader reader = cmd.ExecuteReader();
        //            if (reader.Read())
        //            {
        //                //match = createMatchFromReader(reader);
        //            }
        //        }
        //        //return match;
        //    }
        //    catch (SqlException)
        //    {
        //        throw;
        //    }
        //}

       
    }
}
