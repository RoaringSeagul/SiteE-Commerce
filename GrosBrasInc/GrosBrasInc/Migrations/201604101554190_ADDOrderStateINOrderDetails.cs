namespace GrosBrasInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDOrderStateINOrderDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "AspNetUserID", c => c.String(maxLength: 128));
            AddColumn("dbo.OrderDetails", "State", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "AspNetUserID");
            AddForeignKey("dbo.OrderDetails", "AspNetUserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "AspNetUserID", "dbo.AspNetUsers");
            DropIndex("dbo.OrderDetails", new[] { "AspNetUserID" });
            DropColumn("dbo.OrderDetails", "State");
            DropColumn("dbo.OrderDetails", "AspNetUserID");
        }
    }
}
