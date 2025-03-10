using _365Beauty.Contract.Enumerations;
using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.BeautySalons;
using _365Beauty.Query.Application.Queries.BeautySalons.BeautySalonServices;
using _365Beauty.Query.Application.Queries.Localizations.Wards;
using _365Beauty.Query.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Query.Domain.Abstractions.Repositories.Users;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.BeautySalons.BeautySalonServices
{
    public class GetDetailBeautySalonServiceHandler : IRequestHandler<GetDetailBeautySalonServiceQuery, Result<BeautySalonServiceFullDTO>>
    {
        private readonly IBeautySalonServiceRepository beautySalonServiceRepository;
        private readonly IMediator mediator;

        public GetDetailBeautySalonServiceHandler(IBeautySalonServiceRepository beautySalonServiceRepository, 
                                                  IMediator mediator)
        {
            this.beautySalonServiceRepository = beautySalonServiceRepository;
            this.mediator = mediator;
        }
        public async Task<Result<BeautySalonServiceFullDTO>> Handle(GetDetailBeautySalonServiceQuery request, CancellationToken cancellationToken)
        {
            var salonService = beautySalonServiceRepository
                .FindAll(false, x=> x.Id == request.Id, x => x.Price!, x => x.SalonCatalog!, x => x.ServiceCatalog!)
                .Where(x => x.Price != null && x.Price.IsActived == StatusActived.Actived)
                .FirstOrDefault();
                        
            var wardResult = await mediator.Send(new GetDetailWardQuery { Id = salonService.SalonCatalog.WardId! }, cancellationToken);

            var entity = new BeautySalonServiceFullDTO
            {
                Id = salonService.Id,
                SalonId = salonService.SalonId,
                Name = salonService.Name,
                Description = salonService.Description!,
                Image = salonService.Image,
                BasePrice = salonService.Price?.BasePrice ?? 0,
                FinalPrice = salonService.Price?.FinalPrice ?? 0,
                PrecentDiscount = (salonService.Price != null && salonService.Price.BasePrice > 0)
                    ? (int)Math.Round((salonService.Price.BasePrice - salonService.Price.FinalPrice) / salonService.Price.BasePrice * 100)
                    : 0,
                SerName = salonService.ServiceCatalog.Name,
                SlnName = salonService.SalonCatalog.Name,
                AddressFullAscending = $"{salonService.SalonCatalog.Address}, {wardResult.Data.NameAscending}",
                SlnImage = salonService.SalonCatalog.Image
            };
            return Result.Ok(entity!);
        }
    }
}