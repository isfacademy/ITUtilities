namespace ITUtilities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddisforAdmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.isfBranches", "IsforAdmin", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.isfBranches", "IsforAdmin");
        }
    }
}
