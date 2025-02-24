using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Localizations;
using _365Beauty.Query.Application.Queries.Localizations.Wards;
using _365Beauty.Query.Domain.Abstractions.Repositories.Localizations;
using _365Beauty.Query.Domain.Entities.Localizations;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Localizations.Wards
{
    public class GetDetailWardHandler : IRequestHandler<GetDetailWardQuery, Result<LocalizationDTO>>
    {
        private readonly IWardRepository wardRepository;
        private readonly IDistrictRepository districtRepository;
        private readonly IProvinceRepository provinceRepository;

        public GetDetailWardHandler(IWardRepository wardRepository, IDistrictRepository districtRepository, IProvinceRepository provinceRepository)
        {
            this.wardRepository = wardRepository;
            this.districtRepository = districtRepository;
            this.provinceRepository = provinceRepository;
        }

        public async Task<Result<LocalizationDTO>> Handle(GetDetailWardQuery request, CancellationToken cancellationToken)
        {
            Ward ward = await wardRepository.FindByIdAsync(request.Id);
            District district = await districtRepository.FindByIdAsync(ward.DistrictId);
            Province province = await provinceRepository.FindByIdAsync(district.ProvinceId);
            LocalizationDTO localizationDTO = new LocalizationDTO();
            localizationDTO.WardId = ward.Id;
            localizationDTO.ProvinceId = province.Id;
            localizationDTO.WardName = ward.Name;
            localizationDTO.DistrictName = district.Name;
            localizationDTO.ProvinceName = province.Name;
            return Result.Ok(localizationDTO);
        }
    }
}