using AuthSystem.Application.Interfaces;
using AuthSystem.Domain;

namespace AuthSystem.Application.Services
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new();
        public void Add(User user)
        {
            _users.Add(user);
        }
        public User? GetByEmail(Email email)
        {
            return _users.FirstOrDefault(u => u.Email.Address == email.Address);
        }
        public bool ExistsByEmail(Email email)
        {
            return _users.Any(u => u.Email.Address == email.Address);
        }
    }
}
