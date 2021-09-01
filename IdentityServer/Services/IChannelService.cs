using IdentityServer.DTOs;
using IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface IChannelService
    {
        ChannelDTO AddChannel(ChannelDTO addDTO);
        ChannelDTO EditChannel(ChannelDTO editDTO);
        PagedResult<ChannelDTO> GetChannels(int pageNumber, int pageSize);
        ChannelDTO GetChannelIdentitfiers(int channelId);
        PagedResult<ChannelDTO> SearchChannelBySerial(int? dropDownFilter, int? dropDownFilter2, string searchKey, int pageNumber, int pageSize);
        PagedResult<ChannelDTO> SearchSpecificChannelBySerial(string searchKey, int pageNumber, int pageSize);
        void DeleteChannel(int id);
        bool ChangeStatus(int id, int updatedBy);

    }
}
