namespace ITUtilities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePersonOrder : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.isfPersons", "Order");
        }
        
        public override void Down()
        {
            AddColumn("dbo.isfPersons", "Order", c => c.Int(nullable: false));
        }
    }
}
