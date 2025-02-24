using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.Localizations.Districts;
using _365Beauty.Query.Domain.Abstractions.Repositories.Localizations;
using _365Beauty.Query.Domain.Entities.Localizations;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Localizations.Districts
{
    public class GetDetailDistrictHandler : IRequestHandler<GetDetailDistrictQuery, Result<District>>
    {
        private readonly IDistrictRepository districtRepository;

        public GetDetailDistrictHandler(IDistrictRepository districtRepository)
        {
            this.districtRepository = districtRepository;
        }

        public async Task<Result<District>> Handle(GetDetailDistrictQuery request, CancellationToken cancellationToken)
        {
            var entity = await districtRepository.FindByIdAsync(request.Id, false, true, cancellationToken, includeProperties: x => x.Wards);
            return Result.Ok(entity);
        }
    }
}