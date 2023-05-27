namespace MusicPlayer.Data.Sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SongEntities", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SongEntities", "FileName");
        }
    }
}
