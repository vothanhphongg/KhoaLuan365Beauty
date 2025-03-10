using _365Beauty.Command.Application.Commands.Services;
using _365Beauty.Command.Domain.Abstractions.Repositories.Services;
using _365Beauty.Command.Domain.Constants.Services;
using _365Beauty.Command.Domain.Entities.Services;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Services.ServiceCatalogs
{
    public class CreateServiceCatalogHandler : IRequestHandler<CreateServiceCatalogCommand, Result<object>>
    {
        private readonly IServiceCatalogRepository serviceCategoryRepository;

        public CreateServiceCatalogHandler(IServiceCatalogRepository serviceCategoryRepository)
        {
            this.serviceCategoryRepository = serviceCategoryRepository;
        }
        public async Task<Result<object>> Handle(CreateServiceCatalogCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            ServiceCatalog entity = new ServiceCatalog
            {
                Name = request.Name,
                Icon = request.Icon,
                UserIdCreated = request.UserIdCreated,
                CreatedDate = DateTime.UtcNow,
                IsActived = 1
            };

            using var transaction = await serviceCategoryRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                serviceCategoryRepository.Add(entity);
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

        private void Validators(CreateServiceCatalogCommand request)
        {
            var validator = Validator.Create(request);
            validator.RuleFor(x => x.Name).NotNullOrEmpty().MaxLength(ServiceCatalogConst.SER_NAME_MAX_LENGTH);
            validator.RuleFor(x => x.Icon).NotNullOrEmpty().MaxLength(ServiceCatalogConst.SER_ICON_MAX_LENGTH);
            validator.RuleFor(x => x.UserIdCreated).NotNull();
            validator.Validate();
        }
    }
}