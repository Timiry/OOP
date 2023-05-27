using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows;
using System.Windows.Media;
using MusicPlayer.DI;

namespace MusicPlayer.BLL
{
    public class Player : IPlayer
    {
        private readonly IData<ISong> _songData;

        public ISong CurrentSong { get; set; }

       public MediaPlayer _mediaPlayer { get; set; }

        public bool IsPlaying { get; set; }

        public Player(IData<ISong> songData)
        {
            _songData = songData ?? throw new ArgumentNullException(nameof(songData));
            _mediaPlayer = new MediaPlayer();
            _mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
        }

        public void Play()
        {
            _mediaPlayer.Play();
            IsPlaying = true;
        }

        public void Pause()
        {
            _mediaPlayer.Pause();
            IsPlaying = false;
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

        public void Open()
        {
            _mediaPlayer.MediaFailed += new EventHandler<ExceptionEventArgs>(player_MediaFailed);
            _mediaPlayer.Open(new Uri(CurrentSong.FileName, UriKind.Relative));
        }

        void player_MediaFailed(object sender, ExceptionEventArgs e)
        {
            MessageBox.Show("Ошибка во время открытия файла.");
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
                        //_mediaPlayer.Open(new Uri(CurrentSong.FileName));
                        Open();
                    } else
                    {
                        enumerator = songs.GetEnumerator();
                        enumerator.MoveNext();
                        CurrentSong = enumerator.Current;
                        //_mediaPlayer.Open(new Uri(CurrentSong.FileName));
                        Open();
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
                        //_mediaPlayer.Open(new Uri(CurrentSong.FileName));
                        Open();
                    }
                    else
                    {
                        enumerator = songs.GetEnumerator();
                        enumerator.MoveNext();
                        CurrentSong = enumerator.Current;
                        //_mediaPlayer.Open(new Uri(CurrentSong.FileName));
                        Open();
                    }
                    break;
                }
            }
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            //if (_currentIndex < _playlist.Count - 1)
            //{
            //    _currentIndex++;
            //    _mediaPlayer.Open(new Uri(_playlist[_currentIndex]));
            //    _mediaPlayer.Play();
            //    _isPlaying = true;
            //}
        }
    }
}
