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



        private Match createMatchFromReader(SqlDataReader reader)
        {
            Match match = new Match();

            match.MatchId = Convert.ToInt32(reader["match_id"]);
            match.MatchName = Convert.ToString(reader["match_name"]);
            match.DateAndTime = Convert.ToDateTime(reader["start_time"]);

            return match;
        }
    }
}
