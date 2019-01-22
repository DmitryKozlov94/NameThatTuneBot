using Concentus.Enums;
using Concentus.Oggfile;
using Concentus.Structs;
using NAudio.Wave;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace NameThatTuneBot.DatabaseServices.Entites
{
    public class MusicInfo: IEqualityComparer<MusicInfo>
    {
       public int Id { get; set; }
       
        public string atrist { get; set; }

        public string trackName { get; set; }

        public long fileID { get; set; }

        public string fileLocation { get; set; }

        public string UriTrack { get; set; }

        public MusicInfo() { }

        public string GetNameTrack()
        {
            return this.atrist + " - " + this.trackName;
        }

        public MusicInfo(string artist, string fileLocation, string trackName= "")
        {
            this.atrist = artist;
            this.trackName = trackName;
            this.UriTrack = GetMusicAddress(artist, trackName);
            var fileName = fileID.ToString() + ".ogg";
            this.fileLocation = fileLocation + fileName;
            ConvertToOgg(this.UriTrack, fileLocation, fileName);
        }

        private string GetMusicAddress(string artist, string nameTrack = "")
        {
           using( HttpClient client = new HttpClient())
            {
                var httpResponse = client.GetAsync("https://itunes.apple.com/search?parameterkeyvalue&term=" + artist + "+" + nameTrack + "&media=music&limit=15").Result;
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    var block = JObject.Parse(result);
                    if (block["resultCount"].ToString() != "0")
                    {
                        this.fileID = long.Parse(block["results"][0]["trackId"].ToString());
                        return block["results"][0]["previewUrl"].ToString();                    
                    }
                }
            }
            return null;
        }

        private void ConvertToOgg(string uri, string fileLocation, string FileName)
        {
            MediaFoundationReader reader = new MediaFoundationReader(uri);
            WaveFormat newFormat = new WaveFormat(48000, reader.WaveFormat.Channels);
            WaveFormatConversionStream newStream = new WaveFormatConversionStream(newFormat, reader);
            WaveStream conv = WaveFormatConversionStream.CreatePcmStream(newStream);
            byte[] bytes = new byte[conv.Length];
            conv.Position = 0;
            conv.Read(bytes, 0, (int)conv.Length);
            OpusEncoder encoder = OpusEncoder.Create(48000, 2, OpusApplication.OPUS_APPLICATION_AUDIO);
            var memo = new MemoryStream();
            var oggOut = new OpusOggWriteStream(encoder, memo);
            var shorts = ByteToShort(bytes);
            oggOut.WriteSamples(shorts, 0, shorts.Count());
            oggOut.Finish();
            var result = memo.ToArray();
            using (var stream = new FileStream(fileLocation+FileName, FileMode.Create))
            {
                stream.Write(result, 0, result.Length);
            }
        }

        private short[] ByteToShort(Byte[] bytes)
        {
            List<short> shorts = new List<short>();
            int i = 0;
            while (i < bytes.Length)
            {
                shorts.Add(BitConverter.ToInt16(new byte[2] { bytes[i], bytes[i + 1] }, 0));
                i = i + 2;
            }
            return shorts.ToArray();
        }
        public bool Equals(MusicInfo x, MusicInfo y)
        {
            return x.atrist == y.atrist;
        }

        public int GetHashCode(MusicInfo obj)
        {
            return obj.atrist.GetHashCode();
        }
    }
}
