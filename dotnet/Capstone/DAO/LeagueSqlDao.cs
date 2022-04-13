using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class LeagueSqlDao : ILeagueDao
    {
        private readonly string connectionString;

        public LeagueSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public League GetLeague(int leagueId)
        {
            League league = null;
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"", conn);
                cmd.Parameters.AddWithValue("@", league);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    league = createLeagueFromReader(reader);
                }
            }
            return league;
        }

        public League CreateLeague(League league)
        {
            int newLeagueId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"", conn);
                cmd.Parameters.AddWithValue("@", league);

                newLeagueId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return GetLeague(newLeagueId);
        }

        private League createLeagueFromReader(SqlDataReader reader)
        {
            League league = new League();
            league.LeagueId = Convert.ToInt32(reader["league_id"]);
            league.LeagueName = Convert.ToString(reader["league_name"]);
            league.OrganizerId = Convert.ToInt32(reader["organizer_id"]);
            league.LeagueCourse.CourseId = Convert.ToInt32(reader["course_id"]);
            league.LeagueCourse.CourseName = Convert.ToString(reader["course_name"]);

            return league;
        }
    }
}
