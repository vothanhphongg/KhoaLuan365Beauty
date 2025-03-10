using _365Beauty.Command.Application.Commands.BeautySalons.BeautySalonCatalogs;
using _365Beauty.Command.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Command.Domain.Constants.BeautySalons;
using _365Beauty.Command.Domain.Entities.BeautySalons;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.BeautySalons.BeautySalonCatalogs
{
    public class UpdateBeautySalonCatalogHandler : IRequestHandler<UpdateBeautySalonCatalogCommand, Result<object>>
    {
        private readonly IBeautySalonCatalogRepository beautySalonCatalogRepository;

        public UpdateBeautySalonCatalogHandler(IBeautySalonCatalogRepository beautySalonCatalogRepository)
        {
            this.beautySalonCatalogRepository = beautySalonCatalogRepository;
        }

        public async Task<Result<object>> Handle(UpdateBeautySalonCatalogCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            using var transaction = await beautySalonCatalogRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                var entity = await beautySalonCatalogRepository.FindByIdAsync(request.Id);
                entity!.UpdatedDate = DateTime.UtcNow;
                entity.Update(request.Code, request.Name, request.Description, request.Email, request.Website,
                              request.Tel, request.Image!, request.WorkingDate, request.Address, request.WardId, request.UserIdUpdated);
                entity.BeautySalonImages = request.BeautySalonImages?.Distinct().Select(service => new BeautySalonImage
                {
                    SalonId = entity.Id,
                    ImageUrl = service.ImageUrl,
                }).ToList() ?? entity.BeautySalonImages;
                beautySalonCatalogRepository.Update(entity);
                await beautySalonCatalogRepository.SaveChangesAsync(cancellationToken);
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
        private void Validators(UpdateBeautySalonCatalogCommand request)
        {
            var validator = Validator.Create(request);
            validator.RuleFor(x => x.Code).MaxLength(BeautySalonCatalogConst.SLN_CODE_MAX_LENGTH);
            validator.RuleFor(x => x.Name).MaxLength(BeautySalonCatalogConst.SLN_NAME_MAX_LENGTH);
            validator.RuleFor(x => x.Description);
            validator.RuleFor(x => x.Email).MaxLength(BeautySalonCatalogConst.SLN_EMAIL_MAX_LENGTH);
            validator.RuleFor(x => x.Website).MaxLength(BeautySalonCatalogConst.SLN_WEBSITE_MAX_LENGTH);
            validator.RuleFor(x => x.Tel).MaxLength(BeautySalonCatalogConst.SLN_TEL_MAX_LENGTH);
            validator.RuleFor(x => x.Image).MaxLength(BeautySalonCatalogConst.SLN_IMAGE_MAX_LENGTH);
            validator.RuleFor(x => x.WorkingDate).MaxLength(BeautySalonCatalogConst.SLN_WORKING_DATE_MAX_LENGTH);
            validator.RuleFor(x => x.Address).MaxLength(BeautySalonCatalogConst.SLN_ADDRESS_MAX_LENGTH);
            validator.Validate();
        }
    }
}