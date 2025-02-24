using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.Localizations.Provinces;
using _365Beauty.Query.Domain.Abstractions.Repositories.Localizations;
using _365Beauty.Query.Domain.Entities.Localizations;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Localizations.Provinces
{
    public class GetDetailProvinceHandler : IRequestHandler<GetDetailProvinceQuery, Result<Province>>
    {
        private readonly IProvinceRepository provinceRepository;

        public GetDetailProvinceHandler(IProvinceRepository provinceRepository)
        {
            this.provinceRepository = provinceRepository;
        }

        public async Task<Result<Province>> Handle(GetDetailProvinceQuery request, CancellationToken cancellationToken)
        {
            var entity = await provinceRepository.FindByIdAsync(request.Id, false, true, cancellationToken, includeProperties: x => x.Districts);
            return Result.Ok(entity);
        }
    }
}