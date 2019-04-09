namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "logo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "logo");
        }
    }
}
