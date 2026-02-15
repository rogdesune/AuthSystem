using AuthSystem.Application.Interfaces;
using AuthSystem.Domain;
using Microsoft.AspNetCore.Identity;

namespace AuthSystem.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public AuthService (IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public User Register(string email, string password)
        {
            var emailVo = new Email(email);
            if (_userRepository.ExistsByEmail(emailVo)) {
                throw new InvalidOperationException("Email já cadastrado");
            }
            var user = new User(emailVo);
            var hash = _passwordService.HashPassword(user, password);
            user.ChangePassword(hash);
            _userRepository.Add(user);
            return user;
        }

        public User Login(string email, string password)
        {
            var emailVo = new Email(email);
            var user = _userRepository.GetByEmail(emailVo) ?? throw new InvalidOperationException("Email não encontrado");
            if (!user.HasPassword())
            {
                throw new InvalidOperationException("Usuário não possui senha cadastrada");
            }
            var isValid = _passwordService.VerifyPassword(user, password);
            if (!isValid)
            {
                throw new UnauthorizedAccessException("Senha inválida");
            }
            return user;
        }
    }
}
