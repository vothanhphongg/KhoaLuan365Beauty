using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.BeautySalons;
using _365Beauty.Query.Application.DTOs.Staffs;
using _365Beauty.Query.Application.Queries.Localizations.Wards;
using _365Beauty.Query.Application.Queries.Staffs.StaffCatalogs;
using _365Beauty.Query.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Query.Domain.Entities.Staffs;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;

namespace _365Beauty.Query.Application.UserCases.Staffs.StaffCatalogs
{
    public class GetAllStaffCatalogBySalonIdHandler : IRequestHandler<GetAllStaffCatalogBySalonIdQuery, Result<List<StaffCatalog>>>
    {
        private readonly IStaffCatalogRepository staffCatalogRepository;
        private readonly IMediator mediator;

        public GetAllStaffCatalogBySalonIdHandler(IStaffCatalogRepository staffCatalogRepository, IMediator mediator)
        {
            this.staffCatalogRepository = staffCatalogRepository;
            this.mediator = mediator;
        }
        public async Task<Result<List<StaffCatalog>>> Handle(GetAllStaffCatalogBySalonIdQuery request, CancellationToken cancellationToken)
        {
            var staffs = staffCatalogRepository.FindAll(false,
                x => x.SalonId == request.SalonId,
                x => x.ServiceCatalogs!,
                x => x.OccupationCatalog!,
                x => x.TitleCatalog!,
                x => x.DegreeCatalog!).ToList();
            return await Task.FromResult(Result.Ok(staffs));
        }
    }
}
