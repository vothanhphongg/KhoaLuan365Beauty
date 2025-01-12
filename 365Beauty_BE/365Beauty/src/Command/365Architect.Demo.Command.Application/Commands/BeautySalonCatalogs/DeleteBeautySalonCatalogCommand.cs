using _365Beauty.Contract.Shared;
using _365Beauty.Domain.Entities;
using MediatR;

namespace _365Beauty.Command.Application.Commands.BeautySalonCatalogs
{
    public class DeleteBeautySalonCatalogCommand : IRequest<Result<BeautySalonCatalog>>
    {
        public int Id { get; set; }
    }
}