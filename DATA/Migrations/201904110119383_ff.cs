namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
    "dbo.Taches",
    c => new
    {
        IdTache = c.Int(nullable: false, identity: true),
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
        }
        
        public override void Down()
        {
        }
    }
}
