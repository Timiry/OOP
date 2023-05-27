using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MusicPlayer.DI
{
    public interface IPlayer
    {
        ISong CurrentSong { get; set; }
        MediaPlayer _mediaPlayer { get; set; }
        bool IsPlaying { get; set; }
        void AddSong(ISong song);
        void RemoveSong(ISong song);
        void Open();
        void Play();
        void Pause();
        void Next();
        void Previous();
        IEnumerable<ISong> GetAllSongs();
    }
}
