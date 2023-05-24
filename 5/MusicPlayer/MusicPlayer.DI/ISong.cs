using System;

namespace MusicPlayer.DI
{
    public interface ISong
    {
        string Title { get; set; }
        string Artist { get; set; }

        bool Equals(ISong other);
    }
}
