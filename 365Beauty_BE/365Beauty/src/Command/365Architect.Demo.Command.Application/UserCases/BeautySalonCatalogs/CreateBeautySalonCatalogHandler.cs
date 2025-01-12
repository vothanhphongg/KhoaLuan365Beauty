using _365Beauty.Command.Application.Commands.BeautySalonCatalogs;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using _365Beauty.Domain.Abstractions.Repositories;
using _365Beauty.Domain.Constants;
using _365Beauty.Domain.Entities;
using MediatR;


namespace _365Beauty.Command.Application.UserCases.BeautySalonCatalogs
{
    public class CreateBeautySalonCatalogHandler : IRequestHandler<CreateBeautySalonCatalogCommand, Result<BeautySalonCatalog>>
    {
        private readonly IBeautySalonCatalogRepository beautySalonCatalogRepository;

        public CreateBeautySalonCatalogHandler(IBeautySalonCatalogRepository beautySalonCatalogRepository)
        {
            this.beautySalonCatalogRepository = beautySalonCatalogRepository;
        }
        public async Task<Result<BeautySalonCatalog>> Handle(CreateBeautySalonCatalogCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            BeautySalonCatalog entity = new BeautySalonCatalog
            {
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                Content = request.Content,
                Email = request.Email,
                Website = request.Website,
                Tel = request.Tel,
                Image = request.Image,
                WorkingDate = request.WorkingDate,
                Address = request.Address,
                WardId = (int)request.WardId,
                CreatedDate = DateTime.UtcNow,
                IsActived = 0
            };
            using var transaction = await beautySalonCatalogRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                beautySalonCatalogRepository.Add(entity);
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

        private void Validators(CreateBeautySalonCatalogCommand request)
        {
            var validator = Validator.Create(request);
            validator.RuleFor(x => x.Code).MaxLength(BeautySalonCatalogConst.SLN_CODE_MAX_LENGTH);
            validator.RuleFor(x => x.Name).NotNullOrEmpty().MaxLength(BeautySalonCatalogConst.SLN_NAME_MAX_LENGTH);
            validator.RuleFor(x => x.Description).MaxLength(BeautySalonCatalogConst.SLN_DESCRIPTION_MAX_LENGTH);
            validator.RuleFor(x => x.Email).MaxLength(BeautySalonCatalogConst.SLN_EMAIL_MAX_LENGTH);
            validator.RuleFor(x => x.Website).MaxLength(BeautySalonCatalogConst.SLN_WEBSITE_MAX_LENGTH);
            validator.RuleFor(x => x.Tel).NotNullOrEmpty().MaxLength(BeautySalonCatalogConst.SLN_TEL_MAX_LENGTH);
            validator.RuleFor(x => x.Image).NotNullOrEmpty().MaxLength(BeautySalonCatalogConst.SLN_IMAGE_MAX_LENGTH);
            validator.RuleFor(x => x.WorkingDate).MaxLength(BeautySalonCatalogConst.SLN_WORKING_DATE_MAX_LENGTH);
            validator.RuleFor(x => x.Address).MaxLength(BeautySalonCatalogConst.SLN_ADDRESS_MAX_LENGTH);
            validator.Validate();
        }
    }
}