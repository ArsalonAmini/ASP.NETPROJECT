namespace MVCWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addressstate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "StateID", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "StateID");
            AddForeignKey("dbo.Addresses", "StateID", "dbo.States", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "StateID", "dbo.States");
            DropIndex("dbo.Addresses", new[] { "StateID" });
            DropColumn("dbo.Addresses", "StateID");
        }
    }
}
