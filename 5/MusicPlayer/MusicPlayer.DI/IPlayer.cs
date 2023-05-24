using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DI
{
    public interface IPlayer
    {
        ISong CurrentSong { get; set; }
        bool IsPlaying { get; set; }
        void AddSong(ISong song);
        void RemoveSong(ISong song);
        void Next();
        void Previous();
        IEnumerable<ISong> GetAllSongs();
    }
}
