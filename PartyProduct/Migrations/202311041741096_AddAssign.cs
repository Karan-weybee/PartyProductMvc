namespace PartyProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssign : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignParties",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PartyId = c.Byte(nullable: false),
                        productId = c.Byte(nullable: false),
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
            DropForeignKey("dbo.AssignParties", "Product_id", "dbo.Products");
            DropForeignKey("dbo.AssignParties", "Party_id", "dbo.Parties");
            DropIndex("dbo.AssignParties", new[] { "Product_id" });
            DropIndex("dbo.AssignParties", new[] { "Party_id" });
            DropTable("dbo.AssignParties");
        }
    }
}
