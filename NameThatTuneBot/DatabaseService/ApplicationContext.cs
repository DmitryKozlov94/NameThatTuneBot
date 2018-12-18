using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using NameThatTuneBot.DatabaseService.Entites;
namespace NameThatTuneBot.DatabaseService
{
    public class ApplicationContext:DbContext
    {

        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<MusicInfo> MusicInfos { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TuneBotDatabase;Trusted_Connection=True;");
        //}
    }
}
