using _365Beauty.Command.Domain.Abstractions.Aggregates;
using _365Beauty.Command.Domain.Entities.Staffs;

namespace _365Beauty.Command.Domain.Entities.Users
{
    public class UserAccount : AggregateRoot<int>
    {
        public string Tel { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Otp { get; set; }
        public int IsActived { get; set; }
        public UserInformation? UserInformation { get; set; }
        public StaffCatalog? StaffCatalog { get; set; }
        public List<UserAccountRole>? UserAccountRoles { get; set; }
    }
}