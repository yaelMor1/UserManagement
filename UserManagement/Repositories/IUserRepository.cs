using UserManagement.Models;

namespace UserManagement.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void DeleteUser(Guid userId);
        bool validateUser (string userName , string userPassword);
    }
}
