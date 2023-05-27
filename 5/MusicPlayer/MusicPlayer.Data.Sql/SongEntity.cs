using System;
using MusicPlayer.DI;

namespace MusicPlayer.Data.Sql
{
    public class SongEntity : ISong
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string FileName { get; set; }

        public SongEntity() { }
        public SongEntity(ISong item)
        {
            Id = 0;
            Title = item.Title;
            Artist = item.Artist;
            FileName = item.FileName;
        }

        public bool Equals(ISong other)
        {
            return other.Title.Equals(Title) && other.Artist.Equals(Artist);
        }
    }
}
