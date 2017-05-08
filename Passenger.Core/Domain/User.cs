using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Passenger.Core.Helpers;

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
        public DateTime UpdatedAt { get; protected set; }

        public string Role { get; protected set; }

        protected User()
        {

        }

        public User(string email, string username, string password, string salt, string role)
        {
            Id = Guid.NewGuid();
            Email = Validation.ValidateEmail(email);
            Username = Validation.ValidateString(username);
            Password = Validation.ValidateString(password);
            Salt = Validation.ValidateString(salt);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Role = role;
        }

        public void SetRole(string role)
        {
            if (this.Role == role) return;

            this.Role = role;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
