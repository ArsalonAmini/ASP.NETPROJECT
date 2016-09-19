namespace MVCWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class payment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.Int(nullable: false),
                        paymentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Payments", t => t.paymentId, cascadeDelete: true)
                .Index(t => t.paymentId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CreditCardNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "paymentId", "dbo.Payments");
            DropIndex("dbo.Transactions", new[] { "paymentId" });
            DropTable("dbo.Payments");
            DropTable("dbo.Transactions");
        }
    }
}
