using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Localizations;
using _365Beauty.Query.Application.DTOs.Staffs;
using _365Beauty.Query.Application.Queries.Localizations.Wards;
using _365Beauty.Query.Application.Queries.Staffs.StaffCatalogs;
using _365Beauty.Query.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Query.Domain.Abstractions.Repositories.Services;
using _365Beauty.Query.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Query.Domain.Entities.BeautySalons;
using _365Beauty.Query.Domain.Entities.Services;
using _365Beauty.Query.Domain.Entities.Staffs;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Staffs.StaffCatalogs
{
    public class GetDetailStaffCatalogHandler : IRequestHandler<GetDetailStaffCatalogQuery, Result<StaffCatalogFullDTO>>
    {
        private readonly IStaffCatalogRepository staffCatalogRepository;
        private readonly IBeautySalonCatalogRepository beautySalonCatalogRepository;
        private readonly IDegreeCatalogRepository degreeCatalogRepository;
        private readonly ITitleCatalogRepository titleCatalogRepository;
        private readonly IOccupationCatalogRepository occupationCatalogRepository;
        private readonly IMediator mediator;

        public GetDetailStaffCatalogHandler(IStaffCatalogRepository staffCatalogRepository,
                                            IBeautySalonCatalogRepository beautySalonCatalogRepository,
                                            IDegreeCatalogRepository degreeCatalogRepository, 
                                            ITitleCatalogRepository titleCatalogRepository, 
                                            IOccupationCatalogRepository occupationCatalogRepository,
                                            IMediator mediator)
        {
            this.staffCatalogRepository = staffCatalogRepository;
            this.beautySalonCatalogRepository = beautySalonCatalogRepository;
            this.degreeCatalogRepository = degreeCatalogRepository;
            this.titleCatalogRepository = titleCatalogRepository;
            this.occupationCatalogRepository = occupationCatalogRepository;
            this.mediator = mediator;
        }
        public async Task<Result<StaffCatalogFullDTO>> Handle(GetDetailStaffCatalogQuery request, CancellationToken cancellationToken)
        {
            StaffCatalog? staff = await staffCatalogRepository.FindByIdAsync(request.Id, false, true, cancellationToken, x => x.ServiceCatalogs!);
            BeautySalonCatalog? beautySalon = await beautySalonCatalogRepository.FindByIdAsync(staff.SalonId);
            DegreeCatalog? degree = null;
            if (staff.DegreeId != null)
                degree = await degreeCatalogRepository.FindByIdAsync((int)staff.DegreeId!);
            OccupationCatalog? occupation = null;
            if (staff.OccupationId != null)
                occupation = await occupationCatalogRepository.FindByIdAsync((int)staff.OccupationId!);
            TitleCatalog? title = null;
            if (staff.TitleId != null)
                title = await titleCatalogRepository.FindByIdAsync((int)staff.TitleId!);

            Result<LocalizationDTO>? wardResult = null;
            if (staff.WardId != null)
            {
                wardResult = await mediator.Send(new GetDetailWardQuery { Id = staff.WardId! }, cancellationToken);
            }
            var ward = new GetDetailWardQuery
            {
                Id = staff.WardId!
            };
          
            StaffCatalogFullDTO entity = new StaffCatalogFullDTO
            {
                Code = staff.Code,
                IdCard = staff.IdCard,
                FullName = staff.FullName,
                Gender = staff.Gender,
                DateOfBirth = staff.DateOfBirth,
                Email = staff.Email,
                Tel = staff.Tel,
                Introduction = staff.Introduction,
                Img = staff.Img,
                SalonId = staff.SalonId,
                DegreeId = staff.DegreeId,
                OccupationId = staff.OccupationId,
                TitleId = staff.TitleId,
                BeautySalon = beautySalon,
                DegreeName = degree?.Name,
                OccupationName = occupation?.Name,
                TitleName = title?.Name,
                ProvinceName = wardResult?.Data?.ProvinceName,
                DistrictName = wardResult?.Data?.DistrictName,
                WardName = wardResult?.Data?.WardName,
                WardId = staff.WardId!,
                Address = staff.Address,
                AddressFullAscending = $" {staff.Address}, {wardResult?.Data?.NameAscending}",
                IsActived = staff.IsActived,
            };
            entity.ServiceCatalogs = staff.ServiceCatalogs?.Select(x => new ServiceCatalog
            {
                Id = x.Id,
                Name = x.Name,
                Icon = x.Icon,
                CreatedDate = x.CreatedDate,
                UserIdCreated = x.UserIdCreated,
                IsActived = x.IsActived
            }).ToList() ?? new List<ServiceCatalog>();
            return Result.Ok(entity);
        }
    }
}