using IdentityServer.Data.Entities;
using IdentityServer.DTOs;
using IdentityServer.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class ChannelTypeService : IChannelTypeService
    {
        private readonly IBaseRepository<ChannelType, int> _channelType;
        private readonly IUnitOfWork _unitOfWork;
        public ChannelTypeService(IBaseRepository<ChannelType, int> channelType, IUnitOfWork unitOfWork)
        {
            _channelType = channelType;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ChannelTypeDTO> GetByChannelCategoryId(int id)
        {
            return _channelType.Getwhere(ct => ct.ChannelCategoryID == id).Select(a => new ChannelTypeDTO
            {
                ID = a.ID,
                Name = a.Name,
                NameAr = a.ArName
            }).ToList();
        }

        public IEnumerable<ChannelTypeDTO> GetChannelTypes()
        {
            return _channelType.GetAll().Select(a => new ChannelTypeDTO
            {
                ID = a.ID,
                Name = a.Name,
                NameAr = a.ArName
            }).ToList();
        }
    }
}
