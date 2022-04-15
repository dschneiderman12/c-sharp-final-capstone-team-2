using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    interface IInviteDao
    {
        public Invite CreateInvite(Invite invite);
        public Invite GetInvite(int inviteId);
        public void AcceptInvite();
        public void DenyInvite();
        public List<Invite> ListPendingInvites();
    }
}
