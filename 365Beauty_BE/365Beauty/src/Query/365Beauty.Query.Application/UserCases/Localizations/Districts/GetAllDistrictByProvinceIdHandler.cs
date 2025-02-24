using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.Localizations.Districts;
using _365Beauty.Query.Domain.Abstractions.Repositories.Localizations;
using _365Beauty.Query.Domain.Entities.Localizations;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Localizations.Districts
{
    public class GetAllDistrictByProvinceIdHandler : IRequestHandler<GetAllDistrictByProvinceIdQuery, Result<List<District>>>
    {
        private readonly IDistrictRepository districtRepository;

        public GetAllDistrictByProvinceIdHandler(IDistrictRepository districtRepository)
        {
            this.districtRepository = districtRepository;
        }

        public async Task<Result<List<District>>> Handle(GetAllDistrictByProvinceIdQuery request, CancellationToken cancellationToken)
        {
            var entity = districtRepository.FindAll(false, x => x.ProvinceId == request.ProvinceId).ToList();
            return await Task.FromResult(Result.Ok(entity));
        }
    }
}