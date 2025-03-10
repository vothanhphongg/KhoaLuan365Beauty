using _365Beauty.Query.Domain.Entities.BeautySalons;
using _365Beauty.Query.Domain.Entities.Services;

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
        public string? DegreeName { get; set; }
        public string? TitleName { get; set; }
        public string? OccupationName { get; set; }
        public string? ProvinceName { get; set; }
        public string? DistrictName { get; set; }
        public string? WardName { get; set; }
    }
}
