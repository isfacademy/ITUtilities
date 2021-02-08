namespace ITUtilities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExternalPhoneNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.phoneNumbers", "ExternalNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.phoneNumbers", "ExternalNumber");
        }
    }
}
