namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mokh : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.OrganizerTeams", newName: "TeamOrganizers");
            RenameColumn(table: "dbo.Recomendations", name: "ParticipantId", newName: "IdParticipant");
            RenameColumn(table: "dbo.Recomendations", name: "EventId", newName: "IdEvent");
            RenameIndex(table: "dbo.Recomendations", name: "IX_EventId", newName: "IX_IdEvent");
            RenameIndex(table: "dbo.Recomendations", name: "IX_ParticipantId", newName: "IX_IdParticipant");
            DropPrimaryKey("dbo.Recomendations");
            DropPrimaryKey("dbo.TeamOrganizers");
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        IdLike = c.Int(nullable: false, identity: true),
                        IdParticipant = c.Int(nullable: false),
                        IdPost = c.Int(nullable: false),
                        LikedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.IdLike)
                .ForeignKey("dbo.Users", t => t.IdParticipant, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.IdPost, cascadeDelete: true)
                .Index(t => t.IdParticipant)
                .Index(t => t.IdPost);
            
            CreateTable(
                "dbo.Rewards",
                c => new
                    {
                        RewardId = c.Int(nullable: false, identity: true),
                        description1 = c.String(),
                        firstReward = c.Int(nullable: false),
                        description2 = c.String(),
                        SecondReward = c.Int(nullable: false),
                        description3 = c.String(),
                        ThirdReward = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RewardId)
                .ForeignKey("dbo.Evenements", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Comments", "ParticipantName", c => c.String());
            AddColumn("dbo.Posts", "Photo", c => c.String());
            AddColumn("dbo.Posts", "Category", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "ParticipantId", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "ParticipantName", c => c.String());
            AddColumn("dbo.Posts", "Like", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "commentss", c => c.Int(nullable: false));
            AddColumn("dbo.Recomendations", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Recomendations", "EmailParticipent", c => c.String());
            AddColumn("dbo.Recomendations", "Nom", c => c.String());
            AddColumn("dbo.Recomendations", "Prenom", c => c.String());
            AddPrimaryKey("dbo.Recomendations", "ID");
            AddPrimaryKey("dbo.TeamOrganizers", new[] { "Team_IdTeam", "Organizer_Id" });
            DropColumn("dbo.Recomendations", "IdRecom");
            DropColumn("dbo.Recomendations", "MailRecomd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recomendations", "MailRecomd", c => c.String());
            AddColumn("dbo.Recomendations", "IdRecom", c => c.Int(nullable: false));
            DropForeignKey("dbo.Rewards", "UserId", "dbo.Users");
            DropForeignKey("dbo.Rewards", "EventId", "dbo.Evenements");
            DropForeignKey("dbo.Likes", "IdPost", "dbo.Posts");
            DropForeignKey("dbo.Likes", "IdParticipant", "dbo.Users");
            DropIndex("dbo.Rewards", new[] { "UserId" });
            DropIndex("dbo.Rewards", new[] { "EventId" });
            DropIndex("dbo.Likes", new[] { "IdPost" });
            DropIndex("dbo.Likes", new[] { "IdParticipant" });
            DropPrimaryKey("dbo.TeamOrganizers");
            DropPrimaryKey("dbo.Recomendations");
            DropColumn("dbo.Recomendations", "Prenom");
            DropColumn("dbo.Recomendations", "Nom");
            DropColumn("dbo.Recomendations", "EmailParticipent");
            DropColumn("dbo.Recomendations", "ID");
            DropColumn("dbo.Posts", "commentss");
            DropColumn("dbo.Posts", "Like");
            DropColumn("dbo.Posts", "ParticipantName");
            DropColumn("dbo.Posts", "ParticipantId");
            DropColumn("dbo.Posts", "Category");
            DropColumn("dbo.Posts", "Photo");
            DropColumn("dbo.Comments", "ParticipantName");
            DropTable("dbo.Rewards");
            DropTable("dbo.Likes");
            AddPrimaryKey("dbo.TeamOrganizers", new[] { "Organizer_Id", "Team_IdTeam" });
            AddPrimaryKey("dbo.Recomendations", new[] { "IdRecom", "EventId", "ParticipantId" });
            RenameIndex(table: "dbo.Recomendations", name: "IX_IdParticipant", newName: "IX_ParticipantId");
            RenameIndex(table: "dbo.Recomendations", name: "IX_IdEvent", newName: "IX_EventId");
            RenameColumn(table: "dbo.Recomendations", name: "IdEvent", newName: "EventId");
            RenameColumn(table: "dbo.Recomendations", name: "IdParticipant", newName: "ParticipantId");
            RenameTable(name: "dbo.TeamOrganizers", newName: "OrganizerTeams");
        }
    }
}
