using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Data.Sql
{
    internal class MusicPlayerContext : DbContext
    {
        internal MusicPlayerContext() : base("MusicPlayer") {
            //FixEfProviderServicesProblem();
            
        }

        public DbSet<SongEntity> Songs { get; set; }

        private void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
