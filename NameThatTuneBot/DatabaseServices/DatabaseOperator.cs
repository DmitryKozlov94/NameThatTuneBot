using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using NameThatTuneBot.DatabaseServices.Commands;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace NameThatTuneBot.DatabaseServices
{

    public class DatabaseOperator
    {
        DbContextOptions<ApplicationContext> databaseOptions;

        public DatabaseOperator()//Возможно нужно это винести за класс, для более гибкой настройки 
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile(@"D:\Files\Learning\__Методы\Final\NameThatTuneBot\NameThatTuneBot\NameThatTuneBot\DatabaseServices\appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            
            databaseOptions = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
        }

        public async Task HandleAsync(ICommand<ApplicationContext> command)
        {
            using (ApplicationContext dataBase = new ApplicationContext(databaseOptions))
            {
                await command.HandleCommand(dataBase);
            }
        }



    }
}
