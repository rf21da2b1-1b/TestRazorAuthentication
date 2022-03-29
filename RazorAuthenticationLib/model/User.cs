using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorAuthenticationLib.model
{
    public enum RoleType
    {
        Guest,
        Member,
        Admin
    };
    public class User
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public RoleType Role { get; set; }



        public bool IsGuest
        {
            get
            {
                return Role == RoleType.Guest;
            }
        }
        public bool IsMember
        {
            get
            {
                return Role == RoleType.Member;
            }
        }
        public bool IsAdmin
        {
            get
            {
                return Role == RoleType.Admin;
            }
        }

        public User():this("","")
        {
        }
        public User(string userName, string password):this(userName, password, RoleType.Guest)
        {
        }
        public User(string userName, string password, RoleType role)
        {
            UserName = userName;
            Password = password;
            Role = role;
        }

        public override string ToString()
        {
            return $"{nameof(UserName)}: {UserName}, {nameof(Password)}: {Password}, {nameof(Role)}: {Role}";
        }

        protected bool Equals(User other)
        {
            return UserName == other.UserName && Password == other.Password;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserName, Password);
        }
    }
}
