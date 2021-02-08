namespace ITUtilities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RankIsOfficer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ranks", "IsOfficer", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ranks", "IsOfficer");
        }
    }
}
