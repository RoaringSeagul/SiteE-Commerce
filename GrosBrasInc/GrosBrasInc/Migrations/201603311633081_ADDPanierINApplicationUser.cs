namespace GrosBrasInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDPanierINApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Panier_PanierID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Panier_PanierID");
            AddForeignKey("dbo.AspNetUsers", "Panier_PanierID", "dbo.Paniers", "PanierID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Panier_PanierID", "dbo.Paniers");
            DropIndex("dbo.AspNetUsers", new[] { "Panier_PanierID" });
            DropColumn("dbo.AspNetUsers", "Panier_PanierID");
        }
    }
}
