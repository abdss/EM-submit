namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Distance = c.Int(nullable: false),
                        FloorNumber = c.Int(nullable: false),
                        HasCoupon = c.Boolean(nullable: false),
                        IsNewCustomer = c.Boolean(nullable: false),
                        IsGoldRatedCustomer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.ID, name: "UniqueCustomerId");
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        BaseCost = c.Double(nullable: false),
                        IsPlacedOnWeekend = c.Boolean(nullable: false),
                        OrderedCustomer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.OrderedCustomer_ID)
                .Index(t => t.ID, name: "UniqueOrderId")
                .Index(t => t.OrderedCustomer_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderedCustomer_ID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "OrderedCustomer_ID" });
            DropIndex("dbo.Orders", "UniqueOrderId");
            DropIndex("dbo.Customers", "UniqueCustomerId");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
