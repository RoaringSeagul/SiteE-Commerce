namespace GrosBrasInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class REMOVEPanierINApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Panier_PanierID", "dbo.Paniers");
            DropIndex("dbo.AspNetUsers", new[] { "Panier_PanierID" });
            DropColumn("dbo.AspNetUsers", "Panier_PanierID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Panier_PanierID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Panier_PanierID");
            AddForeignKey("dbo.AspNetUsers", "Panier_PanierID", "dbo.Paniers", "PanierID");
        }
    }
}
