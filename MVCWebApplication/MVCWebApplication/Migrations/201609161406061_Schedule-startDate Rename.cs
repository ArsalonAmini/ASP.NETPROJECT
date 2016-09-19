namespace MVCWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchedulestartDateRename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "StartDate", c => c.Int(nullable: false));
            AddColumn("dbo.Schedules", "SkipDate", c => c.Int(nullable: false));
            DropColumn("dbo.Schedules", "date");
            DropColumn("dbo.Schedules", "date2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "date2", c => c.Int(nullable: false));
            AddColumn("dbo.Schedules", "date", c => c.Int(nullable: false));
            DropColumn("dbo.Schedules", "SkipDate");
            DropColumn("dbo.Schedules", "StartDate");
        }
    }
}
