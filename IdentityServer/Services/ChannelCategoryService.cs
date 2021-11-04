using IdentityServer.Data.Entities;
using IdentityServer.DTOs;
using IdentityServer.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class ChannelCategoryService : IChannelCategoryService
    {
        private readonly IBaseRepository<ChannelCategory, int> _channelCategory;
        private readonly IUnitOfWork _unitOfWork;
        public ChannelCategoryService(IBaseRepository<ChannelCategory, int> channelCategory, IUnitOfWork unitOfWork)
        {
            _channelCategory = channelCategory;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ChannelCategoryDTO> GetChannelCategories()
        {
            return _channelCategory.GetAll().Select(c => new ChannelCategoryDTO
            {
                Id = c.ID,
                Name = c.Name,
                NameAr = c.ArName
            }).ToList();

        }
    }
}
