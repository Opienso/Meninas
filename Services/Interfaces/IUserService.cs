using Meninas.Entities;
using Meninas.Models;

namespace Meninas.Services.Interfaces
{
    public interface IUserService
    {
        public User? GetUserByEmail(string email);
        public BaseResponse ValidateUser(string email, string password);
        public int CreateUser(User user);

        public void UpdateUser(User user);

        public void DeleteUser(User user);
    }
}
