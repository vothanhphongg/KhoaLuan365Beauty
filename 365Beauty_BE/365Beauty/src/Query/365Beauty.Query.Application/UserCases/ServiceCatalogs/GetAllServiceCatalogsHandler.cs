using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.ServiceCatalogs;
using _365Beauty.Query.Domain.Abstractions.Repositories.Services;
using _365Beauty.Query.Domain.Entities.Services;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.ServiceCatalogs
{
    public class GetAllServiceCatalogsHandler : IRequestHandler<GetAllServiceCatalogsQuery, Result<List<ServiceCatalog>>>
    {
        private readonly IServiceCatalogRepository beautySalonServiceRepository;

        public GetAllServiceCatalogsHandler(IServiceCatalogRepository beautySalonServiceRepository)
        {
            this.beautySalonServiceRepository = beautySalonServiceRepository;
        }

        public async Task<Result<List<ServiceCatalog>>> Handle(GetAllServiceCatalogsQuery request, CancellationToken cancellationToken)
        {
            var entity = beautySalonServiceRepository.FindAll(false, x => x.IsActived == request.IsActived).ToList();
            return await Task.FromResult(Result.Ok(entity));
        }
    }
}