using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.DatabaseServices.Entites;


namespace NameThatTuneBot.DatabaseServices.Commands
{
    class AddItem : IDatabaseCommand<ApplicationContext> //Переделать
    {
        public AddItem(MusicInfo musicInfo)
        {
            this.musicInfo = musicInfo;
        }
        public AddItem(UserStatus userStatus)
        {
            this.userStatus = userStatus;
        }

        public AddItem(UserAnswer userAnswer)
        {
            this.userAnswer= userAnswer;
        }
        public async Task HandleCommand(ApplicationContext contex) 
        {
            if( musicInfo != null)
            {
                await contex.MusicInfos.AddAsync(musicInfo);
            }
            if (userStatus != null)
            {
                await contex.UserStatuses.AddAsync(userStatus);
            }
            if (userAnswer!= null)
            {
                await contex.UserAnswer.AddAsync(userAnswer);
            }
            await contex.SaveChangesAsync();
        }

        private UserAnswer userAnswer;
        private MusicInfo musicInfo;
        private UserStatus userStatus;

    }
}
