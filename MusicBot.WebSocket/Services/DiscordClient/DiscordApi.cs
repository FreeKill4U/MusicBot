using MusicBot.Core.Services.DiscordService.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBot.Core.Services.DiscordClient
{
    public class DiscordApi : IDiscordApi
    {
        private RestClient _rest;

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


            return true;
        }
    }
}
