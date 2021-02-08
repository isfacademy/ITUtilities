namespace ITUtilities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRequiredNumber1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.phoneNumbers", "Number1", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.phoneNumbers", "Number1", c => c.String(nullable: false));
        }
    }
}
