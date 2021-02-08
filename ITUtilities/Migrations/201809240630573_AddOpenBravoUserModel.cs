namespace ITUtilities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOpenBravoUserModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.openBravoUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(),
                        isfBranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.isfBranches", t => t.isfBranchId, cascadeDelete: true)
                .Index(t => t.isfBranchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.openBravoUsers", "isfBranchId", "dbo.isfBranches");
            DropIndex("dbo.openBravoUsers", new[] { "isfBranchId" });
            DropTable("dbo.openBravoUsers");
        }
    }
}
