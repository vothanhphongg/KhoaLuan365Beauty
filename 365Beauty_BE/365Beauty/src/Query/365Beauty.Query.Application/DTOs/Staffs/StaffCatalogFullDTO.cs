using _365Beauty.Query.Application.DTOs.Localizations;
using _365Beauty.Query.Domain.Entities.BeautySalons;
using _365Beauty.Query.Domain.Entities.Services;
using _365Beauty.Query.Domain.Entities.Staffs;

namespace _365Beauty.Query.Application.DTOs.Staffs
{
    public class StaffCatalogFullDTO
    {
        public int Id { get; set; }
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
        public string? AddressFullAscending { get; set; }
        public string WardId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedDate { get; set; }
        public int UserIdUpdated { get; set; }
        public int IsActived { get; set; }
        public List<ServiceCatalog>? ServiceCatalogs { get; set; }
        public BeautySalonCatalog? BeautySalon { get; set; }
        public DegreeCatalog? Degree { get; set; }
        public TitleCatalog? Title { get; set; }
        public OccupationCatalog? Occupation { get; set; }
        public LocalizationDTO? Localization { get; set; }
    }
}
