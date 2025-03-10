using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Staffs;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Staffs.StaffCatalogs
{
    public class GetAllStaffCatalogByBeautySalonServiceIdQuery : IRequest<Result<List<StaffCatalogDTO>>>
    {
        public int BeautySalonServiceId { get; set; }
        public DateTime BookingDate { get; set; }
        public int TimeId { get; set; }
    }
}