namespace MVCWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionmodelupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "TransactionID", "dbo.Transactions");
            DropIndex("dbo.Customers", new[] { "TransactionID" });
            AddColumn("dbo.Transactions", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "CustomerId");
            AddForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "TransactionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "TransactionID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropColumn("dbo.Transactions", "CustomerId");
            CreateIndex("dbo.Customers", "TransactionID");
            AddForeignKey("dbo.Customers", "TransactionID", "dbo.Transactions", "id", cascadeDelete: true);
        }
    }
}
