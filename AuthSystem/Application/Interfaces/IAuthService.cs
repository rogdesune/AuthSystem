using AuthSystem.Domain;

namespace AuthSystem.Application.Interfaces
{
    public interface IAuthService
    {
        User Register(string email, string password);
        User Login(string email, string password);
        User ChangeUserEmail(string currentEmail, string newEmail);
    }
}
