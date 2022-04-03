﻿using Microsoft.EntityFrameworkCore;
using MusicBot.Core.Database;
using MusicBot.Core.Services.DiscordClient;
using MusicBot.Core.Services.DiscordService.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websocket.Client;

namespace MusicBot.Core.Services.DiscordService
{
    public class ResponseService : IResponseService
    {
        private Statistics _statistic = new Statistics();
        private readonly IDiscordApi _api;
        public ResponseService(IDiscordApi api)
        {
            _api = api;
        }
        public void ReadResponse(ResponseMessage msg)
        {
            var response = JsonConvert.DeserializeObject<Response>(msg.Text);

            if (response == null)
                throw new Exception("Something goes wrong!");

            if(response.Op == 0)
            {
                if(response.Command == "READY") Task.Run(() => ready(msg.Text));
                //if(response.Command == "GUILD_CREATE") Task.Run(() => guildCreate(msg.Text));
                if(response.Command == "GUILD_CREATE") guildCreate(msg.Text);
            }
            
        }
        private void ready(string msg)
        {
            var data = JsonConvert.DeserializeObject<ReadyResponse>(msg)?.Data;

            var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());

            var guilds = context.Guilds.ToList();

            if(data.Guilds != null && data.Guilds.Count > 0)
            {
                data.Guilds
                .Where(r => !guilds.Select(r => r.ExternalId).ToList().Contains(r.Id))
                .ToList()
                .ForEach(guild =>
                {
                    var newGuild = new GuildEntity()
                    {
                        ExternalId = guild.Id,
                        Is_complete = false
                    };
                    context.Guilds.Add(newGuild);
                });
            }
            if(data.User != null)
            {
                _statistic.Bot = data.User;
            }

            context.SaveChanges();
            _statistic.IsReady = true;
        }
        private async void guildCreate(string msg)
        {

            var data = JsonConvert.DeserializeObject<GuildCreateResponse>(msg).Data;

            var channels = await _api.GetChannels(data.Id);
            var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());


            var guild = context.Guilds
                .Include(r => r.Channels)
                .FirstOrDefault(r => r.ExternalId == data.Id);
            
            if(guild == null && true)
            {
                guild = new GuildEntity()
                {
                    ExternalId = data.Id,
                    Name = data.Name,
                    Icon = data.Icon,
                    Channels = new List<ChannelEntity>()
                };
                
                foreach(var channel in data.Channels)
                {
                    guild.Channels.Add(new ChannelEntity()
                    {
                        ExternalId = channel.Id,
                        Name = channel.Name,
                        Type = channel.Type
                    });
                }
            }
            else
            {
                if(guild.Name != data.Name) guild.Name = data.Name;
                if(guild.Icon != data.Icon) guild.Icon = data.Icon;

                foreach(var channel in data.Channels)
                {
                    var channelDb = guild.Channels.FirstOrDefault(r => r.ExternalId == channel.Id);
                    if(channelDb == null)
                    {
                        channelDb = new ChannelEntity()
                        {
                            ExternalId = channel.Id,
                            Name = channel.Name,
                            Type = channel.Type
                        };
                        guild.Channels.Add(channelDb);
                    }
                    else
                    {
                        if (channelDb.Name != channel.Name) channelDb.Name = channel.Name;
                        if (channelDb.Type != channel.Type) channelDb.Type = channel.Type;
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
