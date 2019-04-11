namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achats",
                c => new
                    {
                        IdAchat = c.Int(nullable: false, identity: true),
                        Quantites = c.Int(nullable: false),
                        IdTicket = c.Int(nullable: false),
                        IdParticipant = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAchat)
                .ForeignKey("dbo.Users", t => t.IdParticipant, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.IdTicket, cascadeDelete: true)
                .Index(t => t.IdTicket)
                .Index(t => t.IdParticipant);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Email = c.String(),
                        Password = c.String(nullable: false),
                        Gender = c.String(),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        City = c.String(),
                        HomeAddress = c.String(),
                        Image = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Role = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        ContenuCom = c.String(),
                        DateCom = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ParticipantName = c.String(),
                        ParticipantId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Users", t => t.ParticipantId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.ParticipantId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        IdPost = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 500),
                        Description = c.String(nullable: false),
                        PostedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Photo = c.String(),
                        Category = c.Int(nullable: false),
                        ParticipantId = c.Int(nullable: false),
                        ParticipantName = c.String(),
                        Like = c.Int(nullable: false),
                        commentss = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPost);
            
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
                "dbo.Feedbacks",
                c => new
                    {
                        IdFB = c.Int(nullable: false, identity: true),
                        Answer = c.String(),
                        DescFB = c.String(),
                        IdEvent = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Id = c.Int(),
                    })
                .PrimaryKey(t => t.IdFB)
                .ForeignKey("dbo.Evenements", t => t.IdEvent, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.IdEvent)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Evenements",
                c => new
                    {
                        IdEvent = c.Int(nullable: false, identity: true),
                        NomEvent = c.String(),
                        DateEventDebut = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateEventFin = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LocationEvent = c.String(),
                        DescriptionEvent = c.String(),
                        NbPlaceEvent = c.Int(nullable: false),
                        ImageEvent = c.String(nullable: false),
                        Welcometext = c.String(),
                        Methodepai = c.Int(nullable: false),
                        EtatEvenement = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        ThemeColor = c.String(),
                        IsFullDay = c.Boolean(nullable: false),
                        TeamFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdEvent)
                .ForeignKey("dbo.Teams", t => t.TeamFk, cascadeDelete: true)
                .Index(t => t.TeamFk);
            
            CreateTable(
                "dbo.Reclamations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descriptions = c.String(),
                        IdEvent = c.Int(nullable: false),
                        Idpar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Evenements", t => t.IdEvent, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Idpar, cascadeDelete: true)
                .Index(t => t.IdEvent)
                .Index(t => t.Idpar);
            
            CreateTable(
                "dbo.Recomendations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmailParticipent = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        EtaRec = c.Int(nullable: false),
                        IdEvent = c.Int(nullable: false),
                        IdParticipant = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Evenements", t => t.IdEvent, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IdParticipant, cascadeDelete: true)
                .Index(t => t.IdEvent)
                .Index(t => t.IdParticipant);
            
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
            
            CreateTable(
                "dbo.CustomUserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        IdTeam = c.Int(nullable: false, identity: true),
                        NomTeam = c.String(),
                        PesidentFK = c.Int(nullable: false),
                        President_Id = c.Int(),
                    })
                .PrimaryKey(t => t.IdTeam)
                .ForeignKey("dbo.Users", t => t.President_Id)
                .Index(t => t.President_Id);
            
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CustomRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomRoles", t => t.CustomRole_Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CustomRole_Id);
            
            CreateTable(
                "dbo.Taches",
                c => new
                    {
                        IdTache = c.Int(nullable: false, identity: true),
                        Nom = c.Int(nullable: false),
                        DescTache = c.String(),
                        DeadlineTache = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EtatdeTache = c.Int(nullable: false),
                        OragnisateurFk = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                        OrgNom = c.String(),
                    })
                .PrimaryKey(t => t.IdTache)
                .ForeignKey("dbo.Users", t => t.OragnisateurFk, cascadeDelete: true)
                .Index(t => t.OragnisateurFk);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        IdTicket = c.Int(nullable: false, identity: true),
                        Prix = c.Long(nullable: false),
                        Logo = c.String(),
                        IdEvent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTicket)
                .ForeignKey("dbo.Evenements", t => t.IdEvent, cascadeDelete: true)
                .Index(t => t.IdEvent);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Css = c.String(),
                        Answer_AnswerID = c.Int(),
                    })
                .PrimaryKey(t => t.AnswerID)
                .ForeignKey("dbo.Answers", t => t.Answer_AnswerID)
                .Index(t => t.Answer_AnswerID);
            
            CreateTable(
                "dbo.Rapports",
                c => new
                    {
                        IdRapport = c.Int(nullable: false, identity: true),
                        Contenu = c.String(),
                        ImageRapport = c.String(),
                    })
                .PrimaryKey(t => t.IdRapport);
            
            CreateTable(
                "dbo.CustomRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeamOrganizers",
                c => new
                    {
                        Team_IdTeam = c.Int(nullable: false),
                        Organizer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Team_IdTeam, t.Organizer_Id })
                .ForeignKey("dbo.Teams", t => t.Team_IdTeam, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Organizer_Id, cascadeDelete: true)
                .Index(t => t.Team_IdTeam)
                .Index(t => t.Organizer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomUserRoles", "CustomRole_Id", "dbo.CustomRoles");
            DropForeignKey("dbo.Answers", "Answer_AnswerID", "dbo.Answers");
            DropForeignKey("dbo.Achats", "IdTicket", "dbo.Tickets");
            DropForeignKey("dbo.Achats", "IdParticipant", "dbo.Users");
            DropForeignKey("dbo.Feedbacks", "Id", "dbo.Users");
            DropForeignKey("dbo.Feedbacks", "IdEvent", "dbo.Evenements");
            DropForeignKey("dbo.Tickets", "IdEvent", "dbo.Evenements");
            DropForeignKey("dbo.Evenements", "TeamFk", "dbo.Teams");
            DropForeignKey("dbo.Rewards", "UserId", "dbo.Users");
            DropForeignKey("dbo.Taches", "OragnisateurFk", "dbo.Users");
            DropForeignKey("dbo.TeamOrganizers", "Organizer_Id", "dbo.Users");
            DropForeignKey("dbo.TeamOrganizers", "Team_IdTeam", "dbo.Teams");
            DropForeignKey("dbo.Teams", "President_Id", "dbo.Users");
            DropForeignKey("dbo.Rewards", "EventId", "dbo.Evenements");
            DropForeignKey("dbo.Recomendations", "IdParticipant", "dbo.Users");
            DropForeignKey("dbo.Recomendations", "IdEvent", "dbo.Evenements");
            DropForeignKey("dbo.Reclamations", "Idpar", "dbo.Users");
            DropForeignKey("dbo.Reclamations", "IdEvent", "dbo.Evenements");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Likes", "IdPost", "dbo.Posts");
            DropForeignKey("dbo.Likes", "IdParticipant", "dbo.Users");
            DropForeignKey("dbo.Comments", "ParticipantId", "dbo.Users");
            DropIndex("dbo.TeamOrganizers", new[] { "Organizer_Id" });
            DropIndex("dbo.TeamOrganizers", new[] { "Team_IdTeam" });
            DropIndex("dbo.Answers", new[] { "Answer_AnswerID" });
            DropIndex("dbo.Tickets", new[] { "IdEvent" });
            DropIndex("dbo.Taches", new[] { "OragnisateurFk" });
            DropIndex("dbo.CustomUserRoles", new[] { "CustomRole_Id" });
            DropIndex("dbo.CustomUserRoles", new[] { "UserId" });
            DropIndex("dbo.Teams", new[] { "President_Id" });
            DropIndex("dbo.CustomUserLogins", new[] { "UserId" });
            DropIndex("dbo.Rewards", new[] { "UserId" });
            DropIndex("dbo.Rewards", new[] { "EventId" });
            DropIndex("dbo.Recomendations", new[] { "IdParticipant" });
            DropIndex("dbo.Recomendations", new[] { "IdEvent" });
            DropIndex("dbo.Reclamations", new[] { "Idpar" });
            DropIndex("dbo.Reclamations", new[] { "IdEvent" });
            DropIndex("dbo.Evenements", new[] { "TeamFk" });
            DropIndex("dbo.Feedbacks", new[] { "Id" });
            DropIndex("dbo.Feedbacks", new[] { "IdEvent" });
            DropIndex("dbo.Likes", new[] { "IdPost" });
            DropIndex("dbo.Likes", new[] { "IdParticipant" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "ParticipantId" });
            DropIndex("dbo.CustomUserClaims", new[] { "UserId" });
            DropIndex("dbo.Achats", new[] { "IdParticipant" });
            DropIndex("dbo.Achats", new[] { "IdTicket" });
            DropTable("dbo.TeamOrganizers");
            DropTable("dbo.CustomRoles");
            DropTable("dbo.Rapports");
            DropTable("dbo.Answers");
            DropTable("dbo.Tickets");
            DropTable("dbo.Taches");
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.Teams");
            DropTable("dbo.CustomUserLogins");
            DropTable("dbo.Rewards");
            DropTable("dbo.Recomendations");
            DropTable("dbo.Reclamations");
            DropTable("dbo.Evenements");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Likes");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Achats");
        }
    }
}
