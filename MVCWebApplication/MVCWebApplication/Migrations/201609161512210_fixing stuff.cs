namespace MVCWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingstuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CreditCardNumber = c.Int(nullable: false),
                        ExpirationDate = c.Int(nullable: false),
                        SecurityCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        StartDate = c.Int(nullable: false),
                        SkipDate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        ScheduleId = c.Int(nullable: false),
                        PaymentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Payments", t => t.PaymentId, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId, cascadeDelete: true)
                .Index(t => t.AddressId)
                .Index(t => t.ScheduleId)
                .Index(t => t.PaymentId);
            
            DropColumn("dbo.Customers", "DOB");
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
