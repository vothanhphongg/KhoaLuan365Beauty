using _365Beauty.Query.Application.DTOs.Staffs;
using _365Beauty.Query.Domain.Entities.BeautySalons;

namespace _365Beauty.Query.Application.DTOs.BeautySalons
{
    public class BeautySalonCatalogFullDTO
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string Tel { get; set; }
        public string Image { get; set; }
        public string? WorkingDate { get; set; }
        public string? AddressFullAscending { get; set; }
        public List<BeautySalonImage>? BeautySalonImages { get; set; }
        public List<BeautySalonServiceWithPriceDTO>? BeautySalonServices { get; set; }
        public List<StaffCatalogDTO>? StaffCatalogs { get; set; }
    }
}
