namespace ITUtilities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.phoneNumbers", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.phoneNumbers", "Order");
        }
    }
}
