using System;
using System.Collections.Generic;
using RazorAuthenticationLib.model;

namespace TestRazorAuthenticationSession.Services
{
    public interface IUserService
    {
        public List<User> GetAll();
        public User Get(string username);
        public User Create(User user);
        public User Update(User user);
        public User Delete(String username);
        public bool Contains(User user);
        public RoleType ContainsAndGiveRole(User user);
    }
}
