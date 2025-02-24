using _365Beauty.Command.Application.DTOs;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Services.ServiceCatalogs
{
    public class CreateServiceCatalogCommand : IRequest<Result<object>>
    {
        public string Name { get; set; }
        public string? Icon { get; set; }
        public int UserIdCreated { get; set; }
    }
}