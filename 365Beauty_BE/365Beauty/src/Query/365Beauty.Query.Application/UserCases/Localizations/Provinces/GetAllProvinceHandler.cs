using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.Localizations.Provinces;
using _365Beauty.Query.Domain.Abstractions.Repositories.Localizations;
using _365Beauty.Query.Domain.Entities.Localizations;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Localizations.Provinces
{
    public class GetAllProvinceHandler : IRequestHandler<GetAllProvinceQuery, Result<List<Province>>>
    {
        private readonly IProvinceRepository provinceRepository;

        public GetAllProvinceHandler(IProvinceRepository provinceRepository)
        {
            this.provinceRepository = provinceRepository;
        }

        public async Task<Result<List<Province>>> Handle(GetAllProvinceQuery request, CancellationToken cancellationToken)
        {
            var entity = provinceRepository.FindAll().ToList();
            return await Task.FromResult(Result.Ok(entity));
        }
    }
}