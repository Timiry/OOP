using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.DI;

namespace MusicPlayer.BLL
{
    public class Song : ISong
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string FileName { get; set; }

        public bool Equals(ISong other)
        {
            return other.Title.Equals(Title) && other.Artist.Equals(Artist);
        }
    }
}
