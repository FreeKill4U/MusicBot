using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MusicBot.Core.Database;
using System.Linq;
using MusicBot.Core.Services.DiscordClient;
using System.Threading;
using Newtonsoft.Json;
using System.Net.WebSockets;
using Websocket.Client;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace MusicBot
{
    public class Function1
    {
        private readonly ApplicationDbContext _context;
        private readonly IDiscordService _discord;

        private string streaming_API_Key = "your_api_key";

        public Function1(ApplicationDbContext context, IDiscordService discord)
        {
            _context = context;
            _discord = discord;
        } 

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                var exitEvent = new ManualResetEvent(false);

                var client = new WebsocketClient(new Uri("wss://gateway.discord.gg?v=9&encoding=json"));

                client.ReconnectTimeout = TimeSpan.FromSeconds(30);
                client.ReconnectionHappened.Subscribe(info =>
                    log.LogWarning($"Reconnection happened, type: {info.Type}"));


                client.MessageReceived.Subscribe(msg => {
                    log.LogWarning($"Message received: {msg}");

                    var block = JsonConvert.DeserializeObject<Opcode10Hello>(msg.Text);

                    if(block.S == null)
                    {
                        var heart = new Heartbeat()
                        {
                            Op = 1,
                            D = null
                        };

                        //client.Send(JsonConvert.SerializeObject(heart));
                    }
                });

                client.Start();

               /* var body = new Identify()
                {
                    Op = 7,
                    D = null
                };



                var body2 = new
                {
                    op = 2,
                    d = new
                    {
                        token = "OTU3NjY3NjQzMDA2MDAxMTky.YkCHfg.V5z1wZGJD_KYUU6Su4xXTNAYNiM",
                        intents = 1,
                        properties = new {
                            os = "linux",
                            browser = "my_library",
                            device = "my_library"
                        }
                    }
                };*/

                var body = new Identify()
                {
                    Op
                }

                client.Send(JsonConvert.SerializeObject(body));

                //Task.Run(() => client.Send("{ message }"));

                exitEvent.WaitOne();

                
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
            }
            return new OkResult();
        }

    }

    public class Properties
    {
        [JsonProperty("$os")]
        public string Os { get; set; }

        [JsonProperty("$browser")]
        public string Browser { get; set; }

        [JsonProperty("$device")]
        public string Device { get; set; }
    }

    public class Activity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }
    }

    public class Presence
    {
        [JsonProperty("activities")]
        public List<Activity> Activities { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("since")]
        public int Since { get; set; }

        [JsonProperty("afk")]
        public bool Afk { get; set; }
    }

    public class IdentifyData
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }

        [JsonProperty("compress")]
        public bool Compress { get; set; }

        [JsonProperty("large_threshold")]
        public int LargeThreshold { get; set; }

        [JsonProperty("shard")]
        public List<int> Shard { get; set; }

        [JsonProperty("presence")]
        public Presence Presence { get; set; }

        [JsonProperty("intents")]
        public int Intents { get; set; }
    }

    public class Identify
    {
        [JsonProperty("op")]
        public int Op { get; set; }

        [JsonProperty("d")]
        public IdentifyData D { get; set; }
    }












    public class Heartbeat
    {
        [JsonProperty("op")]
        public int Op { get; set; }

        [JsonProperty("d")]
        public int? D { get; set; }
    }



















    public class Opcode10HelloData
{
        [JsonProperty("heartbeat_interval")]
        public int HeartbeatInterval { get; set; }

        [JsonProperty("_trace")]
        public List<string> Trace { get; set; }
    }

    public class Opcode10Hello
    {
        [JsonProperty("t")]
        public object T { get; set; }

        [JsonProperty("s")]
        public object S { get; set; }

        [JsonProperty("op")]
        public int Op { get; set; }

        [JsonProperty("d")]
        public Opcode10HelloData D { get; set; }
    }
}
