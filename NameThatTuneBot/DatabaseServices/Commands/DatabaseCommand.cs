using NameThatTuneBot.DatabaseServices.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace NameThatTuneBot.DatabaseServices.Commands
{
    static class DatabaseCommand
    {
        public static async Task AddUserAnswer(ApplicationContext contex, UserAnswer userAnswer)
        {
            await contex.UserAnswer.AddAsync(userAnswer);
            await contex.SaveChangesAsync();
        }

        public static bool CheckAnswer(ApplicationContext contex, long userId, string answer)
        {
            var correctAnswer = contex.UserAnswer.Where(x => x.userId == userId).FirstOrDefault().answer;
            return answer == correctAnswer;
        }

        public static async Task DeleteMusicInfo(ApplicationContext contex, int fileId)
        {
            MusicInfo[] tracks = contex.MusicInfos.Where(info => info.fileID == fileId).ToArray();
            contex.MusicInfos.RemoveRange(tracks);
            await contex.SaveChangesAsync();
        }

        public static async Task DeleteUserAnswer(ApplicationContext contex, long userId)
        {
            UserAnswer[] users = contex.UserAnswer.Where(user => user.userId == userId).ToArray();
            contex.UserAnswer.RemoveRange(users);
            await contex.SaveChangesAsync();
        }

        public static async Task DeleteUserStatus(ApplicationContext contex, long userId)
        {
            UserStatus user = contex.UserStatuses.Find(userId);
            contex.UserStatuses.Remove(user);
            await contex.SaveChangesAsync();
        }

        public static async Task<MusicInfo> GetMusicTrack(ApplicationContext contex)
        {
            var count = contex.MusicInfos.Count();
            Random random = new Random();
            return await contex.MusicInfos.FindAsync(random.Next(0, count));
        }

        //public Task GetRandomArtists(ApplicationContext contex)
        //{
        //    artistNames = new string[numArtist];
        //    var artists = contex.MusicInfos.Include(music => music.atrist)
        //                                     .Where(music => music.atrist != notUseArtist);
        //    for (int i = 0; i < numArtist; i++)
        //    {
        //        artistNames[i] = artists.Random().atrist;
        //    }
        //    return null; //Исправить
        //}

        //public async Task GetStatusUser(ApplicationContext contex)
        //{
        //    var user = await contex.UserStatuses.FindAsync(userId);
        //    this.UserStates = (user == null) ? UserStates.None : user.state;
        
    }
}
