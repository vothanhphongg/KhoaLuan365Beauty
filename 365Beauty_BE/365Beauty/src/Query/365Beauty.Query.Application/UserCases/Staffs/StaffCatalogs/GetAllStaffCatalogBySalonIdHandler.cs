using _365Beauty.Contract.Enumerations;
using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Staffs;
using _365Beauty.Query.Application.Queries.Staffs.StaffCatalogs;
using _365Beauty.Query.Domain.Abstractions.Repositories.Staffs;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Staffs.StaffCatalogs
{
    public class GetAllStaffCatalogBySalonIdHandler : IRequestHandler<GetAllStaffCatalogBySalonIdQuery, Result<List<StaffCatalogSimpleDTO>>>
    {
        private readonly IStaffCatalogRepository staffCatalogRepository;

        public GetAllStaffCatalogBySalonIdHandler(IStaffCatalogRepository staffCatalogRepository)
        {
            this.staffCatalogRepository = staffCatalogRepository;
        }
        public async Task<Result<List<StaffCatalogSimpleDTO>>> Handle(GetAllStaffCatalogBySalonIdQuery request, CancellationToken cancellationToken)
        {
            var staffs = staffCatalogRepository.FindAll(false, x => x.SalonId == request.SalonId && x.IsActived == StatusActived.Actived);
            var entities = staffs.Select(x => new StaffCatalogSimpleDTO
            {
                Id = x.Id,
                Code = x.Code,
                IdCard = x.IdCard,
                Tel = x.Tel,
                FullName = x.FullName,
                Img = x.Img,
            }).ToList();
            return await Task.FromResult(Result.Ok(entities));
        }
    }
}
