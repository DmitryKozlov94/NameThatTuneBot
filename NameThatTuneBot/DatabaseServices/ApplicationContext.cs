using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using NameThatTuneBot.DatabaseServices.Entites;
namespace NameThatTuneBot.DatabaseServices
{
    public class ApplicationContext:DbContext
    {

        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<UserAnswer> UserAnswer { get; set; }
        public DbSet<MusicInfo> MusicInfos { get; set; }

        public int MusicLength { get; private set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
            MusicLength = MusicInfos.CountAsync().Result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserStatus>().HasKey(u => u.userId);
            modelBuilder.Entity<UserStatus>().Property(u => u.userId).ValueGeneratedNever();
            modelBuilder.Entity<UserAnswer>().HasKey(u => u.Id);
            modelBuilder.Entity<MusicInfo>().HasKey(u => u.Id);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TuneBotDatabase;Trusted_Connection=True;");
        //}
    }
}
