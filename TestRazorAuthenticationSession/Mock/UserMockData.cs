using System.Collections.Generic;
using RazorAuthenticationLib.model;

namespace TestRazorAuthenticationSession.Mock
{
    public static class UserMockData
    {
        private readonly static List<User> users = new List<User>()
        {
            new User("Peter", "Secret"),
            new User("Jakob", "Terces")
        };

        public static List<User> Users => new List<User>(users);
    }
}
