using MusicPlayer.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MusicPlayer.Data.Sql
{
    public class SongSqlData : IData<ISong>
    {
        public SongSqlData() {}

        public void Add(ISong item)
        {
            using (var db = new MusicPlayerContext())
            {
                var song = new SongEntity(item);
                db.Songs.Add(song);
                db.SaveChanges();
            }
        }

        public IEnumerable<ISong> ReadAll()
        {
            using (var db = new MusicPlayerContext())
            {
                return db.Songs.ToList();
            }
        }

        public void Remove(ISong item)
        {
            using (var db = new MusicPlayerContext())
            {
                var song = db.Songs.SingleOrDefault(s => s.Title.Equals(item.Title) && s.Artist.Equals(item.Artist));
                db.Songs.Remove(song);
                db.SaveChanges();
            }
        }
    }
}
