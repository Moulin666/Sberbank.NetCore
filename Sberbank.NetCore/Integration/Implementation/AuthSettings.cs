using Sberbank.NetCore.Integration.Interfaces;
using System.Collections.Generic;

namespace Sberbank.NetCore.Integration.Implementation
{
    public class AuthSettings : IParameters
    {
        public class Keys
        {
            public const string UserName = "userName";
            public const string Password = "password";
        }

        public string UserName { get; set; }
        public string Password { get; set; }

        public AuthSettings(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        Dictionary<string, object> IParameters.CollectParameters ()
            => new Dictionary<string, object>
            {
                {
                    Keys.UserName, UserName
                },
                {
                    Keys.Password, Password
                }
            };
    }
}
