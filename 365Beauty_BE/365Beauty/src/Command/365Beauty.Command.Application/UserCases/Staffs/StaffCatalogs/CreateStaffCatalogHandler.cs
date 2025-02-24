using _365Beauty.Command.Application.Commands.Staffs.StaffCatalogs;
using _365Beauty.Command.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Command.Domain.Abstractions.Repositories.Localizations;
using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Constants.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using MediatR;
using System.Data;

namespace _365Beauty.Command.Application.UserCases.Staffs.StaffCatalogs
{
    public class CreateStaffCatalogHandler : IRequestHandler<CreateStaffCatalogCommand, Result<object>>
    {
        private readonly IStaffCatalogRepository staffCatalogRepository;
        private readonly IBeautySalonCatalogRepository beautySalonCatalogRepository;
        private readonly IDegreeCatalogRepository degreeCatalogRepository;
        private readonly ITitleCatalogRepository titleCatalogRepository;
        private readonly IOccupationCatalogRepository occupationCatalogRepository;
        private readonly IWardRepository wardRepository;

        public CreateStaffCatalogHandler(IStaffCatalogRepository staffCatalogRepository,
                                         IBeautySalonCatalogRepository beautySalonCatalogRepository,
                                         IDegreeCatalogRepository degreeCatalogRepository,
                                         ITitleCatalogRepository titleCatalogRepository,
                                         IOccupationCatalogRepository occupationCatalogRepository,
                                         IWardRepository wardRepository)
        {
            this.staffCatalogRepository = staffCatalogRepository;
            this.beautySalonCatalogRepository = beautySalonCatalogRepository;
            this.degreeCatalogRepository = degreeCatalogRepository;
            this.titleCatalogRepository = titleCatalogRepository;
            this.occupationCatalogRepository = occupationCatalogRepository;
            this.wardRepository = wardRepository;
        }

        public async Task<Result<object>> Handle(CreateStaffCatalogCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            await CheckForeignKeyToStaffCatalog(request.DegreeId, request.TitleId, request.OccupationId, request.SalonId, request.WardId);
            StaffCatalog? entity = new StaffCatalog
            {
                Code = request.Code,
                IdCard = request.IdCard!,
                FullName = request.FullName!,
                Gender = (int)request.Gender!,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                Tel = request.Tel,
                TelOther = request.TelOther,
                Introduction = request.Introduction,
                Content = request.Content,
                Img = request.Img,
                SalonId = request.SalonId,
                TitleId = request.TitleId,
                DegreeId = request.DegreeId,
                OccupationId = request.OccupationId,
                Address = request.Address,
                WardId = request.WardId,
                UserIdUpdated = (int)request.UserIdUpdated!,
                IsActived = 1,
                CreatedDate = DateTime.UtcNow,
            };

            entity.StaffServices = request.Services?.Distinct().Select(service => new StaffService
            {
                StaffId = entity.Id,
                ServiceId = service.ServiceId

            }).ToList();
            using var transaction = await staffCatalogRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                staffCatalogRepository.Add(entity);
                await staffCatalogRepository.SaveChangesAsync(cancellationToken);
                transaction.Commit();
                return Result.Ok();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        private void Validators(CreateStaffCatalogCommand request)
        {
            var validator = Validator.Create(request);
            validator.RuleFor(x => x.Code)!.MaxLength(StaffCatalogConst.STAFF_CATALOG_CODE_MAX_LENGTH);
            validator.RuleFor(x => x.IdCard).NotNullOrEmpty().MaxLength(StaffCatalogConst.STAFF_CATALOG_ID_CARD_MAX_LENGTH);
            validator.RuleFor(x => x.FullName).NotNullOrEmpty().MaxLength(StaffCatalogConst.STAFF_CATALOG_FULLNAME_MAX_LENGTH);
            validator.RuleFor(x => x.Gender).NotNull();
            validator.RuleFor(x => x.Email)!.Email().MaxLength(StaffCatalogConst.STAFF_CATALOG_EMAIL_MAX_LENGTH);
            validator.RuleFor(x => x.Tel)!.NotNull().NotNullOrEmpty().MaxLength(StaffCatalogConst.STAFF_CATALOG_TEL_MAX_LENGTH);
            validator.RuleFor(x => x.TelOther)!.MaxLength(StaffCatalogConst.STAFF_CATALOG_TEL_OTHER_MAX_LENGTH);
            validator.RuleFor(x => x.Introduction)!.MaxLength(StaffCatalogConst.STAFF_CATALOG_INTRODUCTION_MAX_LENGTH);
            validator.RuleFor(x => x.Img)!.NotNullOrEmpty();
            validator.RuleFor(x => x.Address)!.MaxLength(StaffCatalogConst.STAFF_CATALOG_ADDRESS_MAX_LENGTH);
            validator.Validate();
        }

        private async Task CheckForeignKeyToStaffCatalog(int? degreeId, int? titleId, int? occupationId, int salonId, string wardId)
        {
            if (titleId is not null)
                await titleCatalogRepository.FindByIdAsync((int)titleId);
            if (degreeId is not null)
                await degreeCatalogRepository.FindByIdAsync((int)degreeId);
            if (occupationId is not null)
                await occupationCatalogRepository.FindByIdAsync((int)occupationId);
            await beautySalonCatalogRepository.FindByIdAsync(salonId);
            await wardRepository.FindByIdAsync(wardId);
        }
    }
}