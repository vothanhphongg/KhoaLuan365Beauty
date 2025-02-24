using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Services.ServiceCatalogs
{
    public class UpdateServiceCatalogCommand : IRequest<Result<object>>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
    }
}