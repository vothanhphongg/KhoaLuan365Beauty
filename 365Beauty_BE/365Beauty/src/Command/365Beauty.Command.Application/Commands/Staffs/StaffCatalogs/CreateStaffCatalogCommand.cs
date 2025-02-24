using _365Beauty.Command.Domain.Entities.Staffs;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Staffs.StaffCatalogs
{
    public class CreateStaffCatalogCommand : IRequest<Result<object>>
    {
        public string? Code { get; set; }
        public string? IdCard { get; set; }
        public string? FullName { get; set; }
        public int? Gender { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
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
        public int? UserIdUpdated { get; set; }
        public List<StaffService>? Services { get; set; }
    }
}