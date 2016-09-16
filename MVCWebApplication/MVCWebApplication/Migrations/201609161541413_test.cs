namespace MVCWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "DOB", c => c.Int(nullable: false));
            DropForeignKey("dbo.Transactions", "ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.Transactions", "PaymentId", "dbo.Payments");
            DropForeignKey("dbo.Transactions", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Transactions", new[] { "PaymentId" });
            DropIndex("dbo.Transactions", new[] { "ScheduleId" });
            DropIndex("dbo.Transactions", new[] { "AddressId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Schedules");
            DropTable("dbo.Payments");
        }
    }
}
