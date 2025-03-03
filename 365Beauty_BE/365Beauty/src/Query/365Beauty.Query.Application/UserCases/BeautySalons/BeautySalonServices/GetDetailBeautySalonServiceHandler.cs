using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.BeautySalons;
using _365Beauty.Query.Application.Queries.BeautySalons.BeautySalonServices;
using _365Beauty.Query.Application.Queries.Localizations.Wards;
using _365Beauty.Query.Domain.Abstractions.Repositories.BeautySalons;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.BeautySalons.BeautySalonServices
{
    public class GetDetailBeautySalonServiceHandler : IRequestHandler<GetDetailBeautySalonServiceQuery, Result<BeautySalonServiceFullDTO>>
    {
        private readonly IBeautySalonServiceRepository beautySalonServiceRepository;
        private readonly IMediator mediator;

        public GetDetailBeautySalonServiceHandler(IBeautySalonServiceRepository beautySalonServiceRepository, IMediator mediator)
        {
            this.beautySalonServiceRepository = beautySalonServiceRepository;
            this.mediator = mediator;
        }
        public async Task<Result<BeautySalonServiceFullDTO>> Handle(GetDetailBeautySalonServiceQuery request, CancellationToken cancellationToken)
        {
            var salonService = await beautySalonServiceRepository.FindByIdAsync(request.Id, false, true, cancellationToken, x => x.Price!, x => x.SalonCatalog!, x => x.ServiceCatalog!);

            var wardResult = await mediator.Send(new GetDetailWardQuery { Id = salonService.SalonCatalog.WardId! }, cancellationToken);

            var entity = new BeautySalonServiceFullDTO
            {
                Id = salonService.Id,
                SalonId = salonService.SalonId,
                Name = salonService.Name,
                Description = salonService.Description!,
                Image = salonService.Image,
                BasePrice = salonService.Price.BasePrice,
                FinalPrice = salonService.Price.FinalPrice,
                PrecentDiscount = (int)Math.Round((salonService.Price.BasePrice - salonService.Price.FinalPrice) / salonService.Price.BasePrice * 100),
                SerName = salonService.ServiceCatalog.Name,
                SlnName = salonService.SalonCatalog.Name,
                AddressFullAscending = $" {salonService.SalonCatalog.Address}, {wardResult.Data.NameAscending}",
                SlnImage = salonService.SalonCatalog.Image,
            };
            return Result.Ok(entity!);
        }
    }
}
