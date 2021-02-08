namespace ITUtilities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MergingBranchesOfficersApp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.isfPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Order = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.isfBranches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            AddColumn("dbo.isfBranches", "isPseudo", c => c.Boolean(nullable: false));
            AddColumn("dbo.isfBranches", "ParentId", c => c.Int());
            CreateIndex("dbo.isfBranches", "ParentId");
            AddForeignKey("dbo.isfBranches", "ParentId", "dbo.isfBranches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.isfBranches", "ParentId", "dbo.isfBranches");
            DropForeignKey("dbo.isfPersons", "BranchId", "dbo.isfBranches");
            DropIndex("dbo.isfPersons", new[] { "BranchId" });
            DropIndex("dbo.isfBranches", new[] { "ParentId" });
            DropColumn("dbo.isfBranches", "ParentId");
            DropColumn("dbo.isfBranches", "isPseudo");
            DropTable("dbo.isfPersons");
        }
    }
}
