namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gte : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reclamations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descriptions = c.String(),
                        IdEvent = c.Int(),
                        Idpar = c.Int(),
                        Participant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Evenements", t => t.IdEvent)
                .ForeignKey("dbo.Users", t => t.Participant_Id)
                .Index(t => t.IdEvent)
                .Index(t => t.Participant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reclamations", "Participant_Id", "dbo.Users");
            DropForeignKey("dbo.Reclamations", "IdEvent", "dbo.Evenements");
            DropIndex("dbo.Reclamations", new[] { "Participant_Id" });
            DropIndex("dbo.Reclamations", new[] { "IdEvent" });
            DropTable("dbo.Reclamations");
        }
    }
}
