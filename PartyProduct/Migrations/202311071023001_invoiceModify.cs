namespace PartyProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class invoiceModify : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Invoices", "Total");


        }

        public override void Down()
        {
            AddColumn("dbo.Invoices", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
