using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.DatabaseService.Entites;


namespace NameThatTuneBot.DatabaseService.DatabaseCommand
{
    class AddItem : IDatabaseCommand<ApplicationContext>
    {
        public AddItem(MusicInfo musicInfo)
        {
            this.musicInfo = musicInfo;
        }
        public AddItem(UserStatus userStatus)
        {
            this.userStatus = userStatus;
        }
        public async Task HandleCommand(ApplicationContext contex)
        {
            if( musicInfo == null)
            {
                await contex.UserStatuses.AddAsync(userStatus);
            }else
            {
                await contex.MusicInfos.AddAsync(musicInfo);
            }
            await contex.SaveChangesAsync();
        }


        private MusicInfo musicInfo;
        private UserStatus userStatus;

    }
}
