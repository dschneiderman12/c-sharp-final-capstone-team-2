using Capstone.Models;
using System.Collections.Generic;
namespace Capstone.DAO
{
    public interface IUserDao
    {
        User GetUser(string username);
        User AddUser(string username, string password, string role);
<<<<<<< HEAD
        
=======
        public List<User> GetUserList();
>>>>>>> a8f89eec724fc8a9bd223057b94df17095ccb07f
    }
}
