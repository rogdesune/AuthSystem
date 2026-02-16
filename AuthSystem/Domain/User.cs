
namespace AuthSystem.Domain
{
    public class User
    {
        public Guid Id { get; private set; }
        public Email Email { get ; private set; }
        public string? PasswordHash { get; private set; }
        public Role Role { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastUpdatedAt { get; private set; }

        public User (Email email)
        {
            this.Id = Guid.NewGuid();
            this.Email = email ?? throw new ArgumentNullException(nameof(email));
            this.Role = Role.USER;
            this.CreatedAt = DateTime.UtcNow;
            this.LastUpdatedAt = this.CreatedAt;
        }

        public bool HasPassword()
        {
            return !string.IsNullOrEmpty(this.PasswordHash);
        }

        public void SetPassword(string newPasswordHash)
        {
            if(string.IsNullOrWhiteSpace(newPasswordHash))
            {
                throw new ArgumentException("Password hash inválida.", nameof(newPasswordHash));
            }
            this.PasswordHash = newPasswordHash;
            this.LastUpdatedAt = DateTime.UtcNow;
        }
        public void ChangeEmail (Email newEmail)
        {
            if (newEmail is null)
            {
                throw new ArgumentNullException(nameof(newEmail));
            }
            if (newEmail.Equals(this.Email))
            {
                throw new ArgumentException("O novo email deve ser diferente do email atual.", nameof(newEmail));
            }
            this.Email = newEmail;
            LastUpdatedAt = DateTime.UtcNow;
        }
    }
}
