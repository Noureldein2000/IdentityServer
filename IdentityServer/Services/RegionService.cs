using IdentityServer.Data.Entities;
using IdentityServer.DTOs;
using IdentityServer.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class RegionService : IRegionService
    {
        private readonly IBaseRepository<Region, int> _region;
        private readonly IBaseRepository<Governorate, int> _governorate;
        private readonly IUnitOfWork _unitOfWork;
        public RegionService(IBaseRepository<Region, int> region,
          IBaseRepository<Governorate, int> governorate,
            IUnitOfWork unitOfWork)
        {
            _region = region;
            _governorate = governorate;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<RegionDTO> GetGovernorate()
        {
            return _governorate.GetAll().Select(g => new RegionDTO
            {
                ID = g.ID,
                Name = g.Name
            }).ToList();
        }

        public IEnumerable<RegionDTO> GetRegion(int governorateId)
        {
            return _region.Getwhere(r => r.GovernorateID == governorateId).Select(r => new RegionDTO()
            {
                ID = r.ID,
                Name = r.Name,
                GovernorateID = r.GovernorateID
            }).ToList();
        }

        #region Helper Method
        //Helper Method

        private AccountRequestDTO MapEntityToDto(AccountRequest entityRequest) => new AccountRequestDTO
        {
            Id = entityRequest.ID,
            OwnerName = entityRequest.OwnerName,
            AccountName = entityRequest.AccountName,
            Mobile = entityRequest.Mobile,
            Address = entityRequest.Address,
            Email = entityRequest.Email,
            NationalID = entityRequest.NationalID,
            CommercialRegistrationNo = entityRequest.CommercialRegistrationNo,
            TaxNo = entityRequest.TaxNo,
            ActivityID = entityRequest.ActivityID,
        };

        #endregion
    }
}
