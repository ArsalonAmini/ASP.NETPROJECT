namespace MVCWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Transactions", "ServiceId", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "ScheduleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "ServiceId");
            CreateIndex("dbo.Transactions", "ScheduleId");
            AddForeignKey("dbo.Transactions", "ScheduleId", "dbo.Schedules", "id", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "ServiceId", "dbo.Services", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Transactions", "ScheduleId", "dbo.Schedules");
            DropIndex("dbo.Transactions", new[] { "ScheduleId" });
            DropIndex("dbo.Transactions", new[] { "ServiceId" });
            DropColumn("dbo.Transactions", "ScheduleId");
            DropColumn("dbo.Transactions", "ServiceId");
            DropTable("dbo.Services");
        }
    }
}
