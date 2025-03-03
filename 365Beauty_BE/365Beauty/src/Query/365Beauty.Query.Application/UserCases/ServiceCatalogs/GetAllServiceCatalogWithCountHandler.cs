using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Services;
using _365Beauty.Query.Application.Queries.ServiceCatalogs;
using _365Beauty.Query.Domain.Abstractions.Repositories.Services;
using MediatR;
using System.Text;

namespace _365Beauty.Query.Application.UserCases.ServiceCatalogs
{
    public class GetAllServiceCatalogWithCountHandler : IRequestHandler<GetAllServiceCatalogWithCountQuery, Result<List<ServiceCatalogWithCount>>>
    {
        private readonly IServiceCatalogRepository serviceCatalogRepository;

        public GetAllServiceCatalogWithCountHandler(IServiceCatalogRepository serviceCatalogRepository)
        {
            this.serviceCatalogRepository = serviceCatalogRepository;
        }
        public async Task<Result<List<ServiceCatalogWithCount>>> Handle(GetAllServiceCatalogWithCountQuery request, CancellationToken cancellationToken)
        {
            var services = serviceCatalogRepository.FindAll().ToList();
            var entities = services.Select(x => new ServiceCatalogWithCount
            {
                Id = x.Id,
                Name = x.Name,
                Count = RandomOtp()
            }).ToList();
            return await Task.FromResult(Result.Ok(entities));
        }
        private int RandomOtp()
        {
            var random = new Random();
            return random.Next(100, 1000);
        }
    }
}
