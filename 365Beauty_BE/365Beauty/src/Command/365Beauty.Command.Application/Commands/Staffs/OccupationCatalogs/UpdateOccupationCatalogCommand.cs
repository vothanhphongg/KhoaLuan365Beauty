using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Staffs.OccupationCatalogs
{
    public class UpdateOccupationCatalogCommand : IRequest<Result<object>>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}