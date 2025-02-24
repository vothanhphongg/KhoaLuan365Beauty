using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.BeautySalons.BeautySalonCatalogs
{
    public class LockOrUnLockBeautySalonCatalogCommand : IRequest<Result<object>>
    {
        public int Id { get; set; }
    }
}