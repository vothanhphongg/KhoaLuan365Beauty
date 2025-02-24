using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Staffs.DegreeCatalogs
{
    public class CreateDegreeCatalogCommand : IRequest<Result<object>>
    {
        public string? Name { get; set; }
    }
}