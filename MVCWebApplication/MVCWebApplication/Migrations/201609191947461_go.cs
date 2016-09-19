namespace MVCWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class go : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "StartDate", c => c.String(nullable: false));
            AlterColumn("dbo.Schedules", "SkipDate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "SkipDate", c => c.Int(nullable: false));
            AlterColumn("dbo.Schedules", "StartDate", c => c.Int(nullable: false));
        }
    }
}
