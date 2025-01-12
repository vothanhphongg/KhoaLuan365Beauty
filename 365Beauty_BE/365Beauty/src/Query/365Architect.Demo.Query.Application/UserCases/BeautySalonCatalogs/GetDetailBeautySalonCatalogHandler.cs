using _365Beauty.Contract.Errors;
using _365Beauty.Contract.Exceptions;
using _365Beauty.Contract.Shared;
using _365Beauty.Domain.Abstractions.Repositories;
using _365Beauty.Domain.Entities;
using _365Beauty.Query.Application.Queries.BeautySalonCatalogs;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.BeautySalonCatalogs
{
    public class GetDetailBeautySalonCatalogHandler : IRequestHandler<GetDetailBeautySalonCatalogQuery, Result<BeautySalonCatalog>>
    {
        private readonly IBeautySalonCatalogRepository beautySalonCatalogRepository;

        public GetDetailBeautySalonCatalogHandler(IBeautySalonCatalogRepository beautySalonCatalogRepository)
        {
            this.beautySalonCatalogRepository = beautySalonCatalogRepository;
        }
        public async Task<Result<BeautySalonCatalog>> Handle(GetDetailBeautySalonCatalogQuery request, CancellationToken cancellationToken)
        {
            var entity = await beautySalonCatalogRepository.FindByIdAsync(request.Id);
            return Result.Ok(entity);
        }
    }
}