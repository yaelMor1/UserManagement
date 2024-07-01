using UserManagement.Models;
using System.Collections.Generic;
using System.Linq;


namespace UserManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users= new List<User> ();
        public void CreateUser(User user)
        {
            _users.Add(user);
        }

        public void DeleteUser(Guid userId)
        {
            var user = _users.FirstOrDefault(x=> x.UserId==userId);
            if (user!=null)
            {
                _users.Remove(user);
            }
        }


        public bool validateUser(string userName, string userPassword)
        {
            return _users.Any(u => u.UserName == userName && u.UserPassword == userName);
        }
    }
}
