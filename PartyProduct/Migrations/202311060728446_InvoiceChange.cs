namespace PartyProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "Party_id", "dbo.Parties");
            DropForeignKey("dbo.Invoices", "Product_id", "dbo.Products");
            DropIndex("dbo.Invoices", new[] { "Party_id" });
            DropIndex("dbo.Invoices", new[] { "Product_id" });
            AlterColumn("dbo.Invoices", "Party_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Invoices", "Product_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoices", "Party_id");
            CreateIndex("dbo.Invoices", "Product_id");
            AddForeignKey("dbo.Invoices", "Party_id", "dbo.Parties", "id", cascadeDelete: true);
            AddForeignKey("dbo.Invoices", "Product_id", "dbo.Products", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "Product_id", "dbo.Products");
            DropForeignKey("dbo.Invoices", "Party_id", "dbo.Parties");
            DropIndex("dbo.Invoices", new[] { "Product_id" });
            DropIndex("dbo.Invoices", new[] { "Party_id" });
            AlterColumn("dbo.Invoices", "Product_id", c => c.Int());
            AlterColumn("dbo.Invoices", "Party_id", c => c.Int());
            CreateIndex("dbo.Invoices", "Product_id");
            CreateIndex("dbo.Invoices", "Party_id");
            AddForeignKey("dbo.Invoices", "Product_id", "dbo.Products", "id");
            AddForeignKey("dbo.Invoices", "Party_id", "dbo.Parties", "id");
        }
    }
}
