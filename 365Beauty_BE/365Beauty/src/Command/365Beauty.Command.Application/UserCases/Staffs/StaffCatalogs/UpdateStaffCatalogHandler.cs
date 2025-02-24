using _365Beauty.Command.Application.Commands.Staffs.StaffCatalogs;
using _365Beauty.Command.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Command.Domain.Abstractions.Repositories.Localizations;
using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Constants.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;
using _365Beauty.Contract.Shared;
using _365Beauty.Contract.Validators;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Staffs.StaffCatalogs
{
    /// <summary>
    /// Handler for update staffCatalog request
    /// </summary>
    public class UpdateStaffCatalogHandler : IRequestHandler<UpdateStaffCatalogCommand, Result<object>>
    {
        private readonly IStaffCatalogRepository staffCatalogRepository;
        private readonly IBeautySalonCatalogRepository beautySalonCatalogRepository;
        private readonly IDegreeCatalogRepository degreeCatalogRepository;
        private readonly ITitleCatalogRepository titleCatalogRepository;
        private readonly IOccupationCatalogRepository occupationCatalogRepository;
        private readonly IWardRepository wardRepository;

        public UpdateStaffCatalogHandler(IStaffCatalogRepository staffCatalogRepository,
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

        /// <summary>
        /// Handle update staffCatalog request
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Result with staffCatalog data</returns>
        public async Task<Result<object>> Handle(UpdateStaffCatalogCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            await CheckForeignKeyToStaffCatalog(request.DegreeId, request.TitleId, request.OccupationId, (int)request.SalonId!, request.WardId);

            using var transaction = await staffCatalogRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                StaffCatalog? entity = await staffCatalogRepository.FindByIdAsync(request.Id!, true, true, cancellationToken, x => x.StaffServices!);


                entity.Update(request.Code, request.IdCard, request.FullName, request.Gender, request.DateOfBirth, request.Email, request.Tel, request.TelOther, 
                              request.Introduction, request.Content, request.Img, request.DegreeId, request.TitleId, request.OccupationId, request.Address, request.WardId, request.IsActived);


                entity.StaffServices = request.Services?.Distinct().Select(service => new StaffService
                {
                    StaffId = entity.Id,
                    ServiceId = service.ServiceId

                }).ToList() ?? entity.StaffServices;
                staffCatalogRepository.Update(entity);

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

        private void Validators(UpdateStaffCatalogCommand request)
        {
            var validator = Validator.Create(request);
            validator.RuleFor(x => x.Code)!.MaxLength(StaffCatalogConst.STAFF_CATALOG_CODE_MAX_LENGTH);
            validator.RuleFor(x => x.IdCard).MaxLength(StaffCatalogConst.STAFF_CATALOG_ID_CARD_MAX_LENGTH);
            validator.RuleFor(x => x.FullName).MaxLength(StaffCatalogConst.STAFF_CATALOG_FULLNAME_MAX_LENGTH);
            validator.RuleFor(x => x.Email)!.Email().MaxLength(StaffCatalogConst.STAFF_CATALOG_EMAIL_MAX_LENGTH);
            validator.RuleFor(x => x.Tel)!.MaxLength(StaffCatalogConst.STAFF_CATALOG_TEL_MAX_LENGTH);
            validator.RuleFor(x => x.TelOther)!.MaxLength(StaffCatalogConst.STAFF_CATALOG_TEL_OTHER_MAX_LENGTH);
            validator.RuleFor(x => x.Introduction)!.MaxLength(StaffCatalogConst.STAFF_CATALOG_INTRODUCTION_MAX_LENGTH);
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