using System;
using System.Collections.Generic;
using System.Windows.Media;
using MusicPlayer.DI;

namespace MusicPlayer.BLL
{
    public class Player : IPlayer
    {
        private readonly IData<ISong> _songData;

        public ISong CurrentSong { get; set; }

        public bool IsPlaying { get; set; }

        public Player(IData<ISong> songData)
        {
            _songData = songData ?? throw new ArgumentNullException(nameof(songData));
        }

        public void AddSong(ISong song)
        {
            _songData.Add(song);
        }

        public void RemoveSong(ISong song)
        {
            _songData.Remove(song);
        }

        public IEnumerable<ISong> GetAllSongs()
        {
            return _songData.ReadAll();
        }

        public void Next()
        {
            var songs = GetAllSongs();
            var enumerator = songs.GetEnumerator();
            ISong song;
            while(enumerator.MoveNext())
            {
                if (enumerator.Current.Equals(CurrentSong))
                {
                    if (enumerator.MoveNext())
                    {
                        CurrentSong = enumerator.Current;
                    } else
                    {
                        enumerator = songs.GetEnumerator();
                        enumerator.MoveNext();
                        CurrentSong = enumerator.Current;
                    }
                    break;
                }
            }
        }

        public void Previous()
        {
            var songs = GetAllSongs();
            var enumerator = songs.GetEnumerator();
            ISong prev;

            while (enumerator.MoveNext())
            {
                if (enumerator.Current.Equals(CurrentSong))
                {
                    if (enumerator.MoveNext())
                    {
                        CurrentSong = enumerator.Current;
                    }
                    else
                    {
                        enumerator = songs.GetEnumerator();
                        enumerator.MoveNext();
                        CurrentSong = enumerator.Current;
                    }
                    break;
                }
            }
        }
    }
}
