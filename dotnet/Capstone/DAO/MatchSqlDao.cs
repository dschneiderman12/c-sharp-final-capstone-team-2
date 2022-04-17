using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class MatchSqlDao : IMatchDao
    {
        private readonly string connectionString;

        public MatchSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Match GetMatch(int matchId)
        {
            Match match = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT match_id, match_name, start_time
                                                    FROM matches
                                                    WHERE match_id = @match_id", conn);
                    cmd.Parameters.AddWithValue("@match_id", matchId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        match = createMatchFromReader(reader);
                    }
                }
                return match;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public Match CreateMatch(Match match)
        {
            int newMatchId;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO matches (match_name, start_time)
                                                    OUTPUT INSERTED.match_id
                                                    VALUES (@match_name, @match_datetime)", conn);
                    cmd.Parameters.AddWithValue("@match_name", match.MatchName);
                    cmd.Parameters.AddWithValue("@match_name", match.DateAndTime);

                    newMatchId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                return GetMatch(newMatchId);
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public List<User> GetUsersByLeague(int LeagueId)
        {
            List<User> usersInLeague = new List<User>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM users 
                                                        JOIN user_league ON users.user_id = user_league.user_id
                                                        WHERE league_id = @league_Id", conn);
                    cmd.Parameters.AddWithValue("@league_Id", LeagueId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User();
                        user.UserId = Convert.ToInt32(reader["user_id"]);
                        
                        user.Username = Convert.ToString(reader["username"]);
                        usersInLeague.Add(user);


                    }
                }
                return usersInLeague;

            }
            catch (SqlException)
            {
                throw;
            }
        }



        private Match createMatchFromReader(SqlDataReader reader)
        {
            Match match = new Match();

            match.MatchId = Convert.ToInt32(reader["match_id"]);
            match.MatchName = Convert.ToString(reader["match_name"]);
            match.DateAndTime = Convert.ToDateTime(reader["start_time"]);

            return match;
        }
        public void setTeeTimeForUser(UserMatch userMatch)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO user_match (user_id, match_id, tee_time) 
                                                VALUES(@user_id, @match_id, @tee_time); ", conn);
                    cmd.Parameters.AddWithValue("@match_id", userMatch.MatchId);
                    cmd.Parameters.AddWithValue("@user_id", userMatch.UserId);
                    cmd.Parameters.AddWithValue("@tee_time", userMatch.TeeTime);

                    cmd.ExecuteNonQuery();
                }
                ;
            }
            catch (SqlException)
            {
                throw;
            }


        }

    }
}
