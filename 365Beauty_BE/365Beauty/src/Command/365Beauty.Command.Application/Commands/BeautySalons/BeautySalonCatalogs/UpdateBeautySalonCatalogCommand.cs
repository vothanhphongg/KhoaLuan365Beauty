using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.BeautySalons.BeautySalonCatalogs
{
    public class UpdateBeautySalonCatalogCommand : IRequest<Result<object>>
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? Tel { get; set; }
        public string? Image { get; set; }
        public string? WorkingDate { get; set; }
        public string? Address { get; set; }
        public string? WardId { get; set; }
        public int? UserIdUpdated { get; set; }
    }
}