namespace GrosBrasInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePanierINArticles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "PanierID", "dbo.Paniers");
            DropIndex("dbo.Articles", new[] { "PanierID" });
            DropColumn("dbo.Articles", "PanierID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "PanierID", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "PanierID");
            AddForeignKey("dbo.Articles", "PanierID", "dbo.Paniers", "PanierID", cascadeDelete: true);
        }
    }
}
