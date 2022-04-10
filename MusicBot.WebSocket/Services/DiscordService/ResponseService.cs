using Microsoft.EntityFrameworkCore;
using MusicBot.Core.Database;
using MusicBot.Core.Services.DiscordClient;
using MusicBot.Core.Services.DiscordService.Models;
using MusicBot.WebSocket;
using MusicBot.WebSocket.Services.DiscordService.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Websocket.Client;
using MusicBot.WebSocket.Database;

namespace MusicBot.Core.Services.DiscordService
{
    public class ResponseService : IResponseService
    {
        private Statistics _statistic = new Statistics();
        private readonly IDiscordApi _api;

        private string msg;

        private Task guildCreateTask = new Task(() => {});
        private Task readyTask;
        private Task messageCreateTask;


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
                if (response.Command == "READY") ready(msg.Text);
                else if (response.Command == "GUILD_CREATE")
                {
                    Task.Run(() =>
                    {
                        while (guildCreateTask.Status != TaskStatus.Created) { }

                        guildCreateTask = new Task(() => guildCreate(msg.Text));
                        guildCreateTask.Start();
                    });
                }
                else if (response.Command == "MESSAGE_CREATE") Task.Run(() => messegeCreate(msg.Text));
                else if (response.Command == "VOICE_STATE_UPDATE") Task.Run(() => voiceStateUpdate(msg.Text));
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
            Writter.Error($"{_statistic.Bot.Username} is ready to work!");
        }
        private async void guildCreate(string msg)
        {

            var data = JsonConvert.DeserializeObject<GuildCreateResponse>(msg)?.Data;

            var channels = await _api.GetChannels(data.Id);
            var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());


            var guild = context.Guilds
                .Include(r => r.Channels)
                .FirstOrDefault(r => r.ExternalId == data.Id);

            var users = await _api.GetUsers(data.Id);
            var usersDB = context.Users.Where(r => data.Members.Select(x => x.User.Id).Contains(r.ExternalId)).ToList();

            var usersDoesntExistsInDB = new List<UserEntity>();

            foreach(var user in users.Where(r => !usersDB.Select(x => x.ExternalId).Contains(r.User.Id)).ToList())
            {
                usersDoesntExistsInDB.Add(new UserEntity()
                {
                    ExternalId = user.User.Id,
                    Name = user.User.Username,
                    ChannelId = data.VoiceStates.FirstOrDefault(r => r.UserId == user.User.Id)?.ChannelId
                });
                Writter.Info($"User {user.User.Username} [{user.User.Id}] has been added to the database");
            }

            context.Users.AddRange(usersDoesntExistsInDB);


            foreach(var voiceState in data.VoiceStates)
            {
                var user = usersDB.FirstOrDefault(r => r.ExternalId == voiceState.UserId);
                if(user != null)
                    user.ChannelId = voiceState.ChannelId;
            }


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

            try
            {
                context.SaveChanges();
            }
            catch(Exception ex)
            {

            }
            
            Writter.Info($"{AppConstant.BotName} has been added to the guild \"{guild.Name}\"[{guild.ExternalId}]");
            guildCreateTask = new Task(() => { });
        }
        private void messegeCreate(string msg)
        {
            var data = JsonConvert.DeserializeObject<MessegeCreateResponse>(msg)?.Data;

            var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());

            var guilds = context.Guilds
                            .Include(r => r.Channels)
                            .ToList();
            if (guilds.Count < 0)
                throw new Exception($"{_statistic.Bot.Username} cant get guilds from database!");

            if (Regex.IsMatch(data.Content, @"^\/[a-zA-Z]* "))
            {
                var match = Regex.Match(data.Content, @"^\/[a-zA-Z]* ");
                if(match == null) return;

                var commend = Regex.Replace(match.Value, @"\/| ", "");

                if(commend == "p") _api.SendMessege(Regex.Replace(data.Content, @"^\/[a-zA-Z]* ", ""), data.ChannelId);
                if(commend == "join")
                {
                    guilds.FirstOrDefault();
                    //_api.Join(data.ChannelId);
                }

                Writter.Info($"{_statistic.Bot.Username} answer {data.Author.Username} in channel [{data.ChannelId}]!");
            }
        }
        private void voiceStateUpdate(string msg)
        {


            var data = JsonConvert.DeserializeObject<VoiceStateResponse>(msg)?.Data;
            
            var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());

            var user = context.Users.FirstOrDefault(x => x.ExternalId == data.UserId);

            user.ChannelId = data.ChannelId;

            Writter.Info($"User {user.Name} [{user.ExternalId}] change channel to [{data.ChannelId}]!");

            context.SaveChanges();
        }
    }
}
