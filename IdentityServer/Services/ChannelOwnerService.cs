using IdentityServer.Data.Entities;
using IdentityServer.DTOs;
using IdentityServer.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class ChannelOwnerService : IChannelOwnerService
    {
        private readonly IBaseRepository<ChannelOwner, int> _channelOwner;
        private readonly IUnitOfWork _unitOfWork;
        public ChannelOwnerService(IBaseRepository<ChannelOwner, int> channelOwner, IUnitOfWork unitOfWork)
        {
            _channelOwner = channelOwner;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<ChannelOwnerDTO> GetChannelOwners()
        {
            return _channelOwner.GetAll().Select(a => new ChannelOwnerDTO()
            {
                ID = a.ID,
                Name = a.Name,
                NameAr = a.ArName
            }).ToList();
        }
    }
}
