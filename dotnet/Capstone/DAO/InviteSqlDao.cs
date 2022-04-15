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
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO invites(invite_status, to_user, to_league)
                                                OUTPUT INSERTED.invite_id
                                                VALUES ('pending', @to_user, @to_league)", conn);
                    cmd.Parameters.AddWithValue("@to_user", invite.ToUserId);
                    cmd.Parameters.AddWithValue("@to_league", invite.ToLeagueId);

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
                    SqlCommand cmd = new SqlCommand(@"SELECT invite_id, invite_status, to_user, to_league
                                            FROM invites
                                            WHERE invite_id = @inviteId", conn);
                    cmd.Parameters.AddWithValue("@inviteId", inviteId);

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

        public void AcceptInvite(int inviteId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"UPDATE invites
                                                SET invite_status = 'accepted'
                                                WHERE invite_id = @inviteId", conn);
                    cmd.Parameters.AddWithValue("@inviteId", inviteId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public void DeclineInvite(int inviteId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"UPDATE invites
                                                SET invite_status = 'declined'
                                                WHERE invite_id = @inviteId", conn);
                    cmd.Parameters.AddWithValue("@inviteId", inviteId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public List<Invite> ListPendingInvites(int userId)
        {
            List<Invite> userLeagueInvites = new List<Invite>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT invite_id, invite_status, to_user, to_league
                                                FROM invites
                                                WHERE to_user = @user_id AND invite_status = 'pending'", conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Invite newInvite = createInviteFromReader(reader);                        
                        userLeagueInvites.Add(newInvite);
                    }
                }
                return userLeagueInvites;
            }
            catch (SqlException)
            {
                throw;
            }
        }

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
