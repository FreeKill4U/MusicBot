using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websocket.Client;

namespace MusicBot.Core.Services.DiscordService
{
    public interface IResponseService
    {
        void ReadResponse(ResponseMessage msg);
    }
}
