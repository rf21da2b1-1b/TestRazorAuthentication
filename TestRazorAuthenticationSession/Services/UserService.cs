using System.Collections.Generic;
using RazorAuthenticationLib.model;
using TestRazorAuthenticationSession.Mock;

namespace TestRazorAuthenticationSession.Services
{
    public class UserService:IUserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = UserMockData.Users;
        }

        public List<User> GetAll()
        {
            return new List<User>(_users);
        }

        public User Get(string username)
        {
            User user = _users.Find(u => u.UserName == username);
            
            return (user != null)? user: throw new KeyNotFoundException();
        }

        public User Create(User user)
        {
            User u = Get(user.UserName); // check if exists, not exists => keyNotFoundException 
            _users.Add(user);
            return user;
        }

        public User Update(User user)
        {
            User u = Get(user.UserName); // check if exists, not exists => keyNotFoundException 
            int indexOfUser = _users.IndexOf(u);
            _users[indexOfUser] = user;
            return user;
        }

        public User Delete(string username)
        {
            User u = Get(username); // check if exists, not exists => keyNotFoundException 
            _users.Remove(u);
            return u;
        }

        public bool Contains(User user)
        {
            return _users.Contains(user);
        }

        public RoleType ContainsAndGiveRole(User user)
        {
            if (!Contains(user))
            {
                user.Role = RoleType.Guest;
            }
            else
            {
                user.Role = (user.UserName.Equals("Peter")) ? RoleType.Admin : RoleType.Member;
            }

            return user.Role;

        }
    }
}
