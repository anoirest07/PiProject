namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mr : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Taches");
            AddColumn("dbo.Taches", "OrgNom", c => c.String());
            AlterColumn("dbo.Users", "BirthDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Users", "LockoutEndDateUtc", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Comments", "DateCom", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Posts", "PostedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Feedbacks", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Evenements", "DateEventDebut", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Evenements", "DateEventFin", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Taches", "IdTache", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Taches", "DeadlineTache", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddPrimaryKey("dbo.Taches", "IdTache");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Taches");
            AlterColumn("dbo.Taches", "DeadlineTache", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Taches", "IdTache", c => c.Int(nullable: false));
            AlterColumn("dbo.Evenements", "DateEventFin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Evenements", "DateEventDebut", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Feedbacks", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "PostedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comments", "DateCom", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "LockoutEndDateUtc", c => c.DateTime());
            AlterColumn("dbo.Users", "BirthDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Taches", "OrgNom");
            AddPrimaryKey("dbo.Taches", new[] { "IdTache", "Nom" });
        }
    }
}