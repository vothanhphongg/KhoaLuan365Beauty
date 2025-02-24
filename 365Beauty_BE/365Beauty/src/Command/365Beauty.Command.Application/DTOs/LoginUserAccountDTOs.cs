using _365Beauty.Command.Domain.Entities.Users;
using _365Beauty.Contract.Shared;

namespace _365Beauty.Command.Application.DTOs
{
    public class LoginUserAccountDTOs
    {
        public int Id { get; set; }
        public AuthResult? AuthResults {  get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Tel { get; set; }
        public string? Img { get; set; }
        public List<UserRole>? UserRoles { get; set; }
    }
}
