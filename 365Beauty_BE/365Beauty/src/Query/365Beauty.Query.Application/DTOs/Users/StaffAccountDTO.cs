namespace _365Beauty.Query.Application.DTOs.Users
{
    public class StaffAccountDTO
    {
        public int SalonId { get; set; }
        public string SalonName { get; set; }
        public string Email { get; set; }
        public string Tel {  get; set; }
        public string Img { get; set; }
        public bool IsActived { get; set; }
    }
}
