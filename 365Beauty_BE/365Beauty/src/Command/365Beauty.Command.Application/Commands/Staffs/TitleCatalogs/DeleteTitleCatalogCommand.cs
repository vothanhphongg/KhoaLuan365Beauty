using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Staffs.TitleCatalogs
{
    public class DeleteTitleCatalogCommand : IRequest<Result<object>>
    {
        public int Id { get; set; }
    }
}