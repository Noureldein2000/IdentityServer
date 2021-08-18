using IdentityServer.Data.Entities;
using IdentityServer.DTOs;
using IdentityServer.Helpers;
using IdentityServer.Infrastructure;
using IdentityServer.Properties;
using IdentityServer.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class ChannelService : IChannelService
    {
        private readonly IBaseRepository<Channel, int> _channel;
        private readonly IBaseRepository<ChannelIdentifier, int> _channelIdentifier;
        private readonly IUnitOfWork _unitOfWork;
        public ChannelService(IBaseRepository<Channel, int> channel,
            IBaseRepository<ChannelIdentifier, int> channelIdentifier,
            IUnitOfWork unitOfWork)
        {
            _channel = channel;
            _channelIdentifier = channelIdentifier;
            _unitOfWork = unitOfWork;
        }

        public ChannelDTO AddChannel(ChannelDTO addDTO)
        {
            if (_channel.Any(c => c.Serial == addDTO.Serial))
                throw new OkException(Resources.ThisChannelExistedBefore, ErrorCodes.Channel.SerialExists);

            var addedEntity = _channel.Add(new Channel()
            {
                Name = addDTO.Name,
                Serial = addDTO.Serial,
                ChannelTypeID = addDTO.ChannelTypeID,
                ChannelOwnerID = addDTO.ChannelOwnerID,
                PaymentMethodID = addDTO.PaymentMethodID,
                ChannelIdentifiers = new ChannelIdentifier
                {
                    Status = addDTO.Status,
                    Value = addDTO.Value,
                    CreatedBy = addDTO.CreatedBy
                }
            });

            _unitOfWork.SaveChanges();

            return MapEntityToDto(addedEntity);
        }

        public void DeleteChannel(int id)
        {
            var deletedChannel = _channel.Delete(id);
            var currentChannelIdentifier = _channelIdentifier.Getwhere(ci => ci.ChannelID == deletedChannel.ID).FirstOrDefault();
            _channelIdentifier.Delete(currentChannelIdentifier.ID);
            _unitOfWork.SaveChanges();
        }

        public ChannelDTO EditChannel(ChannelDTO editDTO)
        {
            var currentChannel = _channel.Getwhere(c => c.ID == editDTO.ChannelID).Include(c=>c.ChannelIdentifiers).FirstOrDefault();

            currentChannel.Name = editDTO.Name;
            currentChannel.Serial = editDTO.Serial;
            currentChannel.ChannelTypeID = editDTO.ChannelTypeID;
            currentChannel.ChannelOwnerID = editDTO.ChannelOwnerID;
            currentChannel.PaymentMethodID = editDTO.PaymentMethodID;

            currentChannel.ChannelIdentifiers.Value = editDTO.Value;
            currentChannel.ChannelIdentifiers.UpdatedBy = editDTO.UpdatedBy;
            _unitOfWork.SaveChanges();

            return MapEntityToDto(currentChannel);
        }

        public ChannelDTO GetChannelIdentitfiers(int channelId)
        {
            var currentChannelDetails = _channel.Getwhere(c => c.ID == channelId).Include(c => c.ChannelIdentifiers).FirstOrDefault();
            return MapEntityToDto(currentChannelDetails);
        }

        public IEnumerable<ChannelDTO> GetChannels(int pageNumber, int pageSize)
        {
            return _channel.GetAll().Select(c => new ChannelDTO
            {
                Name = c.Name,
                Serial = c.Serial,
                ChannelTypeID = c.ChannelTypeID,
                ChannelOwnerID = c.ChannelOwnerID,
                PaymentMethodID = c.PaymentMethodID,
                CreationDate = c.CreationDate
            }).OrderByDescending(c => c.CreationDate).Skip(pageNumber - 1).Take(pageSize).ToList();
        }

        public IEnumerable<ChannelDTO> SearchChannelBySerial(string searchKey, int pageNumber, int pageSize)
        {
            return _channel.GetAll().Where(c => c.Serial.Contains(searchKey)).Select(c => new ChannelDTO
            {
                Name = c.Name,
                Serial = c.Serial,
                ChannelTypeID = c.ChannelTypeID,
                ChannelOwnerID = c.ChannelOwnerID,
                PaymentMethodID = c.PaymentMethodID,
                CreationDate = c.CreationDate
            }).OrderByDescending(c => c.CreationDate).Skip(pageNumber - 1).Take(pageSize).ToList();
        }


        #region Helper Method
        //Helper Method

        private ChannelDTO MapEntityToDto(Channel entityRequest) => new ChannelDTO
        {
            Name = entityRequest.Name,
            Serial = entityRequest.Serial,
            ChannelTypeID = entityRequest.ChannelTypeID,
            ChannelOwnerID = entityRequest.ChannelOwnerID,
            PaymentMethodID = entityRequest.PaymentMethodID,
            Status = entityRequest.ChannelIdentifiers.Status,
            Value = entityRequest.ChannelIdentifiers.Value,
            CreatedBy = entityRequest.ChannelIdentifiers.CreatedBy,
            CreationDate = entityRequest.CreationDate
        };

        #endregion
    }
}
