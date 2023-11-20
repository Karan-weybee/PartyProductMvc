namespace PartyProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssign2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AssignParties", "PartyId");
            DropColumn("dbo.AssignParties", "productId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssignParties", "productId", c => c.Byte(nullable: false));
            AddColumn("dbo.AssignParties", "PartyId", c => c.Byte(nullable: false));
        }
    }
}
