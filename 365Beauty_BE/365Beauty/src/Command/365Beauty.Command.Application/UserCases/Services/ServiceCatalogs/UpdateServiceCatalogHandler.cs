using _365Beauty.Command.Application.Commands.Services.ServiceCatalogs;
using _365Beauty.Command.Domain.Abstractions.Repositories.Services;
using _365Beauty.Command.Domain.Constants.Services;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using MediatR;

namespace UserCases.Services.ServiceCatalogs
{
    public class UpdateServiceCatalogHandler : IRequestHandler<UpdateServiceCatalogCommand, Result<object>>
    {
        private readonly IServiceCatalogRepository serviceCategoryRepository;

        public UpdateServiceCatalogHandler(IServiceCatalogRepository serviceCategoryRepository)
        {
            this.serviceCategoryRepository = serviceCategoryRepository;
        }
        public async Task<Result<object>> Handle(UpdateServiceCatalogCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            using var transaction = await serviceCategoryRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                var entity = await serviceCategoryRepository.FindByIdAsync(request.Id);
                entity!.Update(request.Name, request.Icon);
                serviceCategoryRepository.Update(entity);
                await serviceCategoryRepository.SaveChangesAsync(cancellationToken);
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

        private void Validators(UpdateServiceCatalogCommand request)
        {
            var validator = Validator.Create(request);
            validator.RuleFor(x => x.Id).NotNull();
            validator.RuleFor(x => x.Name).MaxLength(ServiceCatalogConst.SER_NAME_MAX_LENGTH);
            validator.RuleFor(x => x.Icon).MaxLength(ServiceCatalogConst.SER_ICON_MAX_LENGTH);
            validator.Validate();
        }
    }
}