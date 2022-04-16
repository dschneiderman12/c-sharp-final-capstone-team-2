using Capstone.Models;
using System.Collections.Generic;
namespace Capstone.DAO
{
    public interface IUserDao
    {
        User GetUser(string username);
        User AddUser(string username, string password, string role);
<<<<<<< HEAD
        public List<User> GetUserList();
=======
        
        public List<ReturnUser> GetUserList();
>>>>>>> a90f55bcf64a2a183cf3243989eeeadb06228e30

    }
}
