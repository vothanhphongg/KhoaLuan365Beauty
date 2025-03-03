using _365Beauty.Contract.Enumerations;
using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.BeautySalons;
using _365Beauty.Query.Application.DTOs.Staffs;
using _365Beauty.Query.Application.Queries.Localizations.Wards;
using _365Beauty.Query.ApplicationQueries.BeautySalons.BeautySalonCatalogs;
using _365Beauty.Query.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Query.Domain.Entities.BeautySalons;
using MediatR;

namespace UserCases.BeautySalons.BeautySalonCatalogs
{
    public class GetDetailBeautySalonCatalogHandler : IRequestHandler<GetDetailBeautySalonCatalogQuery, Result<BeautySalonCatalogFullDTO>>
    {
        private readonly IBeautySalonCatalogRepository beautySalonCatalogRepository;
        private readonly IBeautySalonServiceRepository beautySalonServiceRepository;
        private readonly IMediator mediator;

        public GetDetailBeautySalonCatalogHandler(IBeautySalonCatalogRepository beautySalonCatalogRepository, IBeautySalonServiceRepository beautySalonServiceRepository, IMediator mediator)
        {
            this.beautySalonCatalogRepository = beautySalonCatalogRepository;
            this.beautySalonServiceRepository = beautySalonServiceRepository;
            this.mediator = mediator;
        }
        public async Task<Result<BeautySalonCatalogFullDTO>> Handle(GetDetailBeautySalonCatalogQuery request, CancellationToken cancellationToken)
        {
            var salon = await beautySalonCatalogRepository.FindByIdAsync(request.Id, false, true, cancellationToken, x => x.StaffCatalogs, x => x.BeautySalonImages);
            var service = beautySalonServiceRepository.FindAll(false, x => x.SalonId == salon.Id && x.IsActived == StatusActived.Actived, x => x.Price).Where(x => x.Price != null).ToList();
            var wardResult = await mediator.Send(new GetDetailWardQuery { Id = salon.WardId! }, cancellationToken);

            var entity = new BeautySalonCatalogFullDTO
            {
                Id = salon.Id,
                Code = salon.Code,
                Name = salon.Name,
                Description = salon.Description,
                Email = salon.Email,
                Website = salon.Website,
                Tel = salon.Tel,
                Image = salon.Image,
                WorkingDate = salon.WorkingDate,
                AddressFullAscending = $" {salon.Address}, {wardResult.Data.NameAscending}",
                BeautySalonServices = service.Select(x => new BeautySalonServiceWithPriceDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    BasePrice = x.Price.BasePrice,
                    FinalPrice = x.Price.FinalPrice,
                    PrecentDiscount = (int)Math.Round((x.Price.BasePrice - x.Price.FinalPrice) / x.Price.BasePrice * 100)

                }).ToList(),
                StaffCatalogs = salon.StaffCatalogs.Select(x => new StaffCatalogSimpleDTO
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Img = x.Img
                }).ToList(),
                BeautySalonImages = salon.BeautySalonImages?.Select(x => new BeautySalonImage
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                }).ToList(),
            };
            return Result.Ok(entity!);
        }
    }
}