using Microsoft.Extensions.Logging;
using MusicBot.Core.Database;
using MusicBot.Core.Services.DiscordClient.Models;
using MusicBot.Core.Services.DiscordClient.Models.Request;
using MusicBot.Core.Services.DiscordService;
using MusicBot.WebSocket;
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
    public class DiscordService
    {
        private readonly RestClient _rest;
        public static WebsocketClient Client;
        private readonly IResponseService _service;
        private readonly ApplicationDbContext _context;
        private ILogger log;

        public DiscordService(ApplicationDbContext context, IResponseService service, ILogger<DiscordService> logger)
        {
            _context = context;
            _rest = new RestClient(AppConstant.DiscordUrl);
            Client = new WebsocketClient(new Uri("wss://gateway.discord.gg?v=9&encoding=json"));
            _service = service;
            log = logger;
        }

        public async void Connect()
        {
            try
            {
                _context.Users.ToList().ForEach(u => u.ChannelId = null);
                _context.SaveChanges();

                Writter.Init();
                var exitEvent = new ManualResetEvent(false);

                Client.ReconnectTimeout = TimeSpan.FromSeconds(30);
                Client.ReconnectionHappened.Subscribe(info =>
                    Writter.Warning($"Reconnection happened, type: {info.Type}"));


                Client.MessageReceived.Subscribe(msg => {

                    _service.ReadResponse(msg);
                });

                Client.Start();


                var startTimeSpan = TimeSpan.Zero;
                var periodTimeSpan = TimeSpan.FromMilliseconds(41250 / 2);

                var timer = new System.Threading.Timer((e) =>
                {
                    Client.Send("{\"op\": 1, \"d\": 11}");
                    
                    Writter.Warning("Heartbeat!");
                }, null, startTimeSpan, periodTimeSpan);

                Identify();


                exitEvent.WaitOne();


            }
            catch (Exception ex)
            {
                Writter.Warning($"Something goes wrong: {ex.Message}");
            }
        }

        public async void Identify()
        {
            var identify = new IdentifyPayload()
            {
                Op = 2,
                Data = new IdentifyPayloadData()
                {
                    Intents = 98303,
                    Token = AppConstant.DiscordToken,
                    Properties = new Properties()
                    {
                        Os = "linux",
                        Browser = "my_library",
                        Device = "my_library"
                    }
                }
            };

            Client.SendPayload(identify);
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
        public static void SendPayload(this WebsocketClient client, Payload payload)
        {
            client.Send(JsonConvert.SerializeObject(payload));
        }
    }
}
