
using TechnicalTest.Domain.Common.Entities;

namespace TechnicalTest.Domain.Users.Entities
{
    public sealed class User: Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Token { get; private set; } = string.Empty;

        private User()
        {
        }

        private User(string name, string email, string password, string token)
        {
            Name = name;
            Email = email;
            Password = password;
            Token = token;
        }

        private User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public static User Create(string name, string email, string password)
        {
            return new User(name, email, password);
        }

        public void UpdateToken(string token)
        {
            this.Token = token;
        }

        public bool Login(string email, string password)
        {
            if (Email == email && Password == password)
            {
                return true;
            }
            return false;
        }

    }
}
