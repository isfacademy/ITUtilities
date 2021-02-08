namespace ITUtilities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredPassword : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ctsUsers", "Password", c => c.String());
            AlterColumn("dbo.ipRecords", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ipRecords", "Username", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ipRecords", "Username", c => c.String());
            AlterColumn("dbo.ipRecords", "Name", c => c.String());
            AlterColumn("dbo.ctsUsers", "Password", c => c.String(nullable: false));
        }
    }
}
