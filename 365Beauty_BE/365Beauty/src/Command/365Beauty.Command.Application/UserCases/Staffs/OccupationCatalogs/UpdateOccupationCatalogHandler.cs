using _365Beauty.Command.Application.Commands.Staffs.OccupationCatalogs;
using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Constants.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Staffs.OccupationCatalogs
{
    public class UpdateOccupationCatalogHandler : IRequestHandler<UpdateOccupationCatalogCommand, Result<object>>
    {
        private readonly IOccupationCatalogRepository occupationCatalogRepository;

        public UpdateOccupationCatalogHandler(IOccupationCatalogRepository occupationCatalogRepository)
        {
            this.occupationCatalogRepository = occupationCatalogRepository;
        }
        public async Task<Result<object>> Handle(UpdateOccupationCatalogCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            using var transaction = await occupationCatalogRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                OccupationCatalog? entity = await occupationCatalogRepository.FindByIdAsync(request.Id);
                entity!.Update(request.Name);
                occupationCatalogRepository.Update(entity);
                await occupationCatalogRepository.SaveChangesAsync(cancellationToken);
                transaction.Commit();
                return Result.Ok();
            }
            catch (Exception)
            {
                // Rollback transaction
                transaction.Rollback();
                throw;
            }

        }
        private void Validators(UpdateOccupationCatalogCommand request)
        {
            var validator = Validator.Create(request);
            validator.RuleFor(x => x.Name).MaxLength(OccupationCatalogConst.OCCUPATION_NAME_MAX_LENGTH);
            validator.Validate();
        }
    }
}