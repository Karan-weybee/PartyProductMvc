namespace PartyProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvoice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Rate_Of_Product = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Party_id = c.Int(),
                        Product_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Parties", t => t.Party_id)
                .ForeignKey("dbo.Products", t => t.Product_id)
                .Index(t => t.Party_id)
                .Index(t => t.Product_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "Product_id", "dbo.Products");
            DropForeignKey("dbo.Invoices", "Party_id", "dbo.Parties");
            DropIndex("dbo.Invoices", new[] { "Product_id" });
            DropIndex("dbo.Invoices", new[] { "Party_id" });
            DropTable("dbo.Invoices");
        }
    }
}
