using System;
using System.Collections.Generic;
using MusicPlayer.DI;

namespace MusicPlayer.Data.Memory
{
    public class SongMemoryData : IData<ISong>
    {
        private readonly List<ISong> _songs;

        public SongMemoryData()
        {
            _songs = new List<ISong>();
        }
        public void Add(ISong item)
        {
            _songs.Add(item);
        }

        public void Remove(ISong item)
        {
            _songs.Remove(item);
        }

        public IEnumerable<ISong> ReadAll()
        {
            return _songs;
        }
    }
}
