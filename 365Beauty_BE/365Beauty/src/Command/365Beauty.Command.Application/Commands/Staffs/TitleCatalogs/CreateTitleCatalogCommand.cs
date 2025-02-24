using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Staffs.TitleCatalogs
{
    public class CreateTitleCatalogCommand : IRequest<Result<object>>
    {
        public string? Name { get; set; }
    }
}