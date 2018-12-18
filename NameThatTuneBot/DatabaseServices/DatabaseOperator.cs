using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using NameThatTuneBot.DatabaseServices.Commands;

namespace NameThatTuneBot.DatabaseServices
{

    class DatabaseOperator
    {
        DbContextOptions<ApplicationContext> databaseOptions;  

        public DatabaseOperator(DbContextOptions<ApplicationContext> options)
        {
            databaseOptions = options;

        }

        public async void HandleAsync(IDatabaseCommand<ApplicationContext> command)
        {
            using (ApplicationContext dataBase = new ApplicationContext(databaseOptions))
            {
                await command.HandleCommand(dataBase);
            }
        }

    }
}
