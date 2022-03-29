using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using MusicBot.Core.Services.DiscordClient.Models;
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
    public class DiscordService : IDiscordService
    {
        private readonly RestClient _rest;
        private readonly DiscordSocketClient _client;
        private ILogger log;

        public DiscordService()
        {
            _rest = new RestClient(AppConstant.DiscordUrl);
            _client = new DiscordSocketClient();
        }

        public async void Connect(Func<object> func)
        {
            try
            {
                var exitEvent = new ManualResetEvent(false);

                var client = new WebsocketClient(new Uri("wss://gateway.discord.gg?v=9&encoding=json"));

                client.ReconnectTimeout = TimeSpan.FromSeconds(30);
                client.ReconnectionHappened.Subscribe(info =>
                    log.LogWarning($"Reconnection happened, type: {info.Type}"));


                client.MessageReceived.Subscribe(msg => {
                    log.LogWarning($"{msg}");
                });

                client.Start();

                var startTimeSpan = TimeSpan.Zero;
                var periodTimeSpan = TimeSpan.FromMinutes(5);

                var timer = new System.Threading.Timer((e) =>
                {
                    client.Send("{\"op\"}");
                }, null, startTimeSpan, periodTimeSpan);


                exitEvent.WaitOne();


            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
            }
        }

        public async Task<List<Guild>> GetGuilds()
        {
            var request = new DiscordRequest()
            {
                Resource = "/v6/users/@me/guilds",
                HttpMethod = Method.Get
            }.CreateRequest();

            var x =_client.GetGuild(595353831919845407);

            var response = await _rest.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception("Nie udało się pobrać gildii");

            var responseModel = JsonConvert.DeserializeObject<List<Guild>>(response.Content);
            return responseModel;
        }

        public void UseLogger(ILogger logger)
        {
            log = logger;
        }


    }
    public class DiscordRequest
    {
        public string Resource { get; set; }
        public Method HttpMethod { get; set; }
        public object? Body { get; set; }
    }
    public static class DiscordExtension
    {
        public static RestRequest CreateRequest(this DiscordRequest request)
        {
            var restRequest = new RestRequest(new Uri(request.Resource, UriKind.Relative), request.HttpMethod);
            restRequest.AddHeader("Authorization", "Bot " + AppConstant.DiscordToken);

            if(request.Body != null)
                restRequest.AddJsonBody(request.Body);

            return restRequest;
        }
    }
}
