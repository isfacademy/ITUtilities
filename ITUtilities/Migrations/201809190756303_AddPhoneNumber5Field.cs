namespace ITUtilities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumber5Field : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.phoneNumbers", "Number5", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.phoneNumbers", "Number5");
        }
    }
}
