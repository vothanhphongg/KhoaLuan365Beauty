using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Staffs.OccupationCatalogs
{
    public class CreateOccupationCatalogCommand : IRequest<Result<object>>
    {
        public string? Name { get; set; }
    }
}