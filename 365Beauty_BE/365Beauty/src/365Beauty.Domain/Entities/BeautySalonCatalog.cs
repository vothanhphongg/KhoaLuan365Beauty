using _365Beauty.Contract.Validators;
using _365Beauty.Domain.Abstractions.Aggregates;
using _365Beauty.Domain.Constants;

namespace _365Beauty.Domain.Entities
{
    public class BeautySalonCatalog : AggregateRoot<int>
    {
        public string? Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string Tel {  get; set; }
        public string Image { get; set; }
        public string? WorkingDate { get; set; }
        public string? Address { get; set; }
        public int WardId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UserIdCreated { get; set; }
        public int? UserIdUpdated { get; set; }
        public int IsActived { get; set; }

        public void Update(string? code = null, string? name = null, string? description = null, string? content = null,
                           string? email = null, string? website = null, string? tel = null, string image = null,
                           string? workingDate = null, string? address = null, int? wardId = null, 
                           int? userIdUpdated = null, int? isActived = null)
        {
            Code = code ?? Code;
            Name = name ?? Name;
            Description = description ?? Description;
            Content = content ?? Content;
            Email = email ?? Email;
            Website = website ?? Website;
            Tel = tel ?? Tel;
            Image = image ?? Image;
            WorkingDate = workingDate ?? WorkingDate;
            Address = address ?? Address;
            WardId = wardId ?? WardId;
            UserIdUpdated = userIdUpdated ?? UserIdUpdated;
            IsActived = isActived ?? IsActived;
        }
    }
}