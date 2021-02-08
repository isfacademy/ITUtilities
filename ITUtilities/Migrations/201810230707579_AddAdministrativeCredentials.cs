namespace ITUtilities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdministrativeCredentials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.administrativeCredentials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        IP = c.String(),
                        URL = c.String(),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.administrativeCredentials");
        }
    }
}
