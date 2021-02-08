namespace ITUtilities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMilitaryNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.isfPersons", "MilitaryNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.isfPersons", "MilitaryNumber");
        }
    }
}
