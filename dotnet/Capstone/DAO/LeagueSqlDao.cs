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
                SqlCommand cmd = new SqlCommand(@"SELECT league_id, league_name, organizer_id, leagues.course_id, course_name
                                                FROM leagues JOIN courses ON courses.course_id = leagues.course_id
                                                WHERE league_id = @league_id", conn);
                cmd.Parameters.AddWithValue("@league_id", leagueId);

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
                SqlCommand cmd = new SqlCommand(@"INSERT INTO leagues(league_name, organizer_id, course_id)
                                                OUTPUT INSERTED.league_id
                                                VALUES (@league_name, @organizer_id, @course_id);", conn);
                cmd.Parameters.AddWithValue("@league_name", league.LeagueName);
                cmd.Parameters.AddWithValue("@organizer_id", league.OrganizerId);
                cmd.Parameters.AddWithValue("@course_id", league.LeagueCourse.CourseId);
                
                newLeagueId = Convert.ToInt32(cmd.ExecuteScalar());
                
            }

            return GetLeague(newLeagueId);
         
               
            
        }

        private League createLeagueFromReader(SqlDataReader reader)
        {
            League league = new League();
            Course course = new Course();
            league.LeagueId = Convert.ToInt32(reader["league_id"]);
            league.LeagueName = Convert.ToString(reader["league_name"]);
            league.OrganizerId = Convert.ToInt32(reader["organizer_id"]);
            course.CourseId = Convert.ToInt32(reader["course_id"]);
            course.CourseName = Convert.ToString(reader["course_name"]);
            league.LeagueCourse = course;
            return league;
        }
    }
}
