namespace MVCWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedTransaction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Transactions", new[] { "AddressId" });
            AddColumn("dbo.Customers", "TransactionID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "TransactionID");
            AddForeignKey("dbo.Customers", "TransactionID", "dbo.Transactions", "id", cascadeDelete: true);
            DropColumn("dbo.Transactions", "AddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "AddressId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "TransactionID", "dbo.Transactions");
            DropIndex("dbo.Customers", new[] { "TransactionID" });
            DropColumn("dbo.Customers", "TransactionID");
            CreateIndex("dbo.Transactions", "AddressId");
            AddForeignKey("dbo.Transactions", "AddressId", "dbo.Addresses", "id", cascadeDelete: true);
        }
    }
}
