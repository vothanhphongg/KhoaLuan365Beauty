using _365Beauty.Query.Application.DTOs.Localizations;

namespace _365Beauty.Query.Application.DTOs.BeautySalons
{
    public class BeautySalonCatalogWithLocalizationDTO
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
        public string? WardId { get; set; }
        public int IsActived { get; set; }
        public string Address { get; set; }
        public string? AddressFullAscending { get; set; }
        public LocalizationDTO? Localization { get; set; }
    }
}