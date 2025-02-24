using _365Beauty.Command.Application.Commands.Staffs.DegreeCatalogs;
using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Constants.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Staffs.DegreeCatalogs
{
    public class UpdateDegreeCatalogHandler : IRequestHandler<UpdateDegreeCatalogCommand, Result<object>>
    {
        private readonly IDegreeCatalogRepository degreeCatalogRepository;

        public UpdateDegreeCatalogHandler(IDegreeCatalogRepository degreeCatalogRepository)
        {
            this.degreeCatalogRepository = degreeCatalogRepository;
        }
        public async Task<Result<object>> Handle(UpdateDegreeCatalogCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            using var transaction = await degreeCatalogRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                DegreeCatalog? entity = await degreeCatalogRepository.FindByIdAsync(request.Id);
                entity.Update(request.Name);
                degreeCatalogRepository.Update(entity);
                await degreeCatalogRepository.SaveChangesAsync(cancellationToken);
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
        private void Validators(UpdateDegreeCatalogCommand request)
        {
            var validator = Validator.Create(request);
            validator.RuleFor(x => x.Name).MaxLength(DegreeCatalogConst.DEGREE_NAME_MAX_LENGTH);
            validator.Validate();
        }
    }
}