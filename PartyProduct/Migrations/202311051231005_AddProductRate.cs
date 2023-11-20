namespace PartyProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductRate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssignParties", "Party_id", "dbo.Parties");
            DropForeignKey("dbo.AssignParties", "Product_id", "dbo.Products");
            DropIndex("dbo.AssignParties", new[] { "Party_id" });
            DropIndex("dbo.AssignParties", new[] { "Product_id" });
            CreateTable(
                "dbo.ProductRates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date_Of_Rate = c.DateTime(nullable: false),
                        Product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: true)
                .Index(t => t.Product_id);
            
            AlterColumn("dbo.AssignParties", "Party_id", c => c.Int(nullable: false));
            AlterColumn("dbo.AssignParties", "Product_id", c => c.Int(nullable: false));
            CreateIndex("dbo.AssignParties", "Party_id");
            CreateIndex("dbo.AssignParties", "Product_id");
            AddForeignKey("dbo.AssignParties", "Party_id", "dbo.Parties", "id", cascadeDelete: true);
            AddForeignKey("dbo.AssignParties", "Product_id", "dbo.Products", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignParties", "Product_id", "dbo.Products");
            DropForeignKey("dbo.AssignParties", "Party_id", "dbo.Parties");
            DropForeignKey("dbo.ProductRates", "Product_id", "dbo.Products");
            DropIndex("dbo.ProductRates", new[] { "Product_id" });
            DropIndex("dbo.AssignParties", new[] { "Product_id" });
            DropIndex("dbo.AssignParties", new[] { "Party_id" });
            AlterColumn("dbo.AssignParties", "Product_id", c => c.Int());
            AlterColumn("dbo.AssignParties", "Party_id", c => c.Int());
            DropTable("dbo.ProductRates");
            CreateIndex("dbo.AssignParties", "Product_id");
            CreateIndex("dbo.AssignParties", "Party_id");
            AddForeignKey("dbo.AssignParties", "Product_id", "dbo.Products", "id");
            AddForeignKey("dbo.AssignParties", "Party_id", "dbo.Parties", "id");
        }
    }
}
