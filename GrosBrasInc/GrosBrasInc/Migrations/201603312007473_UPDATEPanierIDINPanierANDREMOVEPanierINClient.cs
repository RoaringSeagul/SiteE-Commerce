namespace GrosBrasInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATEPanierIDINPanierANDREMOVEPanierINClient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "PanierID", "dbo.Paniers");
            DropIndex("dbo.Clients", new[] { "PanierID" });
            AddColumn("dbo.Paniers", "KeyPanier", c => c.String());
            DropColumn("dbo.Clients", "PanierID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "PanierID", c => c.Int(nullable: false));
            DropColumn("dbo.Paniers", "KeyPanier");
            CreateIndex("dbo.Clients", "PanierID");
            AddForeignKey("dbo.Clients", "PanierID", "dbo.Paniers", "PanierID", cascadeDelete: true);
        }
    }
}
