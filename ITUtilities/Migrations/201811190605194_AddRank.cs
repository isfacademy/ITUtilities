namespace ITUtilities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRank : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.isfPersons", name: "Rank_Id", newName: "RankId");
            RenameIndex(table: "dbo.isfPersons", name: "IX_Rank_Id", newName: "IX_RankId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.isfPersons", name: "IX_RankId", newName: "IX_Rank_Id");
            RenameColumn(table: "dbo.isfPersons", name: "RankId", newName: "Rank_Id");
        }
    }
}
