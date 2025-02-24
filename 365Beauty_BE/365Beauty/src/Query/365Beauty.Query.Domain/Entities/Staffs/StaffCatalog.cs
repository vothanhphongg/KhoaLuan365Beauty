using _365Beauty.Query.Domain.Abstractions.Aggregates;
using _365Beauty.Query.Domain.Entities.Services;
using Newtonsoft.Json;

namespace _365Beauty.Query.Domain.Entities.Staffs
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
        public string? TelOther { get; set; }
        public string? Introduction { get; set; }
        public string? Content { get; set; }
        public string? Img { get; set; }
        public int SalonId { get; set; }
        public int? DegreeId { get; set; }
        public int? TitleId { get; set; }
        public int? OccupationId { get; set; }
        public string? Address { get; set; }
        public string WardId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedDate { get; set; }
        public int UserIdUpdated { get; set; }
        public int IsActived { get; set; }

        #region Navigation properties

        [JsonIgnore]
        public ICollection<ServiceCatalog>? ServiceCatalogs { get; set; }

        //[JsonIgnore]
        //public BeautySalonCatalog? BeautySalonCatalog { get; set; }

        //[JsonIgnore]
        //public OccupationCatalog? Occupation { get; set; }

        //[JsonIgnore]
        //public TitleCatalog? Title { get; set; }

        //[JsonIgnore]
        //public DegreeCatalog? Degree { get; set; }

        #endregion
    }
}