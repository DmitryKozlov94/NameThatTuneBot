using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace NameThatTuneBot.TelegramServices
{
    public static class KeyboardBuilder
    {
        public static ReplyKeyboardMarkup GetMainTypeKeyboard()
        {
            return new ReplyKeyboardMarkup(new[]
                    {
                        new [] 
                        {
                            new KeyboardButton("Run Game")
                        },
                    });
        }

        public static ReplyKeyboardMarkup GetKeyboardSelection()
        {
            return new ReplyKeyboardMarkup(new[]
                {
                        new [] 
                    {
                        new KeyboardButton("A"),
                        new KeyboardButton("B"),
                    },
                        new [] // last row
                    {
                        new KeyboardButton("C"),
                        new KeyboardButton("D"),
                    },
                    new []
                    {
                        new KeyboardButton("Stop the game"),
                      
                    }
                });

        }
    }
}
