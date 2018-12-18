using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.DatabaseServices.Entites;
using System.Linq;

namespace NameThatTuneBot.DatabaseServices.Commands
{
    class DeleteMusicInfo : IDatabaseCommand<ApplicationContext>
    {
        public DeleteMusicInfo(int fileId)
        {
            this.fileId = fileId;
        }
        public async Task HandleCommand(ApplicationContext contex)
        {
            MusicInfo[] tracks = contex.MusicInfos.Where(info => info.fileID == fileId).ToArray();
            contex.MusicInfos.RemoveRange(tracks);
            await contex.SaveChangesAsync();
        }

        private long fileId;
    {
    }
}
