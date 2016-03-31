namespace GrosBrasInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDLienPanierINClient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "PanierID", c => c.Int(nullable: false));
            CreateIndex("dbo.Clients", "PanierID");
            AddForeignKey("dbo.Clients", "PanierID", "dbo.Paniers", "PanierID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "PanierID", "dbo.Paniers");
            DropIndex("dbo.Clients", new[] { "PanierID" });
            DropColumn("dbo.Clients", "PanierID");
        }
    }
}
