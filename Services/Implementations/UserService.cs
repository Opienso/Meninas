using Meninas.Context;
using Meninas.Entities;
using Meninas.Models;
using Meninas.Services.Interfaces;

namespace Meninas.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly MeninasContext _context;
        public UserService(MeninasContext context)
        {
            _context = context;
        }

        public User? GetUserByEmail(string email) { 
         return _context.Users.SingleOrDefault(u => u.Email == email);
        }
        public BaseResponse ValidateUser(string email, string password)
        {
            BaseResponse response = new();
            User? userForLogin = _context.Users.SingleOrDefault(u => u.Email == email);
            if (userForLogin != null)          //Si lo encuentra, entra al if (distinto de null)
            {
                if (userForLogin.Password == password)
                {
                    response.Result = true;
                    response.Message = "successful login";
                }
                else
                {
                    response.Result = false;
                    response.Message = "wrong password";
                }
            }
            else
            {
                response.Result = false;
                response.Message = "wrong email";
            }
            return response;
        }
        public int CreateUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.Id;
        }
        public void UpdateUser(User user) {
            _context.Update(user);
            _context.SaveChanges();
        }
        public void DeleteUser(User user) { 
          User userToBeDeleted= _context.Users.SingleOrDefault(u=> u.Id == user.Id);  //BORRADO LOGICO DEL BROSCA
            userToBeDeleted.State = false;
            _context.Update(user);
            _context.SaveChanges();
        }

    }
}
