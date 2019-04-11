namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Taches");
            AddPrimaryKey("dbo.Taches", "IdTache");
        }
        
        public override void Down()
        {
        }
    }
}
