namespace GrosBrasInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATEUnitPriceINOrderDetails : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetails", "UnitPrice", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
