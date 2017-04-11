using Passenger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Passenger.Core.Domain;
using System.Linq;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>()
        {
            new User("user1@gmail.com","user1","secret1","salt"),
            new User("user2@gmail.com","user2","secret2","salty"),
            new User("user3@email.com","user3","secret3","salten")
        };

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(Guid id)
        {
            return _users.Single(x => x.Id == id);
        }

        public User Get(string email)
        {
            return _users.Single(x => x.Email == email.ToLowerInvariant());
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);
        }

        public void Update(User user)
        {
            
        }
    }
}
