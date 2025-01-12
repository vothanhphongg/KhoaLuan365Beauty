namespace _365Beauty.Command.Presentation.DTOs.BeautySalonCatalogRequestDTOs
{
    public class CreateBeautySalonCatalogRequest
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? Tel { get; set; }
        public string? Image { get; set; }
        public string? WorkingDate { get; set; }
        public string? Address { get; set; }
        public int? WardId { get; set; }
        public int? UserIdCreated { get; set; }
    }
}