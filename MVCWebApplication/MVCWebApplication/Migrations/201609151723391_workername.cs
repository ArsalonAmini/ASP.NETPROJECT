namespace MVCWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workers", "Name");
        }
    }
}
