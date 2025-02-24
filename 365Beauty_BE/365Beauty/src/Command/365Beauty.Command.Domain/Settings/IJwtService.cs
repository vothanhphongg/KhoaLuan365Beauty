using _365Beauty.Command.Domain.Entities.Users;

namespace _365Beauty.Domain.Settings
{
    public interface IJwtService
    {
        string GenerateToken(UserAccount user, IList<string> roles);
    }
}