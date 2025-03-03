using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Staffs;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Staffs.StaffCatalogs
{
    public class GetAllStaffCatalogBySalonIdQuery : IRequest<Result<List<StaffCatalogSimpleDTO>>>
    {
        public int SalonId { get; set; }
        public int IsActived { get; set; }
    }
}