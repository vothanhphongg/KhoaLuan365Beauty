using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.Staffs;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Staffs.StaffCatalogs
{
    public class GetAllStaffCatalogBySalonIdQuery : IRequest<Result<List<StaffCatalog>>>
    {
        public int SalonId { get; set; }
    }
}