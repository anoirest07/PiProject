namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
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
                        BirthDate = c.DateTime(nullable: false),
                        City = c.String(),
                        HomeAddress = c.String(),
                        Image = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
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
                        DateCom = c.DateTime(nullable: false),
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
                        PostedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdPost);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        IdFB = c.Int(nullable: false, identity: true),
                        Answer = c.String(),
                        DescFB = c.String(),
                        IdEvent = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
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
                        DateEventDebut = c.DateTime(nullable: false),
                        DateEventFin = c.DateTime(nullable: false),
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
                        IdRecom = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        ParticipantId = c.Int(nullable: false),
                        MailRecomd = c.String(),
                        EtaRec = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdRecom, t.EventId, t.ParticipantId })
                .ForeignKey("dbo.Evenements", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ParticipantId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.ParticipantId);
            
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
                        IdTache = c.Int(nullable: false),
                        Nom = c.Int(nullable: false),
                        DescTache = c.String(),
                        DeadlineTache = c.DateTime(nullable: false),
                        EtatdeTache = c.Int(nullable: false),
                        OragnisateurFk = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.IdTache, t.Nom })
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
                "dbo.OrganizerTeams",
                c => new
                    {
                        Organizer_Id = c.Int(nullable: false),
                        Team_IdTeam = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Organizer_Id, t.Team_IdTeam })
                .ForeignKey("dbo.Users", t => t.Organizer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.Team_IdTeam, cascadeDelete: true)
                .Index(t => t.Organizer_Id)
                .Index(t => t.Team_IdTeam);
            
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
            DropForeignKey("dbo.Taches", "OragnisateurFk", "dbo.Users");
            DropForeignKey("dbo.OrganizerTeams", "Team_IdTeam", "dbo.Teams");
            DropForeignKey("dbo.OrganizerTeams", "Organizer_Id", "dbo.Users");
            DropForeignKey("dbo.Teams", "President_Id", "dbo.Users");
            DropForeignKey("dbo.Recomendations", "ParticipantId", "dbo.Users");
            DropForeignKey("dbo.Recomendations", "EventId", "dbo.Evenements");
            DropForeignKey("dbo.Reclamations", "Idpar", "dbo.Users");
            DropForeignKey("dbo.Reclamations", "IdEvent", "dbo.Evenements");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "ParticipantId", "dbo.Users");
            DropIndex("dbo.OrganizerTeams", new[] { "Team_IdTeam" });
            DropIndex("dbo.OrganizerTeams", new[] { "Organizer_Id" });
            DropIndex("dbo.Answers", new[] { "Answer_AnswerID" });
            DropIndex("dbo.Tickets", new[] { "IdEvent" });
            DropIndex("dbo.Taches", new[] { "OragnisateurFk" });
            DropIndex("dbo.CustomUserRoles", new[] { "CustomRole_Id" });
            DropIndex("dbo.CustomUserRoles", new[] { "UserId" });
            DropIndex("dbo.CustomUserLogins", new[] { "UserId" });
            DropIndex("dbo.Teams", new[] { "President_Id" });
            DropIndex("dbo.Recomendations", new[] { "ParticipantId" });
            DropIndex("dbo.Recomendations", new[] { "EventId" });
            DropIndex("dbo.Reclamations", new[] { "Idpar" });
            DropIndex("dbo.Reclamations", new[] { "IdEvent" });
            DropIndex("dbo.Evenements", new[] { "TeamFk" });
            DropIndex("dbo.Feedbacks", new[] { "Id" });
            DropIndex("dbo.Feedbacks", new[] { "IdEvent" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "ParticipantId" });
            DropIndex("dbo.CustomUserClaims", new[] { "UserId" });
            DropIndex("dbo.Achats", new[] { "IdParticipant" });
            DropIndex("dbo.Achats", new[] { "IdTicket" });
            DropTable("dbo.OrganizerTeams");
            DropTable("dbo.CustomRoles");
            DropTable("dbo.Rapports");
            DropTable("dbo.Answers");
            DropTable("dbo.Tickets");
            DropTable("dbo.Taches");
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.CustomUserLogins");
            DropTable("dbo.Teams");
            DropTable("dbo.Recomendations");
            DropTable("dbo.Reclamations");
            DropTable("dbo.Evenements");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Achats");
        }
    }
}
