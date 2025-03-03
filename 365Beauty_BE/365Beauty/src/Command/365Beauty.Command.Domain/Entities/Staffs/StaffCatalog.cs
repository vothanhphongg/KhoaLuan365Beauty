using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.Staffs
{
    public class StaffCatalog : AggregateRoot<int>
    {
        public string? Code { get; set; }
        public string IdCard { get; set; }
        public string FullName { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Tel { get; set; }
        public string? Introduction { get; set; }
        public string? Img { get; set; }
        public int SalonId { get; set; }
        public int? DegreeId { get; set; }
        public int? TitleId { get; set; }
        public int? OccupationId { get; set; }
        public string? Address { get; set; }
        public string WardId { get; set; }
        public int IsActived { get; set; }

        public List<StaffService>? StaffServices { get; set; }

        public void Update(string? code = null, string? idCard = null, string? fullName = null, int? gender = null,
                           DateTime? dateOfBirth = null, string? email = null, string? tel = null, string? introduction = null,
                           string? img = null, int? degreeId = null, int? titleId = null,  int? occupationId = null,
                           string? address = null, string? wardId = null, int? isActived = null)
        {
            Code = code ?? Code;
            IdCard = idCard ?? IdCard;
            FullName = fullName ?? FullName;
            Gender = gender ?? Gender;
            DateOfBirth = dateOfBirth ?? DateOfBirth;
            Email = email ?? Email;
            Tel = tel ?? Tel;
            Introduction = introduction ?? Introduction;
            Img = img ?? Img;
            DegreeId = degreeId ?? DegreeId;
            TitleId = titleId ?? TitleId;
            OccupationId = occupationId ?? OccupationId;
            Address = address ?? Address;
            WardId = wardId ?? WardId;
            IsActived = isActived ?? IsActived;
        }
    }
}