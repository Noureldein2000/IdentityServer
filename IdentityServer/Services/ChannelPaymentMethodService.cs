using IdentityServer.Data.Entities;
using IdentityServer.DTOs;
using IdentityServer.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class ChannelPaymentMethodService : IChannelPaymentMethodService
    {
        private readonly IBaseRepository<ChannelPaymentMethod, int> _channelPaymentMethod;
        private readonly IUnitOfWork _unitOfWork;
        public ChannelPaymentMethodService(IBaseRepository<ChannelPaymentMethod, int> channelPaymentMethod, IUnitOfWork unitOfWork)
        {
            _channelPaymentMethod = channelPaymentMethod;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<ChannelPaymentMethodDTO> GetChannelPaymentMethods()
        {
            return _channelPaymentMethod.GetAll().Select(a => new ChannelPaymentMethodDTO()
            {
                ID = a.ID,
                Name = a.Name,
                NameAr = a.ArName
            }).ToList();
           
        }
    }
}
