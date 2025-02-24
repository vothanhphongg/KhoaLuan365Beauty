using _365Beauty.Command.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace _365Beauty.Command.Persistence.Settings
{
    public class PasswordHasher : IPasswordHasher<UserAccount>
    {
        private readonly PasswordHasher<UserAccount> hasher = new();

        public string HashPassword(UserAccount user, string password)
        {
            return hasher.HashPassword(user, password);
        }

        public PasswordVerificationResult VerifyHashedPassword(UserAccount user, string hashedPassword, string providedPassword)
        {
            return hasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
        }
    }
}