namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class g : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Feedbacks", name: "Participant_Id", newName: "Id");
            RenameColumn(table: "dbo.Feedbacks", name: "Events_IdEvent", newName: "IdEvent");
            RenameIndex(table: "dbo.Feedbacks", name: "IX_Events_IdEvent", newName: "IX_IdEvent");
            RenameIndex(table: "dbo.Feedbacks", name: "IX_Participant_Id", newName: "IX_Id");
            AddColumn("dbo.Feedbacks", "Answer", c => c.String());
            AlterColumn("dbo.Tickets", "Prix", c => c.Long(nullable: false));
            DropColumn("dbo.Feedbacks", "RateFB");
            DropColumn("dbo.Feedbacks", "EventFK");
            DropColumn("dbo.Feedbacks", "ParticipantFK");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Feedbacks", "ParticipantFK", c => c.Int(nullable: false));
            AddColumn("dbo.Feedbacks", "EventFK", c => c.Int(nullable: false));
            AddColumn("dbo.Feedbacks", "RateFB", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "Prix", c => c.Single(nullable: false));
            DropColumn("dbo.Feedbacks", "Answer");
            RenameIndex(table: "dbo.Feedbacks", name: "IX_Id", newName: "IX_Participant_Id");
            RenameIndex(table: "dbo.Feedbacks", name: "IX_IdEvent", newName: "IX_Events_IdEvent");
            RenameColumn(table: "dbo.Feedbacks", name: "IdEvent", newName: "Events_IdEvent");
            RenameColumn(table: "dbo.Feedbacks", name: "Id", newName: "Participant_Id");
        }
    }
}
