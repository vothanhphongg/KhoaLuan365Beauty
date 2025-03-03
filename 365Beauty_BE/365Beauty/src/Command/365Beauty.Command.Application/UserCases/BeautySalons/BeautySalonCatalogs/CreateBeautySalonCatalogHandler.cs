using _365Beauty.Command.Application.Commands.BeautySalons.BeautySalonCatalogs;
using _365Beauty.Command.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Command.Domain.Constants.BeautySalons;
using _365Beauty.Command.Domain.Entities.BeautySalons;
using _365Beauty.Contract.Constants;
using _365Beauty.Contract.Exceptions;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using MediatR;


namespace _365Beauty.Command.Application.UserCases.BeautySalons.BeautySalonCatalogs
{
    public class CreateBeautySalonCatalogHandler : IRequestHandler<CreateBeautySalonCatalogCommand, Result<object>>
    {
        private readonly IBeautySalonCatalogRepository beautySalonCatalogRepository;

        public CreateBeautySalonCatalogHandler(IBeautySalonCatalogRepository beautySalonCatalogRepository)
        {
            this.beautySalonCatalogRepository = beautySalonCatalogRepository;
        }
        public async Task<Result<object>> Handle(CreateBeautySalonCatalogCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            var salonExist = await beautySalonCatalogRepository.IsExist(x => x.Code == request.Code);
            if (salonExist)
                throw new ConflictException(MessConst.PROPERTY_ALREADY_EXIST.FormatMsg(request.Code));

            BeautySalonCatalog entity = new BeautySalonCatalog
            {
                Code = request.Code,
                Name = request.Name!,
                Description = request.Description,
                Email = request.Email,
                Website = request.Website,
                Tel = request.Tel!,
                Image = request.Image! ?? Image.DEFAULT_IMAGE,
                WorkingDate = request.WorkingDate,
                Address = request.Address,
                WardId = request.WardId! ?? "00001",
                UserIdCreated = (int)request.UserIdCreated!,
                CreatedDate = DateTime.UtcNow,
                IsActived = 1,
            };
            entity.BeautySalonImages = request.BeautySalonImages?.Distinct().Select(service => new BeautySalonImage
            {
                SalonId = entity.Id,
                ImageUrl = service.ImageUrl,

            }).ToList();
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
            validator.RuleFor(x => x.Email).Email().MaxLength(BeautySalonCatalogConst.SLN_EMAIL_MAX_LENGTH);
            validator.RuleFor(x => x.Website).MaxLength(BeautySalonCatalogConst.SLN_WEBSITE_MAX_LENGTH);
            validator.RuleFor(x => x.Tel).NotNullOrEmpty().MaxLength(BeautySalonCatalogConst.SLN_TEL_MAX_LENGTH);
            validator.RuleFor(x => x.WorkingDate).NotNullOrEmpty().MaxLength(BeautySalonCatalogConst.SLN_WORKING_DATE_MAX_LENGTH);
            validator.RuleFor(x => x.Address).MaxLength(BeautySalonCatalogConst.SLN_ADDRESS_MAX_LENGTH);
            validator.Validate();
        }
    }
}