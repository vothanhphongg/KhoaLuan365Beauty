namespace _365Beauty.Query.Application.DTOs.Users
{
    public class UserRatingFullDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Img {  get; set; }
        public string? Comment { get; set; }
        public double Count { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}