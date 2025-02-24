namespace _365Beauty.Query.Application.DTOs.Localizations
{
    public class LocalizationDTO
    {
        public string WardId { get; set; }
        public string ProvinceId { get; set; }
        public string WardName { get; set; }
        public string DistrictName { get; set; }
        public string ProvinceName { get; set; }
        public string NameDescending => $"{ProvinceName}, {DistrictName}, {WardName}";
        public string NameAscending => $"{WardName}, {DistrictName}, {ProvinceName}";
    }
}
