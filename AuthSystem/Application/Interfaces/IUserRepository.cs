using AuthSystem.Domain;

namespace AuthSystem.Application.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetByEmail(Email email);
        bool ExistsByEmail(Email email);
    }
}
