namespace MVCWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schedule : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Transactions", new[] { "paymentId" });
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.Transactions", "PaymentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Transactions", new[] { "PaymentId" });
            DropTable("dbo.Schedules");
            CreateIndex("dbo.Transactions", "paymentId");
        }
    }
}
