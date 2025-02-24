using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.BeautySalons;
using _365Beauty.Query.Application.Queries.BeautySalons.BeautySalonCatalogs;
using _365Beauty.Query.Application.Queries.Localizations.Wards;
using _365Beauty.Query.Domain.Abstractions.Repositories.BeautySalons;
using MediatR;

namespace UserCases.BeautySalons.BeautySalonCatalogs
{
    public class GetAllBeautySalonCatalogHandler : IRequestHandler<GetAllBeautySalonCatalogsQuery, Result<List<BeautySalonCatalogWithLocalizationDTO>>>
    {
        private readonly IBeautySalonCatalogRepository beautySalonCatalogRepository;
        private readonly IMediator mediator;

        public GetAllBeautySalonCatalogHandler(IBeautySalonCatalogRepository beautySalonCatalogRepository, IMediator mediator)
        {
            this.beautySalonCatalogRepository = beautySalonCatalogRepository;
            this.mediator = mediator;
        }

        public async Task<Result<List<BeautySalonCatalogWithLocalizationDTO>>> Handle(GetAllBeautySalonCatalogsQuery request, CancellationToken cancellationToken)
        {
            var salons = beautySalonCatalogRepository.FindAll(false, x => x.IsActived == request.IsActived).ToList();

            var entities = new List<BeautySalonCatalogWithLocalizationDTO>();

            foreach (var salon in salons)
            {
                var wardResult = await mediator.Send(new GetDetailWardQuery { Id = salon.WardId! }, cancellationToken);
                var localization = wardResult.Data!;

                entities.Add(new BeautySalonCatalogWithLocalizationDTO
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
                    Address = salon.Address,
                    WardId = salon.WardId,
                    AddressFullAscending = $" {salon.Address}, {localization.NameAscending}",
                    IsActived = salon.IsActived,
                    Localization = localization,
                });
            }

            return Result.Ok(entities);
        }
    }
}