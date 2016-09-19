namespace MVCWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class address : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "Street", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "Street", c => c.String(nullable: false));
        }
    }
}
