namespace ITUtilities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVisibleFieldBranch : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.isfBranches", "Visible", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.isfBranches", "Visible", c => c.Int(nullable: false));
        }
    }
}
