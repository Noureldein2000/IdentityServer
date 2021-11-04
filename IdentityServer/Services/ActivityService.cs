using IdentityServer.Data.Entities;
using IdentityServer.DTOs;
using IdentityServer.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IBaseRepository<Activity, int> _actitvity;
        private readonly IUnitOfWork _unitOfWork;
        public ActivityService(IBaseRepository<Activity, int> actitvity, IUnitOfWork unitOfWork)
        {
            _actitvity = actitvity;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<ActivityDTO> GetActivities()
        {
            return _actitvity.GetAll().Select(a => new ActivityDTO
            {
                ID = a.ID,
                Name = a.Name,
                NameAr = a.NameAr
            }).ToList();
        }
    }
}
