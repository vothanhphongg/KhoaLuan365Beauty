using _365Beauty.Command.Application.Commands.Staffs.StaffCatalogs;
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

        public CreateStaffCatalogHandler(IStaffCatalogRepository staffCatalogRepository)
        {
            this.staffCatalogRepository = staffCatalogRepository;
        }

        public async Task<Result<object>> Handle(CreateStaffCatalogCommand request, CancellationToken cancellationToken)
        {
            Validators(request);
            StaffCatalog? entity = new StaffCatalog
            {
                Code = request.Code,
                IdCard = request.IdCard!,
                FullName = request.FullName!,
                Gender = request.Gender! ?? 0,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth ?? new DateTime(2000, 01, 01),
                Tel = request.Tel,
                Introduction = request.Introduction,
                Img = request.Img,
                SalonId = request.SalonId,
                TitleId = request.TitleId,
                DegreeId = request.DegreeId,
                OccupationId = request.OccupationId,
                Address = request.Address,
                WardId = request.WardId! ?? "00001",
                IsActived = 1,
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
            validator.RuleFor(x => x.Email)!.Email().MaxLength(StaffCatalogConst.STAFF_CATALOG_EMAIL_MAX_LENGTH);
            validator.RuleFor(x => x.Tel)!.NotNullOrEmpty().MaxLength(StaffCatalogConst.STAFF_CATALOG_TEL_MAX_LENGTH);
            validator.RuleFor(x => x.Introduction)!.MaxLength(StaffCatalogConst.STAFF_CATALOG_INTRODUCTION_MAX_LENGTH);
            validator.RuleFor(x => x.Address)!.MaxLength(StaffCatalogConst.STAFF_CATALOG_ADDRESS_MAX_LENGTH);
            validator.Validate();
        }
    }
}