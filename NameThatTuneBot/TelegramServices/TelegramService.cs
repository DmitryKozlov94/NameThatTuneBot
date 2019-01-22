using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.DatabaseServices.Entites;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InputFiles;
using NameThatTuneBot.Message;
using System.IO;

namespace NameThatTuneBot.TelegramServices
{
    class TelegramService: ApiBot
    {
        public TelegramService(string authToken, Mediator mediator)
            :base(mediator)
        {
            client = new TelegramBotClient(authToken);
            client.OnMessage += BotOnMessageReceived;
            client.OnCallbackQuery += BotOnCallbackQueryReceived;
            client.OnReceiveError += BotOnReceiveError;
        }

        public override void StartReceiving()
        {
            var me = client.GetMeAsync().Result;

            Console.Title = me.Username;

            client.StartReceiving();
            Console.WriteLine($"Start listening for @{me.Username}");
        }
        public override void StopReceiving()
        {
            client.StopReceiving();
            Console.WriteLine($"Stop listening ");
        }
        private void BotOnReceiveError(object sender, ReceiveErrorEventArgs e)
        {
            
        }

        private async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs e) //Что за бред
        {
            var message = new Message.Message(this.GetType(), e.CallbackQuery.Data, e.CallbackQuery.Message.Chat.Id);
            await mediator.HandleCommand(message);
        }

        private async void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = new Message.Message(this.GetType(), e.Message.Text, e.Message.Chat.Id);
            await mediator.HandleCommand(message);
        }

        public async override Task SendSimpleMessage(long id, string text, KeyboardTypes keyboardType)
        {
            switch (keyboardType)
            {
                case KeyboardTypes.MainKeyboard:
                    await client.SendTextMessageAsync(id, text, replyMarkup: KeyboardBuilder.GetMainTypeKeyboard());
                    break;
                case KeyboardTypes.KeyboardSelection:
                    await client.SendTextMessageAsync(id, text, replyMarkup: KeyboardBuilder.GetKeyboardSelection());
                    break;
                default:
                    await client.SendTextMessageAsync(id, text);
                    break;
            }
            
        }

        public async override Task SendMusicMessage(long id, string text, MusicInfo musicInfo, KeyboardTypes keyboardType)
        {
            // FileStream file = new FileStream(@"D:\file4.ogg", FileAccess.Read);
            Console.WriteLine("SendMusicMessage-1");
           
            Console.WriteLine("SendMusicMessage-2");
           
            Console.WriteLine("SendMusicMessage-3");
            switch (keyboardType)
            {
                case KeyboardTypes.MainKeyboard:
                    await client.SendTextMessageAsync(id, text, replyMarkup: KeyboardBuilder.GetMainTypeKeyboard());
                    break;
                case KeyboardTypes.KeyboardSelection:
                    var stream = new FileStream(musicInfo.fileLocation, FileMode.Open);
                    InputOnlineFile inputFile = new InputOnlineFile(stream);
                    Console.WriteLine("SendMusicMessage-4");
                    await client.SendVoiceAsync(id, inputFile);
                    Console.WriteLine("SendMusicMessage-5");
                    await client.SendTextMessageAsync(id, text, replyMarkup: KeyboardBuilder.GetKeyboardSelection());
                    Console.WriteLine("SendMusicMessage-6");
                    stream.Close();
                    break;
                default:
                    await client.SendTextMessageAsync(id, text);
                    break;
            }
            
        }



        private TelegramBotClient client;
    }
}
