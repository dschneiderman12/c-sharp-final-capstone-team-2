using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class InviteSqlDao : IInviteDao
    {
        private readonly string connectionString;

        public InviteSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public Invite CreateInvite(Invite invite)
        {
            int newInviteId;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"", conn);
                    //cmd.Parameters.AddWithValue("", );
                    
                    newInviteId = Convert.ToInt32(cmd.ExecuteScalar());

                }
                return GetInvite(newInviteId);
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public Invite GetInvite(int inviteId)
        {
            Invite invite = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"", conn);
                    //cmd.Parameters.AddWithValue("", );

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        invite = createInviteFromReader(reader);
                    }
                }
                return invite;
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public void AcceptInvite();
        public void DenyInvite();
        public List<Invite> ListPendingInvites();

        private Invite createInviteFromReader(SqlDataReader reader)
        {
            Invite invite = new Invite();

            invite.InviteId = Convert.ToInt32(reader["invite_id"]);
            invite.InviteStatus = Convert.ToString(reader["invite_status"]);
            invite.ToUserId = Convert.ToInt32(reader["to_user"]);
            invite.ToLeagueId = Convert.ToInt32(reader["to_league"]);

            return invite;
        }
    }
}
