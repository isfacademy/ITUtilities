namespace ITUtilities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rollback1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ranks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.isfPersons", "Rank_Id", c => c.Int());
            CreateIndex("dbo.isfPersons", "Rank_Id");
            AddForeignKey("dbo.isfPersons", "Rank_Id", "dbo.Ranks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.isfPersons", "Rank_Id", "dbo.Ranks");
            DropIndex("dbo.isfPersons", new[] { "Rank_Id" });
            DropColumn("dbo.isfPersons", "Rank_Id");
            DropTable("dbo.Ranks");
        }
    }
}
