using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.BeautySalons
{
    public class BeautySalonCatalog : AggregateRoot<int>
    {
        public string? Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string Tel { get; set; }
        public string Image { get; set; }
        public string WorkingDate { get; set; }
        public string? Address { get; set; }
        public string WardId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UserIdCreated { get; set; }
        public int? UserIdUpdated { get; set; }
        public int IsActived { get; set; }
        public List<BeautySalonService>? beautySalonServices { get; set; }
        public void Update(string? code = null, string? name = null, string? description = null,
                           string? email = null, string? website = null, string? tel = null, string image = null,
                           string? workingDate = null, string? address = null, string? wardId = null,
                           int? userIdUpdated = null)
        {
            Code = code ?? Code;
            Name = name ?? Name;
            Description = description ?? Description;
            Email = email ?? Email;
            Website = website ?? Website;
            Tel = tel ?? Tel;
            Image = image ?? Image;
            WorkingDate = workingDate ?? WorkingDate;
            Address = address ?? Address;
            WardId = wardId ?? WardId;
            UserIdUpdated = userIdUpdated ?? UserIdUpdated;
        }
    }
}