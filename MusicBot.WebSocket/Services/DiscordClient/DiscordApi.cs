using MusicBot.Core.Services.DiscordService.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websocket.Client;

namespace MusicBot.Core.Services.DiscordClient
{
    public class DiscordApi : IDiscordApi
    {
        private readonly RestClient _rest;

        public DiscordApi()
        {
            _rest = new RestClient(AppConstant.DiscordUrl);
        }
        public async Task<List<Channel>> GetChannels(string channelId)
        {
            var request = new RestRequest($"/guilds/{channelId}/channels", Method.Get);
            request.AddHeader("Authorization", "Bot "+AppConstant.DiscordToken);
            var response = await _rest.ExecuteAsync(request);
            if (!response.IsSuccessful)
                throw new Exception("Failed to download channels");

            var channels = JsonConvert.DeserializeObject<List<Channel>>(response.Content);

            return channels;
        }

        public async Task<bool> SendMessege(string content, string channelId)
        {
            var request = new RestRequest($"/channels/{channelId}/messages", Method.Post);
            request.AddHeader("Authorization", "Bot " + AppConstant.DiscordToken);
            var body = new
            {
                content = content
            };

            var json = JsonConvert.SerializeObject(body);

            request.AddJsonBody(body);
            var response = await _rest.ExecuteAsync(request);
            if (!response.IsSuccessful)
                throw new Exception("Failed to send messege");

            var channels = JsonConvert.DeserializeObject<List<Channel>>(response.Content);

            return true;
        }

        public async Task<List<Member>> GetUsers(string guildId)
        {
            var request = new RestRequest($"/guilds/{guildId}/members", Method.Get);
            request.AddHeader("Authorization", "Bot " + AppConstant.DiscordToken);
            request.AddParameter("limit", 1000);

            var response = await _rest.ExecuteAsync(request);
            if (!response.IsSuccessful)
                throw new Exception("Failed to send messege");



            var channels = JsonConvert.DeserializeObject<List<Channel>>(response.Content);

            var members = JsonConvert.DeserializeObject<List<Member>>(response.Content);
            return members;
        }

        public async void Join(string channelId, string guildId)
        {

            var join = new
            {
                op = 4,
                d = new
                {
                    guild_id = guildId,
                    channel_id = channelId,
                    self_mute = true,
                    self_deaf = true
                }
            };
            DiscordService.Client.Send(JsonConvert.SerializeObject(join));
        }
    }
}
