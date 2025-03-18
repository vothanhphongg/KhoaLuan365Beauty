namespace _365Beauty.Query.Application.DTOs.Users
{
    public class UserBookingSalonDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SalonServiceId { get; set; }
        public int TimeId { get; set; }
        public string UserName { get; set; }
        public string UserTel { get; set; }
        public string UserEmail { get; set; }
        public string? UserAvatar { get; set; }
        public string SalonServiceName { get; set; }
        public int? StaffId { get; set; }
        public string? StaffName { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Times { get; set; }
        public string BookingTypeName { get; set; }
        public Decimal Price { get; set; }
        public string? Description { get; set; }
        public int IsActived { get; set; }
        public string Actived { get; set; }
    }
}