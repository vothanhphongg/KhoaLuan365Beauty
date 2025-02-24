using _365Beauty.Command.Application.Commands.Staffs.OccupationCatalogs;
using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Constants.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Staffs.OccupationCatalogs
{
    public class CreateOccupationCatalogHandler : IRequestHandler<CreateOccupationCatalogCommand, Result<object>>
    {
        private readonly IOccupationCatalogRepository occupationCatalogRepository;

        public CreateOccupationCatalogHandler(IOccupationCatalogRepository occupationCatalogRepository)
        {
            this.occupationCatalogRepository = occupationCatalogRepository;
        }
        public async Task<Result<object>> Handle(CreateOccupationCatalogCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            OccupationCatalog entity = new OccupationCatalog
            {
                Name = request.Name!
            };
            using var transaction = await occupationCatalogRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                occupationCatalogRepository.Add(entity);
                await occupationCatalogRepository.SaveChangesAsync(cancellationToken);
                transaction.Commit();
                return Result.Ok();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        private void Validators(CreateOccupationCatalogCommand request)
        {
            var validator = Validator.Create(request);
            validator.RuleFor(x => x.Name).NotNullOrEmpty().MaxLength(OccupationCatalogConst.OCCUPATION_NAME_MAX_LENGTH);
            validator.Validate();
        }
    }
}