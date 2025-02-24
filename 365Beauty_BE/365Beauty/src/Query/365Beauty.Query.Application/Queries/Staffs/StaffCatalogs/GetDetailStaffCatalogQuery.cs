using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Staffs;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Staffs.StaffCatalogs
{
    public class GetDetailStaffCatalogQuery : IRequest<Result<StaffCatalogFullDTO>>
    {
        public int Id { get; set; }
    }
}