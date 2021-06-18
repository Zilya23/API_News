using System;
using System.IO;
using Telegram.Bot;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {

            TelegramBotClient bot = new TelegramBotClient("1835148714:AAHgpBVLEWJPJDoz5GB6NbR9FQmmJxLJx54");

            bot.OnMessage += (s, arg) =>
            {
                Console.WriteLine($"{arg.Message.Chat.FirstName}: {arg.Message.Text}");
                bot.SendTextMessageAsync(arg.Message.Chat.Id, $"You say: {arg.Message.Text}");
            };

            bot.StartReceiving();

            Console.ReadKey();
        }
    }
}
