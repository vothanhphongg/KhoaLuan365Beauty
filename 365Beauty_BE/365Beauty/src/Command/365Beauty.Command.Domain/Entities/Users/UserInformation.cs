using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.Users
{
    public class UserInformation : AggregateRoot<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Img { get; set; }
        public string? IdCard { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? WardId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UserId { get; set; }

        public void Update(string? firstName = null, string? lastName = null, int? gender = null, DateTime? dateOfBirth = null,
                           string? img = null, string? idCard = null, string? email = null,  string? address = null, string? wardId = null)
        {
            FirstName = firstName ?? FirstName;
            LastName = lastName ?? LastName;
            Gender = gender ?? Gender;
            DateOfBirth = dateOfBirth ?? DateOfBirth;
            Img = img ?? Img;
            IdCard = idCard ?? IdCard;
            Email = email ?? Email;
            Address = address ?? Address;
            WardId = wardId ?? WardId;
        }
    }
}