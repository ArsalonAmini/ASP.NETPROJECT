namespace MVCWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionviewmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "ServiceId", "dbo.Services");
            DropIndex("dbo.Transactions", new[] { "ServiceId" });
            AddColumn("dbo.Payments", "ExpirationDate", c => c.Int(nullable: false));
            AddColumn("dbo.Payments", "SecurityCode", c => c.Int(nullable: false));
            AddColumn("dbo.Schedules", "date2", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "AddressId");
            AddForeignKey("dbo.Transactions", "AddressId", "dbo.Addresses", "id", cascadeDelete: true);
            DropColumn("dbo.Customers", "DOB");
            DropColumn("dbo.Transactions", "date");
            DropColumn("dbo.Transactions", "ServiceId");
            DropTable("dbo.Services");
        }
        
        public override void Down()
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
            AddColumn("dbo.Transactions", "date", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "DOB", c => c.Int(nullable: false));
            DropForeignKey("dbo.Transactions", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Transactions", new[] { "AddressId" });
            DropColumn("dbo.Transactions", "AddressId");
            DropColumn("dbo.Schedules", "date2");
            DropColumn("dbo.Payments", "SecurityCode");
            DropColumn("dbo.Payments", "ExpirationDate");
            CreateIndex("dbo.Transactions", "ServiceId");
            AddForeignKey("dbo.Transactions", "ServiceId", "dbo.Services", "id", cascadeDelete: true);
        }
    }
}
