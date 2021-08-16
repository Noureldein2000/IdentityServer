using IdentityServer.DTOs;
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
        IEnumerable<ChannelDTO> GetChannels(int pageNumber, int pageSize);
        ChannelDTO GetChannelIdentitfiers(int channelId);
        IEnumerable<ChannelDTO> SearchChannelBySerial(string searchKey, int pageNumber, int pageSize);
        void DeleteChannel(int id);

    }
}
