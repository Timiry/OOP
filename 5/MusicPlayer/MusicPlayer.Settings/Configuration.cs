using System;
using MusicPlayer.DI;
using MusicPlayer.BLL;
using MusicPlayer.Data.Memory;
using MusicPlayer.Data.Sql;
using SimpleInjector;


namespace MusicPlayer.Settings
{
    public class Configuration
    {
        public Container Container { get; }

        public Configuration()
        {
            Container = new Container();

            Setup();
        }

        public virtual void Setup()
        {
            Container.Register<ISong, Song>(Lifestyle.Transient);
            Container.Register<IPlayer, Player>(Lifestyle.Singleton);
            Container.Register<IData<ISong>, SongSqlData>(Lifestyle.Singleton);
        }
    }
}
