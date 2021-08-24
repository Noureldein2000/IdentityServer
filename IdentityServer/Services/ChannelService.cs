using IdentityServer.Data.Entities;
using IdentityServer.DTOs;
using IdentityServer.Helpers;
using IdentityServer.Infrastructure;
using IdentityServer.Models;
using IdentityServer.Properties;
using IdentityServer.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
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
        private readonly IBaseRepository<AccountChannel, int> _accountChannel;
        private readonly IStringLocalizer<AuthenticationResource> _localizer;
        private readonly IUnitOfWork _unitOfWork;
        public ChannelService(IBaseRepository<Channel, int> channel,
            IBaseRepository<ChannelIdentifier, int> channelIdentifier,
            IBaseRepository<AccountChannel, int> accountChannel,
             IStringLocalizer<AuthenticationResource> localizer,
        IUnitOfWork unitOfWork)
        {
            _channel = channel;
            _channelIdentifier = channelIdentifier;
            _accountChannel = accountChannel;
            _localizer = localizer;
            _unitOfWork = unitOfWork;
        }

        public ChannelDTO AddChannel(ChannelDTO addDTO)
        {
            if (_channel.Any(c => c.Serial == addDTO.Serial))
                throw new OkException(_localizer["ThisChannelExistedBefore"].Value, ErrorCodes.Channel.SerialExists);

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

        public bool ChangeStatus(int id, int updatedBy)
        {
            var currentChannelIdentifier = _channelIdentifier.Getwhere(c => c.ChannelID == id).FirstOrDefault();
            currentChannelIdentifier.Status = !currentChannelIdentifier.Status;
            currentChannelIdentifier.UpdatedBy = updatedBy;
            _unitOfWork.SaveChanges();
            return true;
        }

        public void DeleteChannel(int id)
        {
            var currentChannelIdentifier = _channelIdentifier.Getwhere(ci => ci.ChannelID == id).FirstOrDefault();
            _channelIdentifier.Delete(currentChannelIdentifier.ID);

            var currentAccountChannel = _accountChannel.Getwhere(ac => ac.ChannelID == id).FirstOrDefault();
            _accountChannel.Delete(currentAccountChannel.ID);

            var deletedChannel = _channel.Delete(id);

            _unitOfWork.SaveChanges();
        }

        public ChannelDTO EditChannel(ChannelDTO editDTO)
        {
            var currentChannel = _channel.Getwhere(c => c.ID == editDTO.ChannelID).Include(c => c.ChannelIdentifiers).FirstOrDefault();

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

        public PagedResult<ChannelDTO> GetChannels(int pageNumber, int pageSize)
        {
            var channelsList = _channel.Getwhere(a => true).Select(c => new ChannelDTO
            {
                ChannelID = c.ID,
                Name = c.Name,
                Serial = c.Serial,
                ChannelTypeID = c.ChannelTypeID,
                ChannelTypeName=c.ChannelType.Name,
                ChannelOwnerID = c.ChannelOwnerID,
                ChannelOwnerName=c.ChannelOwner.Name,
                PaymentMethodID = c.PaymentMethodID,
                PaymentMethodName=c.ChannelPaymentMethod.Name,
                CreationDate = c.CreationDate,
                Status=c.ChannelIdentifiers.Status
            });

            var count = channelsList.Count();
            var resultList = channelsList.OrderByDescending(ar => ar.CreationDate)
            .Skip(pageNumber - 1).Take(pageSize)
            .ToList();

            return new PagedResult<ChannelDTO>
            {
                Results = resultList,
                PageCount = count
            };
        }

        public PagedResult<ChannelDTO> SearchChannelBySerial(string searchKey, int pageNumber, int pageSize)
        {
            var searchChannelList = _channel.Getwhere(c => c.Serial.Contains(searchKey)).Select(c => new ChannelDTO
            {
                ChannelID=c.ID,
                Name = c.Name,
                Serial = c.Serial,
                ChannelTypeID = c.ChannelTypeID,
                ChannelTypeName = c.ChannelType.Name,
                ChannelOwnerID = c.ChannelOwnerID,
                ChannelOwnerName = c.ChannelOwner.Name,
                PaymentMethodID = c.PaymentMethodID,
                PaymentMethodName = c.ChannelPaymentMethod.Name,
                CreationDate = c.CreationDate
            });

            var count = searchChannelList.Count();

            var resultList = searchChannelList.OrderByDescending(ar => ar.CreationDate)
           .Skip(pageNumber - 1).Take(pageSize)
           .ToList();

            return new PagedResult<ChannelDTO>
            {
                Results = resultList,
                PageCount = count
            };
        }


        #region Helper Method
        //Helper Method

        private ChannelDTO MapEntityToDto(Channel entityRequest) => new ChannelDTO
        {
            ChannelID = entityRequest.ID,
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
