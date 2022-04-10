using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBot.WebSocket
{
    public static class Writter
    {
        private static List<Messege> _messeges = null;
        private static bool work;
        public static void Debug(string content)
        {
            var date = DateTime.Now;
            _messeges.Add(new Messege($"[{date.ToString("H-mm-ss")}] " + content, ConsoleColor.White));
        }
        public static void Info(string content)
        {
            var date = DateTime.Now;
            Console.Write(" ");
            _messeges.Add(new Messege($"[{date.ToString("H-mm-ss")}] " + content, ConsoleColor.Cyan));
        }
        public static void Warning(string content)
        {
            var date = DateTime.Now;
            Console.Write(" ");
            _messeges.Add(new Messege($"[{date.ToString("H-mm-ss")}] " + content, ConsoleColor.Yellow));
        }
        public static void Error(string content)
        {
            var date = DateTime.Now;
            Console.Write(" ");
            _messeges.Add(new Messege($"[{date.ToString("H-mm-ss")}] " + content, ConsoleColor.Red));
        }
        public static void Critical(string content)
        {
            var date = DateTime.Now;
            Console.Write(" ");
            _messeges.Add(new Messege($"[{date.ToString("H-mm-ss")}] " + content, ConsoleColor.Magenta));
        }

        public static void Init()
        {
            _messeges = new List<Messege>();
            Task.Run(() => {
                //Thread.Sleep(5000);
                while (true)
                {
                    Thread.Sleep(10);
                    var item = _messeges.FirstOrDefault();
                    if (item != null)
                    {
                        Console.ForegroundColor = item.color;
                        Console.WriteLine(item.messege);
                        _messeges.Remove(item);
                    }
                }
            });
        }
    }

    internal class Messege
    {
        public string messege { get; set; }
        public ConsoleColor color { get; set; }
        public Messege(string messege, ConsoleColor color)
        {
            this.messege = messege;
            this.color = color;
        }
    }
}
