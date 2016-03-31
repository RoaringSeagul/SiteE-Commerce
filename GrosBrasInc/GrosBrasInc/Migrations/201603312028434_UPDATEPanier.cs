namespace GrosBrasInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATEPanier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paniers", "ArticleID", c => c.Int(nullable: false));
            AddColumn("dbo.Paniers", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.Paniers", "DateCreated", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Paniers", "ArticleID");
            AddForeignKey("dbo.Paniers", "ArticleID", "dbo.Articles", "ArticleID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paniers", "ArticleID", "dbo.Articles");
            DropIndex("dbo.Paniers", new[] { "ArticleID" });
            DropColumn("dbo.Paniers", "DateCreated");
            DropColumn("dbo.Paniers", "Count");
            DropColumn("dbo.Paniers", "ArticleID");
        }
    }
}
