using System;
using Telegram.Bot;
using System.Linq;
using NameThatTuneBot.DatabaseService;
namespace NameThatTuneBot
{
    class Program
    {
        static void Main(string[] args)
        {
            using( ApplicationContext db = new ApplicationContext()){

                //TelegramBotClient rer = new TelegramBotClient("ede");
                UserStatus user = new UserStatus { userId = 1, status = "1" };
                UserStatus user2 = new UserStatus { userId = 2, status = "3" };
                UserStatus user3 = new UserStatus { userId = 3, status = "4" };
                db.UserStatuses.AddAsync (user);
                //Console.WriteLine("Add1");
                //db.UserStatuses.Add(user2);
                //Console.WriteLine("Add2");
                //db.UserStatuses.Add(user3);
                //Console.WriteLine("Add3");
                //db.SaveChanges();
                
                foreach(var i in db.UserStatuses.ToList())
                {
                    Console.WriteLine("Вот=" + i.ID + "||" + i.status);
                }

                Console.WriteLine("Hello World!");
            }
            
            
        }
    }
}
