using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Passenger.Core.Domain
{
    public class User
    {
        public Guid Id { get; protected set; }

        public string Email { get; protected set; }

        public string Username { get; protected set; }

        public string Password { get; protected set; }

        public string Salt { get; protected set; }

        public string Fullname { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        protected User()
        {

        }

        public User(string email, string username, string password, string salt)
        {
            Id = Guid.NewGuid();
            Email = ValidateEmail(email);
            Username = ValidateString(username);
            Password = ValidateString(password);
            Salt = ValidateString(salt);
            CreatedAt = DateTime.UtcNow;
        }

        private string ValidateString(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException("String cannot be null or whitespace!");
            }
            return str.Trim().ToLowerInvariant();

        }

        private string ValidateEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or whitespace!");
            }
            var temp = email.Trim().ToLowerInvariant();

            bool isEmail = Regex.IsMatch(
                temp, 
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", 
                RegexOptions.IgnoreCase);

            if (isEmail) return temp;
            else throw new ArgumentException("Invalid email address");

        }
    }
}
