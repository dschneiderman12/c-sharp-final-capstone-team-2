using Capstone.Models;
using System.Collections.Generic;
namespace Capstone.DAO
{
    public interface IUserDao
    {
        User GetUser(string username);
<<<<<<< HEAD
        User AddUser(string username, string password, string role);
<<<<<<< HEAD
        public List<User> GetUserList();
=======
        
=======
        User AddUser(string username, string password, string role);           
>>>>>>> 0bfbe72ad94e89b1b64960c2e7e9f4b5a74eec5c
        public List<ReturnUser> GetUserList();
>>>>>>> a90f55bcf64a2a183cf3243989eeeadb06228e30

    }
}
