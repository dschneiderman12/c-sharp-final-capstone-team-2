using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class UserMatchSqlDao : IUserMatchDao
    {
        private readonly string connectionString;

        public UserMatchSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<UserMatch> GetUserMatchesForLeague(int leagueId)
        {
            List<UserMatch> userMatchesInLeague = new List<UserMatch>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT user_id, user_match.match_id, score, tee_time, league_id, match_name
                                        FROM user_match
                                        JOIN matches ON matches.match_id = user_match.match_id
                                        WHERE league_id = @league_id", conn);
                    cmd.Parameters.AddWithValue("@league_id", leagueId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       UserMatch userMatch = createUserMatchFromReader(reader);
                        userMatchesInLeague.Add(userMatch);
                    }
                }
                return userMatchesInLeague;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public void InsertMatchScore(UserMatch userMatch)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"UPDATE user_match 
                                                SET score = @score
                                                WHERE match_id = @match_id AND user_id = @user_id", conn);
                    cmd.Parameters.AddWithValue("@score", userMatch.Score);
                    cmd.Parameters.AddWithValue("@match_id", userMatch.MatchId);
                    cmd.Parameters.AddWithValue("@user_id", userMatch.UserId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }



        private UserMatch createUserMatchFromReader(SqlDataReader reader)
        {
            UserMatch userMatch = new UserMatch();

            userMatch.MatchId = Convert.ToInt32(reader["match_id"]);
            userMatch.UserId = Convert.ToInt32(reader["user_id"]);
            userMatch.TeeTime = Convert.ToDateTime(reader["tee_time"]);
            userMatch.Score = Convert.ToInt32(reader["score"]);

            return userMatch;
        }
    }
}
