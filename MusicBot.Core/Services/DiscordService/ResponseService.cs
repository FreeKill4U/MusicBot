using MusicBot.Core.Database;
using MusicBot.Core.Services.DiscordService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websocket.Client;

namespace MusicBot.Core.Services.DiscordService
{
    public class ResponseService
    {
        private readonly ApplicationDbContext _context;
        public ResponseService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void ReadResponse(ResponseMessage msg)
        {
            var response = JsonConvert.DeserializeObject<Response>(msg.Text);

            if (response == null)
                throw new Exception("Something goes wrong!");

            if(response.Op == 0)
            {
                if(response.Command == "READY") ready(msg.Text);
            }
            
        }
        private void ready(string msg)
        {
            var data = JsonConvert.DeserializeObject<ReadyResponse>(msg)?.Data;

            var guilds = _context.Guilds.ToList();

            data.Guilds
                .Where(r => guilds.Select(r => r.Id).ToList().Contains(r.Id))
                .ToList()
                .ForEach(guild =>
                {
                    var newGuild = new GuildEntity()
                    {
                        Id = guild.Id
                    };
                    guilds.Add(guild);
                });
            _context.SaveChanges();
        }
    }
}
