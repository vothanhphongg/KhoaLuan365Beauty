using _365Beauty.Query.Application.DTOs.Localizations;

namespace _365Beauty.Query.Application.DTOs.Users
{
    public class UserInfomationWithLocalizationDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Img { get; set; }
        public string? IdCard { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int UserId { get; set; }
        public string? ProvinceName { get; set; }
        public string? DistrictName { get; set; }
        public string? WardName { get; set; }

    }
}
